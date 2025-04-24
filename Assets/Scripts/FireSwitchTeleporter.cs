using UnityEngine;

public class FireSwitchTeleporter : MonoBehaviour
{
    [Tooltip("How far (in world units) to teleport the player relative to their current position")]
    public Vector3 teleportOffset = new Vector3(0f, 15f, 0f);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Transform playerTf = collision.collider.transform;
            playerTf.position += teleportOffset;
        }
    }
}
