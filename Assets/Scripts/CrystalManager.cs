using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    [SerializeField] private int requiredCrystalCount;
    [SerializeField] private Portal portal;

    private int collectedCrystalCount;

    private void Start()
    {
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

        Debug.Log("Crystals: 0/" + requiredCrystalCount);
    }

    public void CollectCrystal(Crystal crystal)
    {
        collectedCrystalCount++;

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

    private void OpenPortal()
    {
        Debug.Log("Portal opened!");

        if (portal != null)
        {
            portal.SetOpen(true);
        }
    }
}
