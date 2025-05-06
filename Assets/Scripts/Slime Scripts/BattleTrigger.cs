using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public string stage;
    public GameObject teleporter;
    public BattleManager battleManager;
    public bool isEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player")){
            if(!isEvent){
            battleManager.startEncouter(stage,teleporter);
            } else {
                switch(stage){
                    case "Fall":
                        if(UnityEngine.Random.Range(0f,1f)>0.6){
                            battleManager.player.reciveItem(UnityEngine.Random.Range(1,9));
                            battleManager.bo.displayNotification(battleManager,1f,"You found something within a pile of leaves.");
                        } else{
                            battleManager.bo.displayNotification(battleManager,1f,"nothing's here...");

                        }
                        break;

                    case "Fall2":
                        if(battleManager.player.addSlime(new Slime(UnityEngine.Random.Range(0,35)))){
                            battleManager.bo.displayNotification(battleManager,1f,"A Travilng Slime decided to journey with you.");
                        } else{
                            battleManager.bo.displayNotification(battleManager,1f,"Nobody's here...");

                        }
                        break;
                    case "Winter":
                            if(battleManager.player.increaseMaxOoze(1)){
                               battleManager.bo.displayNotification(battleManager,2f,"Your Slimes enjoyed playing in the snow! They even found some extar Ooze.");
                            }else{
                                battleManager.bo.displayNotification(battleManager,2f,"Your Slimes enjoyed playing in the snow!");
                            }

                            
                            break;
                    case "Winter2":
                            if(UnityEngine.Random.Range(0f,1f)>0.7){
                                battleManager.player.increaseTeamCap(1);
                                battleManager.bo.displayNotification(battleManager,3f,"The Winter Spirit inspired your Slimes to be more charitable and welcoming!");
                            } else {
                              battleManager.bo.displayNotification(battleManager,1.5f,"You hear one of your Slimes sneeze, bless them."); 
                            }
                            break;
                    case "Forest":
                            if(battleManager.player.increaseMaxOoze(1)){
                                battleManager.bo.displayNotification(battleManager,2f,"You found some extra Oooze in the Forest, you can power up your slimes even more now!");
                            } else {
                              battleManager.bo.displayNotification(battleManager,2f,"You found some extra Oooze in the Forest, but you already have a lot."); 
                            }
                            break;
                    case "Forest2":
                            if(UnityEngine.Random.Range(0f,1f)>0.3){
                                battleManager.player.receiveCurrency(15);
                                battleManager.bo.displayNotification(battleManager,2f,"You found some money! Maybe if you have enough, you can buy something in the city.");
                            } else {
                              battleManager.bo.displayNotification(battleManager,2f,"You hear the sound of a Bear Slime from a distance, maybe you should leave."); 
                            }
                        break;
                    case "City":
                            if(battleManager.player.team.Count>1){
                                if(battleManager.player.currency>=50){
                                    battleManager.player.payCurrency(50);
                                    battleManager.player.addSlime(new Slime(UnityEngine.Random.Range(28,35)));
                                    battleManager.bo.displayNotification(battleManager,2f,"A Shady figure sold you a supposdly rare Slime.");

                                }
                                battleManager.player.removeSlime(battleManager.player.team[UnityEngine.Random.Range(0,battleManager.player.team.Count)]);
                                battleManager.bo.displayNotification(battleManager,2f,"Your Slimes were not careful crossing the street... RIP");
                            } else {
                              battleManager.bo.displayNotification(battleManager,1.5f,"You Should be careful crossing the street"); 
                            }
                            break;
                    case "City2":
                            if(battleManager.player.team.Count>1){
                                if(battleManager.player.currency>=20){
                                    battleManager.player.payCurrency(20);
                                    battleManager.player.addSlime(new Slime(UnityEngine.Random.Range(14,28)));
                                    battleManager.bo.displayNotification(battleManager,2f,"A Shady figure sold you a Slime. Although it doesn't seem like you had a choice.");

                                }
                                battleManager.player.removeSlime(battleManager.player.team[UnityEngine.Random.Range(0,battleManager.player.team.Count)]);
                                battleManager.bo.displayNotification(battleManager,2f,"One of your Slimes made a run for it");
                            } else {
                              battleManager.bo.displayNotification(battleManager,1.5f,"You hear.. a clown laughing somewhere? Best be careful around here."); 
                            }
                            break;
                     case "Island":
                            if(UnityEngine.Random.Range(0f,1f)>0.6){
                                battleManager.player.receiveCurrency(15);
                                battleManager.bo.displayNotification(battleManager,1f,"You found a treasure!");
                            } else {
                              battleManager.bo.displayNotification(battleManager,1.5f,"Someone beat you to it..."); 
                            }
                            break;
                    case "Island2":
                            if(UnityEngine.Random.Range(0f,1f)>0.7){
                                battleManager.player.reciveItem(UnityEngine.Random.Range(20,28));
                                battleManager.bo.displayNotification(battleManager,1f,"You found something in the cave, it must have drifted all the way here.");
                            } else {
                              battleManager.bo.displayNotification(battleManager,1.5f,"The cave is empty..."); 
                            }
                            break;
                    case "Castle":
                            if(UnityEngine.Random.Range(0f,1f)>0.5){
                                battleManager.player.increaseTeamCap(1);
                                battleManager.bo.displayNotification(battleManager,3f,"The clausterphobic environment taught your Slime to be less rowdy, you can welcome more Slimes now!");
                            } else {
                              battleManager.bo.displayNotification(battleManager,1.5f,"Your Slimes are not fans of this environment."); 
                            }
                            break;
                }
            }
        }
        //teleporter.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

            
    }
}
