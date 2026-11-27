using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string firstLevelSceneName = "Level1";
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject levelsPanel;

    private void Start()
    {
        if (levelsPanel != null)
        {
            levelsPanel.SetActive(false);
        }
    }

    public void PlayGame()
    {
        LoadLevel(firstLevelSceneName);
    }

    public void ShowLevels()
    {
        if (levelsPanel == null)
        {
            Debug.LogWarning("Assign a Levels Panel to the Main Menu component.", this);
            return;
        }

        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false);
        }

        levelsPanel.SetActive(true);
    }

    public void ShowMainMenu()
    {
        if (levelsPanel != null)
        {
            levelsPanel.SetActive(false);
        }

        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }
    }

    public void LoadLevel(string sceneName)
    {
        if (string.IsNullOrWhiteSpace(sceneName) || !Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogWarning("Cannot load scene '" + sceneName + "'. Check its name and add it to the build scene list.", this);
            return;
        }

        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
