using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    public static UserInterface Instance;

    public GameObject scores;
    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject restartButton;
    public GameObject restartButtonBig;

    private void Start()
    {
        Instance = this;

        playButton.SetActive(true);

        scores.SetActive(false);
        pauseButton.SetActive(false);
        resumeButton.SetActive(false);
        restartButton.SetActive(false);
    }

    public void PlayButtonClicked()
    {
        Gameplay.Instance.StartGame();

        scores.SetActive(true);
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        restartButton.SetActive(false);
    }

    public void ResumeButtonClicked()
    {
        Gameplay.Instance.ResumeGame();

        scores.SetActive(true);
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        restartButton.SetActive(false);
    }

    public void PauseButtonClicked()
    {
        Gameplay.Instance.PauseGame();

        scores.SetActive(false);
        playButton.SetActive(false);
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        restartButton.SetActive(true);
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
