using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private bool isOpen;
    [SerializeField] private string nextSceneName;
    [SerializeField] private LevelCompleteUI levelCompleteUI;
    [SerializeField] private Color closedColor = new Color(0.35f, 0.35f, 0.35f);
    [SerializeField] private Color openColor = new Color(0.2f, 0.9f, 1f);

    private SpriteRenderer spriteRenderer;
    private bool levelCompleted;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateVisual();
    }

    public void SetOpen(bool open)
    {
        isOpen = open;
        UpdateVisual();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (!isOpen)
        {
            Debug.Log("Portal is locked. Collect all crystals first.");
            return;
        }

        CompleteLevel(other.gameObject);
    }

    private void CompleteLevel(GameObject player)
    {
        if (levelCompleted)
            return;

        levelCompleted = true;
        Debug.Log("Level Complete!");

        if (levelCompleteUI != null && levelCompleteUI.Show(player))
            return;

        if (!string.IsNullOrWhiteSpace(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private void UpdateVisual()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = isOpen ? openColor : closedColor;
        }
    }
}
