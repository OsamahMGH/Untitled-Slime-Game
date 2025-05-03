using UnityEngine;



public class FinishArea : MonoBehaviour
{
    public GameObject stageTrigger;

    [Tooltip("Drag your TeleportManager GameObject here")]
    public TeleportManager teleporter;

    
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
            teleporter.TeleportToNextArea();
            
            stageTrigger.gameObject.SetActive(true);
           //Debug.Log(gameObject.name);
            gameObject.SetActive(false);
            
    }
}
