using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;
using System;


public class Battle{
    
    int turnNumber=1;

    bool isBossBattle;
    string stage; 

    public List<Slime> playerSlimes = new List<Slime>();
    public List<Slime> enemySlimes = new List<Slime>();
    public PriorityQueue<Move,int> battleQueue = new PriorityQueue<Move, int>();
    
    public int oLvl=0;

    BattleOrder battleOrder;
    GameObject stageTeleporter;

    public List<int> forestSlimes = new List<int>();
    public List<int> rareForestSlimes = new List<int>();
    public List<int> fallSlimes = new List<int>();
    public List<int> rareFallSlimes = new List<int>();
    public List<int> winterSlimes = new List<int>();
    public List<int> rareWinterSlimes = new List<int>();
    public List<int> citySlimes = new List<int>();
    public List<int> rareCitySlimes = new List<int>();
    public List<int> islandSlimes = new List<int>();
    public List<int> rareIslandSlimes = new List<int>();
    public List<int> castleSlimes = new List<int>();
    public List<int> rareCastleSlimes = new List<int>();
    


    public  Battle(Player player,Slime allySlime1, Slime allySlime2,string currentStage,BattleOrder bo){
        oLvl = player.maxOozeLevel;

        initilizeLists();

        playerSlimes.Add(allySlime1);
        playerSlimes.Add(allySlime2);
        enemySlimes.Add(generateSlime(currentStage));
        enemySlimes.Add(generateSlime(currentStage));

        stage = currentStage;

        battleOrder = bo;

        


    }

    public  Battle(Player player,Slime allySlime1,string currentStage,BattleOrder bo){
        oLvl = player.maxOozeLevel;

        playerSlimes.Add(allySlime1);
        playerSlimes.Add(generateSlime(currentStage));
        enemySlimes.Add(generateSlime(currentStage));
        stage = currentStage;
        battleOrder = bo;


    }

    void initilizeLists(){
        //forest
        { 
            forestSlimes.Add(1);
            forestSlimes.Add(3);
            forestSlimes.Add(4);
            forestSlimes.Add(6);
            forestSlimes.Add(8);
            forestSlimes.Add(10);
           
            forestSlimes.Add(18);
            forestSlimes.Add(21);
            forestSlimes.Add(22);
            forestSlimes.Add(23);
            forestSlimes.Add(26);
            forestSlimes.Add(29);

            rareForestSlimes.Add(12);
            rareForestSlimes.Add(28);
            rareForestSlimes.Add(30);
            rareForestSlimes.Add(31);
            rareForestSlimes.Add(32);
            rareForestSlimes.Add(33);
            rareForestSlimes.Add(34);
            
        }

        //forest 2 (fall)
        { 
            fallSlimes.Add(1);
            fallSlimes.Add(2);
            fallSlimes.Add(3);
            fallSlimes.Add(4);
            forestSlimes.Add(6);
            fallSlimes.Add(8);
            fallSlimes.Add(10);
            fallSlimes.Add(12);
            fallSlimes.Add(18);
            fallSlimes.Add(21);
            fallSlimes.Add(22);

            rareFallSlimes.Add(7);
            rareFallSlimes.Add(11);
            rareFallSlimes.Add(20);
            rareFallSlimes.Add(28);
            rareFallSlimes.Add(30);
            rareFallSlimes.Add(32);
            rareFallSlimes.Add(33);
            rareFallSlimes.Add(34);
            
        }

        //Winter
        {
            winterSlimes.Add(3);
            winterSlimes.Add(4);
            winterSlimes.Add(5);
            winterSlimes.Add(6);
            winterSlimes.Add(7);
            winterSlimes.Add(9);
            winterSlimes.Add(9);
            winterSlimes.Add(11);
            winterSlimes.Add(17);
            winterSlimes.Add(18);
            winterSlimes.Add(20);
            winterSlimes.Add(21);
            winterSlimes.Add(28);
            winterSlimes.Add(29);
            
            
            
            rareWinterSlimes.Add(5);
            rareWinterSlimes.Add(1);
            rareWinterSlimes.Add(30);
            rareWinterSlimes.Add(32);
            rareWinterSlimes.Add(33);
            rareWinterSlimes.Add(34);
            rareWinterSlimes.Add(24);
            rareWinterSlimes.Add(24);
            rareWinterSlimes.Add(24);
            rareWinterSlimes.Add(26);
            rareWinterSlimes.Add(22);

        }

        //City
        {
            citySlimes.Add(1);
            citySlimes.Add(2);
            citySlimes.Add(4);
            citySlimes.Add(6);
            citySlimes.Add(7);
            citySlimes.Add(8);
            citySlimes.Add(10);
            citySlimes.Add(11);
            citySlimes.Add(18);
            citySlimes.Add(20);
            citySlimes.Add(28);
            citySlimes.Add(31);
            citySlimes.Add(31);
            citySlimes.Add(31);
            


            rareCitySlimes.Add(12);
            rareCitySlimes.Add(29);
            rareCitySlimes.Add(30);
            rareCitySlimes.Add(14);
            rareCitySlimes.Add(17);
            rareCitySlimes.Add(19);
            rareCitySlimes.Add(22);
            rareCitySlimes.Add(23);
            rareCitySlimes.Add(32);
            rareCitySlimes.Add(33);
            rareCitySlimes.Add(34);
            rareCitySlimes.Add(16);

        }

        //Island
        {
            islandSlimes.Add(1);
            islandSlimes.Add(2);
            islandSlimes.Add(6);
            islandSlimes.Add(11);
            islandSlimes.Add(13);
            islandSlimes.Add(13);
            islandSlimes.Add(14); 
            islandSlimes.Add(20);
            islandSlimes.Add(27);
            islandSlimes.Add(28);
            islandSlimes.Add(28);

            rareIslandSlimes.Add(3);
            rareIslandSlimes.Add(4);
            rareIslandSlimes.Add(7);
            rareIslandSlimes.Add(19);
            rareIslandSlimes.Add(30);
            rareIslandSlimes.Add(32);
            rareIslandSlimes.Add(33);
            rareIslandSlimes.Add(34);

        }

        //Castle
        {
            castleSlimes.Add(1);
            castleSlimes.Add(2);
            castleSlimes.Add(2);
            castleSlimes.Add(3);
            castleSlimes.Add(4);
            castleSlimes.Add(7);
            castleSlimes.Add(10);
            castleSlimes.Add(11);
            castleSlimes.Add(15);
            castleSlimes.Add(16);
            castleSlimes.Add(17);
            castleSlimes.Add(19);
            castleSlimes.Add(25);
            castleSlimes.Add(25);
            castleSlimes.Add(29);
            castleSlimes.Add(29);

            rareCastleSlimes.Add(18);
            rareCastleSlimes.Add(12);
            rareCastleSlimes.Add(30);
            rareCastleSlimes.Add(32);
            rareCastleSlimes.Add(33);
            rareCastleSlimes.Add(34);
            rareCastleSlimes.Add(34);
        }




    }


    public Slime generateSlime(string stage){

        Slime s;

        bool rareSpawn = false;
        if(UnityEngine.Random.Range(0,1.0f)>0.92f){
            rareSpawn=true;
        }
        switch(stage){

            case "Forest":
                if(!rareSpawn){
                    s= new Slime(forestSlimes[UnityEngine.Random.Range(0,forestSlimes.Count)],UnityEngine.Random.Range(oLvl/4,3*oLvl/4));
                } else{
                     s= new Slime(rareForestSlimes[UnityEngine.Random.Range(0,rareForestSlimes.Count)],UnityEngine.Random.Range(oLvl/2,3*oLvl/4));
                }

                break;
                

            case "Fall":

                if(!rareSpawn){
                    s= new Slime(fallSlimes[UnityEngine.Random.Range(0,fallSlimes.Count)],UnityEngine.Random.Range(oLvl/4,3*oLvl/4));
                } else{
                     s= new Slime(rareFallSlimes[UnityEngine.Random.Range(0,rareFallSlimes.Count)],UnityEngine.Random.Range(oLvl/2,3*oLvl/4));
                }

                break;
                

            case "Winter":

                if(!rareSpawn){
                    s= new Slime(winterSlimes[UnityEngine.Random.Range(0,winterSlimes.Count)],UnityEngine.Random.Range(oLvl/4,3*oLvl/4));
                } else{
                     s= new Slime(rareWinterSlimes[UnityEngine.Random.Range(0,rareWinterSlimes.Count)],UnityEngine.Random.Range(oLvl/2,3*oLvl/4));
                }

                break;
                
            case "Island":
                if(!rareSpawn){
                    s= new Slime(islandSlimes[UnityEngine.Random.Range(0,islandSlimes.Count)],UnityEngine.Random.Range(oLvl/4,3*oLvl/4));
                } else{
                     s= new Slime(rareIslandSlimes[UnityEngine.Random.Range(0,rareIslandSlimes.Count)],UnityEngine.Random.Range(oLvl/2,3*oLvl/4));
                }
               
                break;

            case "City":
                if(!rareSpawn){
                    s= new Slime(citySlimes[UnityEngine.Random.Range(0,citySlimes.Count)],UnityEngine.Random.Range(oLvl/4,3*oLvl/4));
                } else{
                     s= new Slime(rareCitySlimes[UnityEngine.Random.Range(0,rareCitySlimes.Count)],UnityEngine.Random.Range(oLvl/2,3*oLvl/4));
                }
                
                break;
            case "Castle":
                if(!rareSpawn){
                    s= new Slime(castleSlimes[UnityEngine.Random.Range(0,castleSlimes.Count)],UnityEngine.Random.Range(oLvl/4,3*oLvl/4));
                } else{
                     s= new Slime(rareCastleSlimes[UnityEngine.Random.Range(0,rareCastleSlimes.Count)],UnityEngine.Random.Range(oLvl/2,3*oLvl/4));
                }
                
                break;

            default:
                s = new Slime(rareFallSlimes[UnityEngine.Random.Range(0,rareFallSlimes.Count)],UnityEngine.Random.Range(oLvl/2,3*oLvl/4));
                break;


        }

        
        return s;
    }

    void setTeleporter(GameObject teleporter){
            stageTeleporter = teleporter;
    }
   
    public void startBattle(Player player, BattleManager battleManager,SlimeSpawnerHelper spawner,GameObject teleporter){
        setTeleporter(teleporter);
        for (int i=0;i<playerSlimes.Count;i++){
            spawner.spawnSlime(playerSlimes[i].speciesID,i,stage);
            battleManager.healthPointsUI(playerSlimes[i],i);
        }
        for (int i=0;i<enemySlimes.Count;i++){
            spawner.spawnSlime(enemySlimes[i].speciesID,i+2,stage);
            battleManager.healthPointsUI(enemySlimes[i],i+2);
        }

        

        //start battle abilities here
        Debug.Log("Battle Started");
        int attempt=0;
        int j=0;
        int itemKey;
        while(oLvl>0 && player.getInventorySize()>0 && player.team.Count<player.team.Capacity && attempt<=5){ //preperation
            attempt++;
            if(UnityEngine.Random.Range(0f,1f)>0.1){
                //Debug.Log("check");
                j=0;
                
                
                do{
                     itemKey= (int)UnityEngine.Random.Range(0f,31f);
                     j++;
                } while (!player.consumeItem(itemKey) && j<=5);
                
                if(j<=5){
                    if(player.addSlime(new Slime(itemKey))){
                        battleManager.bo.displayNotification(battleManager,1.5f,"A " + new Slime(itemKey).speciesName + " Slime has joined your party");
                        oLvl--;
                    } else{
                        battleManager.bo.displayNotification(battleManager,1.5f, "A "+ new Slime(itemKey).speciesName + " Slime tried joined your party, but did'nt like how crowdy it is");

                    }
                    
                }
                
            }
        }
        startTurn(player, battleManager,spawner);
        
    }
    public void startTurn(Player player, BattleManager battleManager,SlimeSpawnerHelper spawner){
        Debug.Log("Turn Started");

        //both sides select move then start action
        selectMoves(player, battleManager,spawner);
        
        

    }

    public void endBattle(Player player,BattleManager battleManager){
        if(playerSlimes.Count<=0){
        battleManager.bo.displayNotification(battleManager,1.5f,"You Lost :(");

            Debug.Log("You lost :(");
            stageTeleporter.gameObject.SetActive(true);
        } else{
            battleManager.bo.displayNotification(battleManager,1.5f,"You Won :D");
            Debug.Log("You Won :D");
            stageTeleporter.gameObject.SetActive(true);
            player.receiveCurrency((int) UnityEngine.Random.Range(0,oLvl));
            player.resetTeam();
        }
            
        
    }

    public int consumeOoze(){
        if(oLvl<=0){
             Debug.Log("You don't have enough Ooze :(");
            return 0;
        }
        oLvl-=1;
        return 1;
    }

    public bool isBattleOver(){
        if(playerSlimes.Count<=0 || enemySlimes.Count<=0){ //two different cases
            //Debug.Log("Battle Over");
            return true;
        }

        return false;
    }

    public void selectMoves(Player player, BattleManager battleManager,SlimeSpawnerHelper spawner){
        //Debug.Log("Move Selection Started");

            
        //Debug.Log("ps1");
        battleManager.moveSelectUI(playerSlimes[0],spawner);
        
        //UI
        //select moves and targets and enqueue them into the pq
        //set target if needed
        
    }

    public void selectAMove(Player player,Move selectedMove,Slime selectedTarget, BattleManager battleManager,SlimeSpawnerHelper spawner){
        //close UI


        battleManager.closeMoveSelectUI();

        //Debug.Log("Selected:"+selectedMove.moveName+" by your "+selectedMove.owner.speciesName+" Slime. Target: Enemy "+ selectedTarget.speciesName + " Slime");



        if(Move.singleTargetMovesNegative.Contains(selectedMove.moveType)){ //if it is a single target move, the player must select a target through the UI
            battleManager.selectMoveTargetUI(playerSlimes,enemySlimes,selectedMove,spawner);
            return;
        }
        //copy from here
        battleQueue.Enqueue(selectedMove,selectedMove.owner.currentSpeed);
        


        if(battleQueue.Count<playerSlimes.Count){
            if(playerSlimes.Count==2){
                //Debug.Log("ps2");
                battleManager.moveSelectUI(playerSlimes[1],spawner);
            }
        }

        if(battleQueue.Count==playerSlimes.Count){
            //Debug.Log("Enough moves selected");
            aISelectMoves();
            useMoves(player, battleManager,spawner);
        }
    }

    public void selectMoveTarget(Player player,Move selectedMove,Slime selectedTarget,BattleManager battleManager,SlimeSpawnerHelper spawner){
        
        //Debug.Log("Select:"+selectedMove.moveName+" by |"+selectedMove.owner.speciesName+" Target: "+ selectedTarget.speciesName);

        battleManager.closeSelectMoveTargetUI();

        selectedMove.setMoveTarget(selectedTarget);

        battleQueue.Enqueue(selectedMove,selectedMove.owner.currentSpeed);
        


        if(battleQueue.Count<playerSlimes.Count){
            if(playerSlimes.Count==2){
                //Debug.Log("ps2");
                battleManager.moveSelectUI(playerSlimes[1],spawner);
            }
        }

        if(battleQueue.Count==playerSlimes.Count){
            //Debug.Log("Enough moves selected");
            aISelectMoves();
            useMoves(player, battleManager,spawner);
        }



    }


    public void aISelectMoves(){
        //AI selects moves and enqueues them into the pq
        foreach (Slime s in enemySlimes){
            Move m = s.moves[(int)UnityEngine.Random.Range(0,s.moves.Length)]; //choose move randomly
            if(Move.singleTargetMovesNegative.Contains(m.moveType)){
                m.setMoveTarget(playerSlimes[(int)UnityEngine.Random.Range(0,playerSlimes.Count)]); 
            } else if(Move.singleTargetMovesPositive.Contains(m.moveType)){
                m.setMoveTarget(enemySlimes[(int)UnityEngine.Random.Range(0,enemySlimes.Count)]); 
            }
            //Debug.Log("Enemy " + s.speciesName + " Slime Selected " + m.moveName + "Targeting: Your "+m.target.speciesName + " Slime");
            battleQueue.Enqueue(m,s.currentSpeed);
            
        }
        
    }

   /*public void useMoves(Player player,BattleManager battleManager,SlimeSpawnerHelper spawner){ //careful with the order
        Move m;
        while(battleQueue.Count>0){
            m=(Move)battleQueue.Dequeue(); 
            

            if(!playerSlimes.Contains(m.owner) && !enemySlimes.Contains(m.owner)){
                Debug.Log("Move "+m.moveName + "Failed, Owner Defeated");
                continue;
            }

            if(!playerSlimes.Contains(m.target) && !enemySlimes.Contains(m.target) && (m.moveType.Equals("Attack") || m.moveType.Equals("Double Attack") || m.moveType.Equals("Heal")|| m.moveType.Equals("Stat Change"))){ //replace with singletarget moves . contains
                Debug.Log("Move "+m.moveName + "Failed, Target not found");
                continue;
            }

            //Debug.Log(m.owner.speciesName + "Slime Used Move: "+m.moveName + " Target: " + m.target.speciesName + " Slime");

            m.checkAccuracy(playerSlimes,enemySlimes); //auto uses move if succesful, returns false if missed

            
            for(int i=0; i<playerSlimes.Count; i++){
                if(slimeDefeated(playerSlimes[i])){
                    if (playerSlimes.Contains(playerSlimes[i])){
                        
                        player.removeSlime(player.team[player.team.IndexOf(playerSlimes[i])]);
                        playerSlimes.Remove(playerSlimes[i]);
                        spawner.destroySlime(i);



                    }
                }
            }

            for(int i=0; i<enemySlimes.Count; i++){
                Debug.Log(i);
                if(slimeDefeated(enemySlimes[i])){
                    if (enemySlimes.Contains(enemySlimes[i])){

                        

                        enemySlimes.Remove(enemySlimes[i]);
                        spawner.destroySlime(i+2);
                }
                }
            }
        
        }


        // check if the battle has ended
            if(!isBattleOver()){
                //Debug.Log("Turn Over");
                //End Turn abilities here

                if(battleManager.wait())
                
                startTurn(player,battleManager,spawner);
            }else{
                for (int i=0; i<4; i++){
                    spawner.destroySlime(i); 
                }
                
                endBattle(player);
            }
            
    }*/

    public void useMoves(Player player,BattleManager battleManager,SlimeSpawnerHelper spawner){
        battleOrder.useMoves(player,battleManager,spawner,this);
    }
    



    public bool slimeDefeated(Slime checkedSlime){
        if (checkedSlime.currentHP<=0){
            Debug.Log(checkedSlime.speciesName + " Slime has been defeated");
            return true;
        }
        return false;
    }


}
