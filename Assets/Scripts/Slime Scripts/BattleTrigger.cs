using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public string stage;
    public GameObject teleporter;
    public BattleManager battleManager;
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
            battleManager.startEncouter(stage,teleporter);
        }
        //teleporter.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

            
    }
}
