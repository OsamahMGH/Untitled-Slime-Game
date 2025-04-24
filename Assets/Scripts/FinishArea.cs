using UnityEngine;

public class FinishArea : MonoBehaviour
{
    [Tooltip("Drag your TeleportManager GameObject here")]
    public TeleportManager teleporter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            teleporter.TeleportToNextArea();
    }
}
