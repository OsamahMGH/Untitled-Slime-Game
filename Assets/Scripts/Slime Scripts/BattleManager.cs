using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Controls;

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
    Image hP0,hP1, hP2,hP3; 
    public Image hpPrefab;
    public Image healthPointPanel;

    int encouterCount =0;
    
    public Battle currentBattle;
    public Player player = new Player();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){ ////// commented to prevent auto battle starting
        /*currentBattle = new Battle(player,(Slime)player.team[0],(Slime)player.team[1],new Slime(2), new Slime(3),"Forest",bo);
        currentBattle.startBattle(player,this,spawner);*/

    }

    void Update(){

        if (Input.GetKey(KeyCode.I)){
            bo.displayNotification(this,2f,"Team: " + player.team.Count + "/" + player.team.Capacity + " Slimes \t Max Ooze Stored: "+ player.maxOozeLevel+"\nCurrency: "+player.currency+" \t\t Uniqe Items Stored: " + player.getInventorySize());

            }
    }
    public void startEncouter(string stage,GameObject teleporter){
        if(player.team.Count<=0){
           Debug.Log("Game Over");
           textWindowUI("You are out of Slimes.. It's Game Over for you.");
           StartCoroutine(gameOver());
           return;

        }
        bool isBoss = false;
        encouterCount++;
        if(encouterCount>=5){
            if(UnityEngine.Random.Range(encouterCount,11)>10){
                isBoss = true;
                encouterCount=0;
            }
        }
        if(player.team.Count>=2){
            currentBattle = new Battle(player,player.team[0],player.team[1],stage,bo,isBoss);
            currentBattle.startBattle(player,this,spawner,teleporter);
        }else {
            currentBattle = new Battle(player,player.team[0],stage,bo,isBoss);
            currentBattle.startBattle(player,this,spawner,teleporter);
        }

    }

    public void healthPointsUI(Slime s, int pos){

        healthPointPanel.gameObject.SetActive(true);
        
        switch(pos){
            case 0:
                hP0=Instantiate(hpPrefab,  new Vector3(-51*3,52*3,0), transform.rotation);
                hP0.GetComponentInChildren<TextMeshProUGUI>().text = s.speciesName+" Slime \n"+s.currentHP+"/"+s.maxHP+"";
                PointerEventsController script5 = hP0.GetComponent<PointerEventsController>();
                script5.setDescription("Ooze Level: "+s.oozeLevel+" Attack: " + s.currentAttack + " Speed: " + s.currentSpeed + " Accuracy: " + s.accuracy );
                script5.setBattleManager(this);
                hP0.transform.SetParent(healthPointPanel.transform,false);
                break;
            case 1:
                hP1=Instantiate(hpPrefab,  new Vector3(56*3,52*3,0), transform.rotation);
                hP1.GetComponentInChildren<TextMeshProUGUI>().text = s.speciesName+" Slime \n"+s.currentHP+"/"+s.maxHP+"";
                PointerEventsController script6 = hP1.GetComponent<PointerEventsController>();
                script6.setDescription("Ooze Level: "+s.oozeLevel+" Attack: " + s.currentAttack + " Speed: " + s.currentSpeed + " Accuracy: " + s.accuracy );
                script6.setBattleManager(this);
                hP1.transform.SetParent(healthPointPanel.transform,false);
                break;
            case 2:
                hP2=Instantiate(hpPrefab,  new Vector3(-51*3,136*3,0), transform.rotation);
                hP2.GetComponentInChildren<TextMeshProUGUI>().text = s.speciesName+" Slime \n"+s.currentHP+"/"+s.maxHP+"";
                PointerEventsController script7 = hP2.GetComponent<PointerEventsController>();
                script7.setDescription("Ooze Level: "+s.oozeLevel+" Attack: " + s.currentAttack + " Speed: " + s.currentSpeed + " Accuracy: " + s.accuracy );
                script7.setBattleManager(this);
                hP2.transform.SetParent(healthPointPanel.transform,false);
                break;
            case 3:
                hP3=Instantiate(hpPrefab,  new Vector3(56*3,136*3,0), transform.rotation);
                hP3.GetComponentInChildren<TextMeshProUGUI>().text = s.speciesName+" Slime \n"+s.currentHP+"/"+s.maxHP+"";
                PointerEventsController script8 = hP3.GetComponent<PointerEventsController>();
                script8.setDescription("Ooze Level: "+s.oozeLevel+" Attack: " + s.currentAttack + " Speed: " + s.currentSpeed + " Accuracy: " + s.accuracy );
                script8.setBattleManager(this);
                hP3.transform.SetParent(healthPointPanel.transform,false);
                break;
        }
        
        
        
    }

    public void updateHealthPointsUI(Slime s,int pos){
        switch(pos){
            case 0:
                hP0.GetComponentInChildren<TextMeshProUGUI>().text = s.speciesName+" Slime \n"+s.currentHP+"/"+s.maxHP+"";
                break;
            case 1:
                hP1.GetComponentInChildren<TextMeshProUGUI>().text = s.speciesName+" Slime \n"+s.currentHP+"/"+s.maxHP+"";
                break;
            case 2:
                hP2.GetComponentInChildren<TextMeshProUGUI>().text = s.speciesName+" Slime \n"+s.currentHP+"/"+s.maxHP+"";
                break;
            case 3:
                hP3.GetComponentInChildren<TextMeshProUGUI>().text = s.speciesName+" Slime \n"+s.currentHP+"/"+s.maxHP+"";
                break;
        }

    }

    public void moveSelectUI(Slime s,SlimeSpawnerHelper spawner){ 

        moveSelectPanel.gameObject.SetActive(true);

        Button bt1,bt2,bt3,addOButton; 
        Image msbg;
        

        msbg= Instantiate(moveSelectBGPrefab,  new Vector3(-600,255,0), transform.rotation); 
        msbg.transform.SetParent(moveSelectPanel.transform,false);

        bt1 = Instantiate(moveButtonPrefab,  new Vector3(-120 *3,115*3,0), transform.rotation);
        bt2 = Instantiate(moveButtonPrefab,  new Vector3(-292*3,115*3,0), transform.rotation);
        bt3 = Instantiate(moveButtonPrefab,  new Vector3(-292*3,70*3,0), transform.rotation); 
        addOButton= Instantiate(moveButtonPrefab,  new Vector3(-120*3,70*3,0), transform.rotation);       
        addOButton.GetComponentInChildren<TextMeshProUGUI>().text = "Add Ooze";
        addOButton.transform.SetParent(moveSelectPanel.transform,false);

        addOButton.GetComponent<Button>().onClick.AddListener(()=> s.increaseOoze(currentBattle.consumeOoze(this),this));
        PointerEventsController script4 = addOButton.GetComponent<PointerEventsController>();
        script4.setDescription("Adding Ooze increases this " + s.speciesName + " Slime's base stats during this battle");
        script4.setBattleManager(this);
        
        for(int i=0; i<s.moves.Length;i++){
            //Debug.Log("msui"+i);
           
            
            if(i>=3)
                break;
            //set button text
            //set button position based on index
            
            if(i==0){
                bt1.GetComponentInChildren<TextMeshProUGUI>().text = s.moves[0].moveName;
                bt1.transform.SetParent(moveSelectPanel.transform,false);

                bt1.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectAMove(player,s.moves[0],currentBattle.enemySlimes[0],this,spawner)); //set actual targets and move apparently
                PointerEventsController script1 = bt1.GetComponent<PointerEventsController>();
                script1.setDescription(s.moves[0].moveDescription);
                script1.setBattleManager(this);
            }else if(i==1){
                bt2.GetComponentInChildren<TextMeshProUGUI>().text = s.moves[1].moveName;
                bt2.transform.SetParent(moveSelectPanel.transform,false);

                bt2.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectAMove(player,s.moves[1],currentBattle.enemySlimes[0],this,spawner)); //set actual targets and move apparently
                PointerEventsController script2 = bt2.GetComponent<PointerEventsController>();
                script2.setDescription(s.moves[1].moveDescription);
                script2.setBattleManager(this);
            } else{
                bt3.GetComponentInChildren<TextMeshProUGUI>().text = s.moves[2].moveName;
                bt3.transform.SetParent(moveSelectPanel.transform,false);

                bt3.GetComponent<Button>().onClick.AddListener(()=> currentBattle.selectAMove(player,s.moves[2],currentBattle.enemySlimes[0],this,spawner)); //set actual targets and move apparently
                PointerEventsController script3 = bt3.GetComponent<PointerEventsController>();
                script3.setDescription(s.moves[2].moveDescription);
                script3.setBattleManager(this);
            } 
            

            
            
            
        }
        //Debug.Log(moveSelectButtons);
        

    }


    public void selectMoveTargetUI(List<Slime> pSlimes, List<Slime>eSlimes, Move m,SlimeSpawnerHelper spawner){ 

        targetSelectPanel.gameObject.SetActive(true);

        Button tsb1,tsb2,tsb3; 

        tsb1 = Instantiate(targetButtonPrefab, new Vector3(-228-500,600,0), transform.rotation);
        tsb2 = Instantiate(targetButtonPrefab,  new Vector3(228-500,600,0), transform.rotation);
        tsb3 = Instantiate(targetButtonPrefab,  new Vector3(-500,240,0), transform.rotation);      

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

        textWindow = Instantiate(textWindowPrefab,  new Vector3(12,240,0), transform.rotation);
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

    public void closeHPUI(){
        //foreach(Button button in moveSelectButtons){
            //Destroy(button);
        foreach (Transform child in healthPointPanel.transform){
            GameObject.Destroy(child.gameObject);
        }

        healthPointPanel.gameObject.SetActive(false);
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
    


    IEnumerator gameOver()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        yield return new WaitForSeconds(3);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
