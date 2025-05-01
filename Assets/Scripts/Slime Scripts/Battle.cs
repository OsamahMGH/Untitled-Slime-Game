using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;


class Battle{
    
    int turnNumber=1;

    bool isBossBattle;
    string stage; 

    public List<Slime> playerSlimes = new List<Slime>();
    public List<Slime> enemySlimes = new List<Slime>();
    public PriorityQueue<Move,int> battleQueue = new PriorityQueue<Move, int>();
    
    public int oLvl=0;
    


    public  Battle(Player player,Slime allySlime1, Slime allySlime2, Slime enemySlime1, Slime enemySlime2){

        playerSlimes.Add(allySlime1);
        playerSlimes.Add(allySlime2);
        enemySlimes.Add(enemySlime1);
        enemySlimes.Add(enemySlime2);


    }

    public  Battle(Player player,Slime slime1, Slime slime2, Slime slime3){

        playerSlimes.Add(slime1);
        playerSlimes.Add(slime2);
        enemySlimes.Add(slime3);



    }
    public  Battle(Player player,Slime slime1, Slime slime2){

        playerSlimes.Add(slime1);
        enemySlimes.Add(slime2);
    }

   
    public void startBattle(Player player, BattleManager battleManager,SlimeSpawnerHelper spawner){
        oLvl = player.maxOozeLevel;
        for (int i=0;i<playerSlimes.Count;i++){
            spawner.spawnSlime(playerSlimes[i].speciesID,i,stage);
        }
        for (int i=0;i<enemySlimes.Count;i++){
            spawner.spawnSlime(enemySlimes[i].speciesID,i+2,stage);
        }

        //start battle abilities here
        Debug.Log("Battle Started");
        //while(oLvl>0 && player.inventory.Count>0 && player.team.Count<player.team.Capacity){ //preperation
            //(UI)consume item and one Ooze to create a slime 

            //(UI)can continue before hitting limit
        //}
        startTurn(player, battleManager);
        
    }
    public void startTurn(Player player, BattleManager battleManager){
        Debug.Log("Turn Started");

        //both sides select move then start action
        selectMoves(player, battleManager);
        
        

    }

    public void endBattle(Player player){
        if(playerSlimes.Count<=0){
            Debug.Log("You lost :(");
        } else{
            Debug.Log("You Won :D");
            player.receiveCurrency((int) Random.Range(0,oLvl));
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
            Debug.Log("Battle Over");
            return true;
        }

        return false;
    }

    public void selectMoves(Player player, BattleManager battleManager){
        //Debug.Log("Move Selection Started");

            
        //Debug.Log("ps1");
        battleManager.moveSelectUI(playerSlimes[0]);
        
        //UI
        //select moves and targets and enqueue them into the pq
        //set target if needed
        
    }

    public void selectAMove(Player player,Move selectedMove,Slime selectedTarget, BattleManager battleManager){
        //close UI


        battleManager.closeMoveSelectUI();

        //Debug.Log("Selected:"+selectedMove.moveName+" by your "+selectedMove.owner.speciesName+" Slime. Target: Enemy "+ selectedTarget.speciesName + " Slime");



        if(Move.singleTargetMoves.Contains(selectedMove.moveType)){ //if it is a single target move, the player must select a target through the UI
            battleManager.selectMoveTargetUI(playerSlimes,enemySlimes,selectedMove);
            return;
        }
        //copy from here
        battleQueue.Enqueue(selectedMove,selectedMove.owner.currentSpeed);
        


        if(battleQueue.Count<playerSlimes.Count){
            if(playerSlimes.Count==2){
                //Debug.Log("ps2");
                battleManager.moveSelectUI(playerSlimes[1]);
            }
        }

        if(battleQueue.Count==playerSlimes.Count){
            //Debug.Log("Enough moves selected");
            aISelectMoves();
            useMoves(player, battleManager);
        }
    }

    public void selectMoveTarget(Player player,Move selectedMove,Slime selectedTarget,BattleManager battleManager){
        
        //Debug.Log("Select:"+selectedMove.moveName+" by |"+selectedMove.owner.speciesName+" Target: "+ selectedTarget.speciesName);

        battleManager.closeSelectMoveTargetUI();

        selectedMove.setMoveTarget(selectedTarget);

        battleQueue.Enqueue(selectedMove,selectedMove.owner.currentSpeed);
        


        if(battleQueue.Count<playerSlimes.Count){
            if(playerSlimes.Count==2){
                //Debug.Log("ps2");
                battleManager.moveSelectUI(playerSlimes[1]);
            }
        }

        if(battleQueue.Count==playerSlimes.Count){
            //Debug.Log("Enough moves selected");
            aISelectMoves();
            useMoves(player, battleManager);
        }



    }


    public void aISelectMoves(){
        //AI selects moves and enqueues them into the pq
        foreach (Slime s in enemySlimes){
            Move m = s.moves[(int)Random.Range(0,s.moves.Length)]; //choose move randomly
            m.setMoveTarget(playerSlimes[0]); // replace with actual logic for target selection
            //Debug.Log("Enemy " + s.speciesName + " Slime Selected " + m.moveName + "Targeting: Your "+m.target.speciesName + " Slime");
            battleQueue.Enqueue(m,s.currentSpeed);
            
        }
        
    }

    public void useMoves(Player player,BattleManager battleManager){ //careful with the order
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
                    }
                }
            }

            for(int i=0; i<enemySlimes.Count; i++){
                if(slimeDefeated(enemySlimes[i])){
                    if (enemySlimes.Contains(enemySlimes[i])){

                        if(Random.Range(0,1)>0.5f){  //drop item
                            player.reciveItem(enemySlimes[i].speciesID);
                        }

                        enemySlimes.Remove(enemySlimes[i]);
                }
                }
            }
        
        }


        // check if the battle has ended
            if(!isBattleOver()){
                //Debug.Log("Turn Over");
                //End Turn abilities here
                startTurn(player,battleManager);
            }else{
                endBattle(player);
            }
            
    }


    public bool slimeDefeated(Slime checkedSlime){
        if (checkedSlime.currentHP<=0){
            Debug.Log(checkedSlime.speciesName + " Slime has been defeated");
            return true;
        }
        return false;
    }


}
