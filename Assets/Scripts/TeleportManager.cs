// TeleportManager.cs
using UnityEngine;
using System.Collections.Generic;

public class TeleportManager : MonoBehaviour
{
    [Header("Player Reference")]
    [Tooltip("Drag your Player GameObject (its root Transform) here")]
    public Transform player;

    [Header("Area Spawn Points (0=Winter, 1=Island, 2=Forest, 3=Forest2, 4=City)")]
    [Tooltip("Drag your 5 spawn-point Transforms here")]
    public Transform[] spawnPoints;

    // tracks which areas have yet to be visited
    private List<int> unvisitedAreas;

    void Start()
    {
        // start with all indices (0…spawnPoints.Length-1) unvisited
        unvisitedAreas = new List<int>();
        for (int i = 0; i < spawnPoints.Length; i++)
            unvisitedAreas.Add(i);
    }

    /// <summary>
    /// Call this from any fire/finish trigger—first time it will pick randomly
    /// from all five areas, then remove that one from future picks, etc.
    /// </summary>
    public void TeleportToNextArea()
    {
        if (unvisitedAreas.Count == 0)
        {
            Debug.Log("All areas complete!");
            return;
        }

        // pick a random unvisited area
        int listIdx  = Random.Range(0, unvisitedAreas.Count);
        int nextArea = unvisitedAreas[listIdx];
        Transform sp = spawnPoints[nextArea];

        // snap the player
        player.position = sp.position;
        player.rotation = sp.rotation;

        // mark that area as done
        unvisitedAreas.RemoveAt(listIdx);
    }
}
