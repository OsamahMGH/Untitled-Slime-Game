using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
class Battle{
    int turnNumber=1;

    bool isBossBattle;

    List<Slime> playerSlimes = new List<Slime>();
    List<Slime> enemySlimes = new List<Slime>();

    


    public  Battle(Player player,Slime allySlime1, Slime allySlime2, Slime enemySlime1, Slime slimeenemySlime2){

        var battleQueue = new PriorityQueue<Move, int>();
        playerSlimes.Add(allySlime1);
        playerSlimes.Add(allySlime2);
        enemySlimes.Add(enemySlime1);
        enemySlimes.Add(slimeenemySlime2);


    }

    public  Battle(Player player,Slime slime1, Slime slime2, Slime slime3){

        var battleQueue = new PriorityQueue<Move, int>();
        playerSlimes.Add(slime1);
        playerSlimes.Add(slime2);
        enemySlimes.Add(slime3);



    }
    public  Battle(Player player,Slime slime1, Slime slime2){

        var battleQueue = new PriorityQueue<Move, int>();
        playerSlimes.Add(slime1);
        enemySlimes.Add(slime2);
    }

   
    public void statBattle(Player player,PriorityQueue<Move, int> bq ){
        int oLvl = player.maxOozeLevel;
        while(oLvl>0 && player.inventory.Count>0 && player.team.Count<player.team.Capacity){ //preperation
            //(UI)consume item and one Ooze to create a slime 

            //(UI)can continue before hitting limit
        }
        while(!isBattleOver()){
            startTurn(player,bq);
        }
        endBattle();
    }
    public void startTurn(Player player,PriorityQueue<Move, int> bq){
        //check start battle abilities here

        //both sides select move then start action
        selectMoves(player,bq);
        aISelectMoves(bq);
        useMoves(player,bq);
        

    }

    public void endBattle(){
        // win or loss?
        //check end battle abilites here
        //give rewards
        
    }

    public bool isBattleOver(){
        if(playerSlimes.Count<=0 || enemySlimes.Count<=0){ //two different cases
            return true;
        }

        return false;
    }

    public void selectMoves(Player player,PriorityQueue<Move, int> bq){
        //UI
        //select moves and targets and enqueue them into the pq
        //set target if needed
        
    }

    public void aISelectMoves(PriorityQueue<Move, int> bq){
        //AI selects moves and enqueues them into the pq
        
    }

    public void useMoves(Player player,PriorityQueue<Move, int> bq){ //careful with the order
        Move m;
        while(bq.Count>0){
            m=(Move)bq.Dequeue(); 

            if(!playerSlimes.Contains(m.owner)){
                continue;
            }

            if(!playerSlimes.Contains(m.target) && !enemySlimes.Contains(m.target) && (m.moveType.Equals("Attack") || m.moveType.Equals("Double Attack") || m.moveType.Equals("Heal")|| m.moveType.Equals("Stat Change"))){
                continue;
            }

            m.checkAccuracy(playerSlimes,enemySlimes); //auto uses move if succesful, returns false if missed

            foreach (Slime s in playerSlimes){
                if(slimeDefeated(s)){
                    player.removeSlime(s);

                    if (playerSlimes.Contains(s)){
                        playerSlimes.Remove(s);

                    }else if(enemySlimes.Contains(s)){
                        enemySlimes.Remove(s);
                    }
                }
            }
        }
        
    }


    public bool slimeDefeated(Slime checkedSlime){
        if (checkedSlime.currentHP<=0){
            return true;
        }
        return false;
    }


}
