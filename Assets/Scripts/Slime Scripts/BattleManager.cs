using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{

    public Button moveButtonPrefab;
    public Image textWindowPrefab, moveSelectBGPrefab;
    public Button targetButtonPrefab;

    Button[] moveSelectButtons = new Button[5];
    public Canvas canvas;
    public Image moveSelectPanel;
    public Image targetSelectPanel;
    public Image textPanel;
    public SlimeSpawnerHelper spawner;
    public BattleOrder bo;
    
    Battle currentBattle;
    Player player = new Player();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){ ////// commented to prevent auto battle starting
        /*currentBattle = new Battle(player,(Slime)player.team[0],(Slime)player.team[1],new Slime(2), new Slime(3),"Forest",bo);
        currentBattle.startBattle(player,this,spawner);*/

    }

    public void startEncouter(string stage,GameObject teleporter){
        if(player.team.Count>=2){
            currentBattle = new Battle(player,player.team[0],player.team[1],stage,bo);
            currentBattle.startBattle(player,this,spawner,teleporter);
        }else {
            currentBattle = new Battle(player,player.team[0],stage,bo);
            currentBattle.startBattle(player,this,spawner,teleporter);
        }

    }

    public void moveSelectUI(Slime s,SlimeSpawnerHelper spawner){ 

        moveSelectPanel.gameObject.SetActive(true);

        Button bt1,bt2,bt3,addOButton; 
        Image msbg;
        

        msbg= Instantiate(moveSelectBGPrefab,  new Vector3(10,90,0), transform.rotation); 
        msbg.transform.SetParent(moveSelectPanel.transform,false);

        bt1 = Instantiate(moveButtonPrefab,  new Vector3(96,115,0), transform.rotation);
        bt2 = Instantiate(moveButtonPrefab,  new Vector3(-76,115,0), transform.rotation);
        bt3 = Instantiate(moveButtonPrefab,  new Vector3(-76,70,0), transform.rotation); 
        addOButton= Instantiate(moveButtonPrefab,  new Vector3(96,70,0), transform.rotation);       
        addOButton.GetComponentInChildren<TextMeshProUGUI>().text = "Ooze";
        addOButton.transform.SetParent(moveSelectPanel.transform,false);

        addOButton.GetComponent<Button>().onClick.AddListener(()=> s.increaseOoze(currentBattle.consumeOoze()));
        for(int i=0; i<s.moves.Length;i++){
            Debug.Log("msui"+i);
           
            
            if(i>=3)
                break;
            //set button text
            //set button position based on index
            
            if(i==0){
                bt1.GetComponentInChildren<TextMeshProUGUI>().text = s.moves[0].moveName;
                bt1.transform.SetParent(moveSelectPanel.transform,false);

                bt1.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectAMove(player,s.moves[0],currentBattle.enemySlimes[0],this,spawner)); //set actual targets and move apparently

            }else if(i==1){
                bt2.GetComponentInChildren<TextMeshProUGUI>().text = s.moves[1].moveName;
                bt2.transform.SetParent(moveSelectPanel.transform,false);

                bt2.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectAMove(player,s.moves[1],currentBattle.enemySlimes[0],this,spawner)); //set actual targets and move apparently

            } else{
                bt3.GetComponentInChildren<TextMeshProUGUI>().text = s.moves[2].moveName;
                bt3.transform.SetParent(moveSelectPanel.transform,false);

                bt3.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectAMove(player,s.moves[2],currentBattle.enemySlimes[0],this,spawner)); //set actual targets and move apparently

            } 
            

            
            
            
        }
        //Debug.Log(moveSelectButtons);
        

    }


    public void selectMoveTargetUI(List<Slime> pSlimes, List<Slime>eSlimes, Move m,SlimeSpawnerHelper spawner){ 

        targetSelectPanel.gameObject.SetActive(true);

        Button tsb1,tsb2,tsb3; 

        tsb1 = Instantiate(targetButtonPrefab, new Vector3(-76,200,0), transform.rotation);
        tsb2 = Instantiate(targetButtonPrefab,  new Vector3(76,200,0), transform.rotation);
        tsb3 = Instantiate(targetButtonPrefab,  new Vector3(0,80,0), transform.rotation);      

        for(int i=0; i<3;i++){
           
            
            if(i>=3)
                break;
            //set button text
            //set button position based on index
            
            if(i==0){
                tsb1.GetComponentInChildren<TextMeshProUGUI>().text = "Opposing " + eSlimes[0].speciesName + " Slime";
                tsb1.transform.SetParent(targetSelectPanel.transform,false);

                tsb1.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectMoveTarget(player,m,eSlimes[0],this,spawner)); 

            }else if(i==1 && eSlimes.Count>=(i+1)){
                tsb2.GetComponentInChildren<TextMeshProUGUI>().text = "Opposing " + eSlimes[1].speciesName+ " Slime";
                tsb2.transform.SetParent(targetSelectPanel.transform,false);

                tsb2.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectMoveTarget(player,m,eSlimes[1],this,spawner)); 

            } else{
                if(pSlimes.Count>=2 && !pSlimes[0].Equals(m.owner)){
                    tsb3.GetComponentInChildren<TextMeshProUGUI>().text = "Your " + pSlimes[0].speciesName+ " Slime";
                    tsb3.transform.SetParent(targetSelectPanel.transform,false);
                    tsb3.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectMoveTarget(player,m,pSlimes[1],this,spawner)); 

                }else if(pSlimes.Count>=2 && !pSlimes[1].Equals(m.owner)){
                    tsb3.GetComponentInChildren<TextMeshProUGUI>().text = "Your " +pSlimes[1].speciesName+ " Slime";
                    tsb3.transform.SetParent(targetSelectPanel.transform,false);
                    tsb3.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectMoveTarget(player,m,pSlimes[0],this,spawner));
                    
                }
                
                


            } 
            

            
            
            
        }
        //Debug.Log(moveSelectButtons);
        

    }

    public void textWindowUI(string str){ 

        textPanel.gameObject.SetActive(true);
        

        Image textWindow; 

        textWindow = Instantiate(textWindowPrefab,  new Vector3(4,50,0), transform.rotation);
        textWindow.GetComponentInChildren<TextMeshProUGUI>().text = str;
        textWindow.transform.SetParent(textPanel.transform,false);
     
    }

    public void closeTextWinowUI(){
        //foreach(Button button in moveSelectButtons){
            //Destroy(button);
        foreach (Transform child in textPanel.transform){
            GameObject.Destroy(child.gameObject);
        }

        textPanel.gameObject.SetActive(false);
    }

    public void closeSelectMoveTargetUI(){
        //foreach(Button button in moveSelectButtons){
            //Destroy(button);
        foreach (Transform child in targetSelectPanel.transform){
            GameObject.Destroy(child.gameObject);
        }
        //Destroy(targetSelectPanel.transform.GetChild(0).gameObject);
        //Destroy(targetSelectPanel.transform.GetChild(1).gameObject);
        //Destroy(targetSelectPanel.transform.GetChild(2).gameObject);

        //Debug.Log("Target Select UI closed");

        //}

        targetSelectPanel.gameObject.SetActive(false);
    }

    public void closeMoveSelectUI(){

        foreach (Transform child in moveSelectPanel.transform){
            GameObject.Destroy(child.gameObject);
        }

        
        //foreach(Button button in moveSelectButtons){
            //Destroy(button);

        /*Destroy(moveSelectPanel.transform.GetChild(0).gameObject);
        Destroy(moveSelectPanel.transform.GetChild(1).gameObject);
        Destroy(moveSelectPanel.transform.GetChild(2).gameObject);*/

        //Debug.Log("Move select UI closed");
        

        moveSelectPanel.gameObject.SetActive(false);

        //}
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            Cursor.lockState = CursorLockMode.None;

        if (Input.GetKey(KeyCode.E))
            Cursor.lockState = CursorLockMode.Locked;
        
    }
}
