// TeleportManager.cs
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;  // for the UI Text

public class TeleportManager : MonoBehaviour
{
    [Header("Player Reference")]
    [Tooltip("Drag your Player GameObject (its root Transform) here")]
    public Transform player;

    [Header("Area Spawn Points (0=Winter, 1=Island, 2=Forest, 3=Forest2, 4=City)")]
    [Tooltip("Drag your 5 spawn-point Transforms here")]
    public Transform[] spawnPoints;

    [Header("UI")]
    [Tooltip("Drag the UI Text component that shows the score")]
    public TextMeshProUGUI scoreText;

    private List<int> unvisitedAreas;
    private int score = 0;

    void Start()
    {
        // initialize the full set of areas
        ResetAreaList();
        UpdateScoreUI();
    }

    /// <summary>
    /// Call this from any fire/finish trigger.
    /// </summary>
    public void TeleportToNextArea()
    {
        // if you've visited all 5, refill the list so it can go again
        if (unvisitedAreas.Count == 0)
            ResetAreaList();

        // pick & remove a random index
        int listIdx  = Random.Range(0, unvisitedAreas.Count);
        int nextArea = unvisitedAreas[listIdx];
        unvisitedAreas.RemoveAt(listIdx);

        // teleport the player
        Transform sp = spawnPoints[nextArea];
        player.position = sp.position;
        player.rotation = sp.rotation;

        // bump the score and update UI
        score++;
        UpdateScoreUI();
    }

    // refill the “to-visit” list with 0…spawnPoints.Length-1
    private void ResetAreaList()
    {
        unvisitedAreas = new List<int>(spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
            unvisitedAreas.Add(i);
    }

    // show “Score: X” (or just the number) in your UI
    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }
}
