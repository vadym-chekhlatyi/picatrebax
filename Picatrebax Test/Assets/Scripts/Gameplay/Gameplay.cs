using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public static Gameplay Instance;

    [SerializeField] private GameObject PlayerController;
    [SerializeField] private GameObject MapController;
    
    [HideInInspector] public bool gameActive;

    private void Start()
    {
        Instance = this;
    }

    public void StartGame()
    {
        Instantiate(PlayerController, transform);
        Instantiate(MapController, transform);

        gameActive = true;
    }

    public void ResumeGame()
    {
        gameActive = true;
    }

    public void PauseGame()
    {
        gameActive = false;
    }

    public void Lose()
    {
        gameActive = false;

        UserInterface.Instance.restartButtonBig.SetActive(true);

        UserInterface.Instance.restartButton.SetActive(false);
        UserInterface.Instance.resumeButton.SetActive(false);
        UserInterface.Instance.pauseButton.SetActive(false);
        UserInterface.Instance.playButton.SetActive(false);
    }
}
