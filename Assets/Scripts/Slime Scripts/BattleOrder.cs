using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class BattleOrder: MonoBehaviour
{

    public void useMoves(Player player,BattleManager battleManager,SlimeSpawnerHelper spawner,Battle currentBattle){
        StartCoroutine(useMovesH(player,battleManager,spawner,currentBattle));
    }

    IEnumerator useMovesH(Player player,BattleManager battleManager,SlimeSpawnerHelper spawner,Battle currentBattle){ //careful with the order
            Move m;
            while(currentBattle.battleQueue.Count>0){
                
                m=(Move)currentBattle.battleQueue.Dequeue(); 
                

                if(!currentBattle.playerSlimes.Contains(m.owner) && !currentBattle.enemySlimes.Contains(m.owner)){
                    Debug.Log("Move "+m.moveName + "Failed, Owner Defeated");
                    battleManager.textWindowUI("Move "+m.moveName + "failed, User has been defeated");
                    continue;
                }

                if(!currentBattle.playerSlimes.Contains(m.target) && !currentBattle.enemySlimes.Contains(m.target) && (m.moveType.Equals("Attack") || m.moveType.Equals("Double Attack") || m.moveType.Equals("Heal")|| m.moveType.Equals("Stat Change"))){ //replace with singletarget moves . contains
                    Debug.Log("Move "+m.moveName + "Failed, Target not found");
                    battleManager.textWindowUI("Move "+m.moveName + "failed, target has been defeated");
                    continue;
                }

                //Debug.Log(m.owner.speciesName + "Slime Used Move: "+m.moveName + " Target: " + m.target.speciesName + " Slime");

                if(m.checkAccuracy(currentBattle.playerSlimes,currentBattle.enemySlimes)){
                    battleManager.textWindowUI(m.owner.speciesName + " Slime used " + m.moveName);
                    yield return new WaitForSeconds(2);
                    battleManager.closeTextWinowUI();

                    if(currentBattle.playerSlimes.Contains(m.owner)){
                    m.useMove(currentBattle.playerSlimes,currentBattle.enemySlimes,battleManager);
                    } else {
                        m.useMove(currentBattle.enemySlimes,currentBattle.playerSlimes,battleManager);
                    }
                    
                } else {
                    battleManager.textWindowUI(m.owner.speciesName+ "Slime tried to use " + m.moveName + " but it missed");
                } //auto uses move if succesful, returns false if missed

                
                for(int i=0; i<currentBattle.playerSlimes.Count; i++){
                    if(currentBattle.slimeDefeated(currentBattle.playerSlimes[i])){
                        if (currentBattle.playerSlimes.Contains(currentBattle.playerSlimes[i])){
                            
                            player.removeSlime(player.team[player.team.IndexOf(currentBattle.playerSlimes[i])]);
                            currentBattle.playerSlimes.Remove(currentBattle.playerSlimes[i]);
                            spawner.destroySlime(i);



                        }
                    }
                }

                for(int i=0; i<currentBattle.enemySlimes.Count; i++){
                    Debug.Log(i);
                    if(currentBattle.slimeDefeated(currentBattle.enemySlimes[i])){
                        if (currentBattle.enemySlimes.Contains(currentBattle.enemySlimes[i])){

                            if(UnityEngine.Random.Range(0,1)>0.5f){  //drop item
                                player.reciveItem(currentBattle.enemySlimes[i].speciesID);
                            }

                            currentBattle.enemySlimes.Remove(currentBattle.enemySlimes[i]);
                            spawner.destroySlime(i+2);
                            
                    }
                    }
                }

                Debug.Log("Waiting");
                yield return new WaitForSeconds(2);
                battleManager.closeTextWinowUI();
            
            }


            // check if the battle has ended
                if(!currentBattle.isBattleOver()){
                    //Debug.Log("Turn Over");
                    //End Turn abilities here

                    battleManager.closeTextWinowUI();
                    battleManager.closeTextWinowUI();
                   
                    
                    currentBattle.startTurn(player,battleManager,spawner);
                }else{
                    for (int i=0; i<4; i++){
                        spawner.destroySlime(i); 
                    }
                    battleManager.closeTextWinowUI();
                    currentBattle.endBattle(player);
                }
                
        }
}