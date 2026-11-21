using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum State
    {
        Lumis,
        Umbra
    }

    [Header("Current State")]
    public State currentState = State.Lumis;

    private SpriteRenderer spriteRenderer;
    private bool isSwitchLockedExternally;
    private int zoneSwitchLockCount;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        UpdateVisual();
    }

    private void Update()
    {
        if (CanSwitchState && Input.GetKeyDown(KeyCode.Q))
        {
            SwitchState();
        }
    }

    public void SetState(State newState)
    {
        currentState = newState;
        UpdateVisual();

        Debug.Log("Current State: " + currentState);
    }

    public void SetSwitchLocked(bool isLocked)
    {
        isSwitchLockedExternally = isLocked;
    }

    public void AddZoneSwitchLock()
    {
        zoneSwitchLockCount++;
    }

    public void RemoveZoneSwitchLock()
    {
        zoneSwitchLockCount = Mathf.Max(0, zoneSwitchLockCount - 1);
    }

    private bool CanSwitchState => !isSwitchLockedExternally && zoneSwitchLockCount == 0;

    private void SwitchState()
    {
        if (currentState == State.Lumis)
        {
            SetState(State.Umbra);
        }
        else
        {
            SetState(State.Lumis);
        }
    }

    private void UpdateVisual()
    {
        if (spriteRenderer == null)
            return;

        if (currentState == State.Lumis)
        {
            spriteRenderer.color = new Color(1f, 1f, 0.8f);
        }
        else
        {
            spriteRenderer.color = new Color(0.4f, 0f, 0.6f);
        }
    }
}
