using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public static Scores Instance;

    [SerializeField] private TextMeshProUGUI scoresText;
    [Tooltip("Amount of scores added for 1 second")][SerializeField] private int scoresToAdd;

    private float currentScore;

    private void Start()
    {
        Instance = this;
    }

    // Scores depends on game speed (faster = more scores)
    // To disable just delete the "MapController.Instance.speed"
    private void FixedUpdate()
    {
        if (Gameplay.Instance.gameActive)
        {
            currentScore += scoresToAdd * MapController.Instance.speed * Time.deltaTime;
            scoresText.text = "Score: " + Math.Round(currentScore);
        }
    }
}
