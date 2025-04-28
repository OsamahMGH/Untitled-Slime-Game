using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{

    public Button buttonPrefab;
    Button[] moveSelectButtons = new Button[5];
    public Canvas canvas;
    public Image moveSelectPanel;
    public Image targetSelectPanel;
    
    Battle currentBattle;
    Player player = new Player();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){ //////
        //moveSelectUI(new Slime(1));
        currentBattle = new Battle(player,(Slime)player.team[0],(Slime)player.team[1],new Slime(4), new Slime(5));
        currentBattle.startBattle(player,this);

        
    }

    public void moveSelectUI(Slime s){ 

        moveSelectPanel.gameObject.SetActive(true);

        Button bt1,bt2,bt3,addOButton; 

        bt1 = Instantiate(buttonPrefab,  new Vector3(0,-35,0), transform.rotation);
        bt2 = Instantiate(buttonPrefab,  new Vector3(0,-70,0), transform.rotation);
        bt3 = Instantiate(buttonPrefab,  new Vector3(0,-105,0), transform.rotation); 
        addOButton= Instantiate(buttonPrefab,  new Vector3(0,-140,0), transform.rotation);     

        addOButton= Instantiate(buttonPrefab,  new Vector3(0,-140,0), transform.rotation);     
        addOButton.GetComponentInChildren<TextMeshProUGUI>().text = "Ooze";
        addOButton.transform.SetParent(moveSelectPanel.transform,false);

        addOButton.GetComponent<Button>().onClick.AddListener(()=> s.increaseOoze(currentBattle.consumeOoze()));
        for(int i=0; i<s.moves.Length;i++){
           
            
            if(i>=3)
                break;
            //set button text
            //set button position based on index
            
            if(i==0){
                bt1.GetComponentInChildren<TextMeshProUGUI>().text = s.moves[0].moveName;
                bt1.transform.SetParent(moveSelectPanel.transform,false);

                bt1.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectAMove(player,s.moves[0],currentBattle.enemySlimes[0],this)); //set actual targets and move apparently

            }else if(i==1){
                bt2.GetComponentInChildren<TextMeshProUGUI>().text = s.moves[1].moveName;
                bt2.transform.SetParent(moveSelectPanel.transform,false);

                bt2.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectAMove(player,s.moves[1],currentBattle.enemySlimes[0],this)); //set actual targets and move apparently

            } else{
                bt3.GetComponentInChildren<TextMeshProUGUI>().text = s.moves[2].moveName;
                bt3.transform.SetParent(moveSelectPanel.transform,false);

                bt3.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectAMove(player,s.moves[2],currentBattle.enemySlimes[0],this)); //set actual targets and move apparently

            } 
            

            
            
            
        }
        //Debug.Log(moveSelectButtons);
        

    }


    public void selectMoveTargetUI(List<Slime> pSlimes, List<Slime>eSlimes, Move m){ 

        targetSelectPanel.gameObject.SetActive(true);

        Button tsb1,tsb2,tsb3; 

        tsb1 = Instantiate(buttonPrefab,  new Vector3(-10,-35,-10), transform.rotation);
        tsb2 = Instantiate(buttonPrefab,  new Vector3(10,-70,10), transform.rotation);
        tsb3 = Instantiate(buttonPrefab,  new Vector3(20,-105,20), transform.rotation);      

        for(int i=0; i<3;i++){
           
            
            if(i>=3)
                break;
            //set button text
            //set button position based on index
            
            if(i==0){
                tsb1.GetComponentInChildren<TextMeshProUGUI>().text = eSlimes[0].speciesName + "E0";
                tsb1.transform.SetParent(targetSelectPanel.transform,false);

                tsb1.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectMoveTarget(player,m,eSlimes[0],this)); 

            }else if(i==1 && eSlimes.Count>=(i+1)){
                tsb2.GetComponentInChildren<TextMeshProUGUI>().text = eSlimes[1].speciesName+ "E1";
                tsb2.transform.SetParent(targetSelectPanel.transform,false);

                tsb2.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectMoveTarget(player,m,eSlimes[1],this)); 

            } else{
                if(!pSlimes[0].Equals(m.owner)&& pSlimes.Count>=1){
                    tsb3.GetComponentInChildren<TextMeshProUGUI>().text = pSlimes[0].speciesName+ "P0";
                    tsb3.transform.SetParent(targetSelectPanel.transform,false);
                    tsb3.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectMoveTarget(player,m,pSlimes[1],this)); 

                }else if(pSlimes.Count>=2){
                    tsb3.GetComponentInChildren<TextMeshProUGUI>().text = pSlimes[1].speciesName+ "P1";
                    tsb3.transform.SetParent(targetSelectPanel.transform,false);
                    tsb3.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectMoveTarget(player,m,pSlimes[0],this));
                    
                }
                
                


            } 
            

            
            
            
        }
        //Debug.Log(moveSelectButtons);
        

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

        
        //foreach(Button button in moveSelectButtons){
            //Destroy(button);

        Destroy(moveSelectPanel.transform.GetChild(0).gameObject);
        Destroy(moveSelectPanel.transform.GetChild(1).gameObject);
        Destroy(moveSelectPanel.transform.GetChild(2).gameObject);

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
