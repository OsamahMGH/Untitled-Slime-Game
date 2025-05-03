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
                        if(battleManager.player.addSlime(new Slime(UnityEngine.Random.Range(0,35)))){
                            battleManager.bo.displayNotification(battleManager,1f,"A Travilng Slime decided to journey with you.");
                        } else{
                            battleManager.bo.displayNotification(battleManager,1f,"Nobody's here...");

                        }
                        break;
                    case "Winter":
                            battleManager.player.increaseMaxOoze(1);
                            battleManager.bo.displayNotification(battleManager,2f,"Your Slimes enjoyed playing in the snow! They even found some extar Ooze.");
                            break;
                    case "Forest":
                            if(battleManager.player.increaseMaxOoze(1)){
                                battleManager.bo.displayNotification(battleManager,2f,"You found some extra Oooze in the Forest, you can power up your slimes even more now!");
                            } else {
                              battleManager.bo.displayNotification(battleManager,2f,"You found some extra Oooze in the Forest, but you already have a lot."); 
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
                     case "Island":
                            if(UnityEngine.Random.Range(0f,1f)>0.6){
                                battleManager.player.receiveCurrency(15);
                                battleManager.bo.displayNotification(battleManager,1f,"You found a treasure!");
                            } else {
                              battleManager.bo.displayNotification(battleManager,1.5f,"Someone beat you to it..."); 
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
