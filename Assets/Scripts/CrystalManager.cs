using TMPro;
using UnityEngine;

// Tracks collected crystals, updates the counter, and opens the portal.
public class CrystalManager : MonoBehaviour
{
    [SerializeField] private int requiredCrystalCount;
    [SerializeField] private Portal portal;
    [SerializeField] private TMP_Text crystalCounterText;

    private int collectedCrystalCount;

    private void Start()
    {
        // A non-positive requirement uses the number of active crystals in the scene.
        if (requiredCrystalCount <= 0)
        {
            requiredCrystalCount = FindObjectsByType<Crystal>().Length;
        }

        if (portal == null)
        {
            portal = FindAnyObjectByType<Portal>();
        }

        if (portal != null)
        {
            portal.SetOpen(requiredCrystalCount == 0);
        }

        UpdateCrystalText();
        Debug.Log("Crystals: 0/" + requiredCrystalCount);
    }

    public void CollectCrystal(Crystal crystal)
    {
        collectedCrystalCount++;
        UpdateCrystalText();

        if (crystal != null)
        {
            crystal.gameObject.SetActive(false);
        }

        Debug.Log("Crystals: " + collectedCrystalCount + "/" + requiredCrystalCount);

        if (collectedCrystalCount >= requiredCrystalCount)
        {
            OpenPortal();
        }
    }

    private void UpdateCrystalText()
    {
        if (crystalCounterText != null)
        {
            crystalCounterText.text = "Crystal: " + collectedCrystalCount + "/" + requiredCrystalCount;
        }
    }

    private void OpenPortal()
    {
        Debug.Log("Portal opened!");

        if (portal != null)
        {
            portal.SetOpen(true);
        }
    }
}
