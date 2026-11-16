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
    private bool canSwitchState = true;

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
        if (canSwitchState && Input.GetKeyDown(KeyCode.Q))
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
        canSwitchState = !isLocked;
    }

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
