using UnityEngine;
using UnityEngine.SceneManagement;

// Shows the completion panel, pauses gameplay, and handles navigation.
public class LevelCompleteUI : MonoBehaviour
{
    [SerializeField] private GameObject completePanel;
    [SerializeField] private string nextLevelSceneName;
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    private bool isShowing;
    private float previousTimeScale;
    private Behaviour[] playerControls;
    private bool[] controlsWereEnabled;

    private void Start()
    {
        if (IsPanelValid())
        {
            completePanel.SetActive(false);
        }
    }

    public bool Show(GameObject player)
    {
        if (isShowing)
            return true;

        if (!IsPanelValid())
        {
            Debug.LogWarning("Assign a Level Complete Panel that does not contain the LevelCompleteUI object.", this);
            return false;
        }

        PausePlayerControls(player);
        completePanel.SetActive(true);
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        isShowing = true;
        return true;
    }

    public void NextLevel()
    {
        LoadScene(nextLevelSceneName);
    }

    public void OutToMainMenu()
    {
        LoadScene(mainMenuSceneName);
    }

    private void LoadScene(string sceneName)
    {
        if (string.IsNullOrWhiteSpace(sceneName) || !Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogWarning("Cannot load scene '" + sceneName + "'. Check its name and add it to the build scene list.", this);
            return;
        }

        ResumeGame();
        SceneManager.LoadScene(sceneName);
    }

    // The manager must stay outside the panel so hiding it does not disable the manager.
    private bool IsPanelValid()
    {
        return completePanel != null && !transform.IsChildOf(completePanel.transform);
    }

    private void PausePlayerControls(GameObject player)
    {
        if (player == null)
            return;

        playerControls = new Behaviour[]
        {
            player.GetComponent<PlayerMovement>(),
            player.GetComponent<PlayerState>(),
            player.GetComponent<PolaritySplit>(),
            player.GetComponent<LumisLightShooter>()
        };
        // Restore each control to its previous state when gameplay resumes.
        controlsWereEnabled = new bool[playerControls.Length];

        for (int i = 0; i < playerControls.Length; i++)
        {
            if (playerControls[i] == null)
                continue;

            controlsWereEnabled[i] = playerControls[i].enabled;
            playerControls[i].enabled = false;
        }
    }

    private void ResumeGame()
    {
        if (!isShowing)
            return;

        Time.timeScale = previousTimeScale;
        if (playerControls != null)
        {
            for (int i = 0; i < playerControls.Length; i++)
            {
                if (playerControls[i] != null)
                {
                    playerControls[i].enabled = controlsWereEnabled[i];
                }
            }
        }

        isShowing = false;
    }

    private void OnDestroy()
    {
        ResumeGame();
    }
}
