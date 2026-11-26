using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private CrystalManager crystalManager;

    private bool isCollected;

    private void Awake()
    {
        if (crystalManager == null)
        {
            crystalManager = FindAnyObjectByType<CrystalManager>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected || !other.CompareTag("Player"))
            return;

        if (crystalManager == null)
        {
            crystalManager = FindAnyObjectByType<CrystalManager>();
        }

        if (crystalManager == null)
        {
            Debug.LogWarning("Crystal cannot be collected without a CrystalManager.", this);
            return;
        }

        isCollected = true;
        crystalManager.CollectCrystal(this);
    }
}
