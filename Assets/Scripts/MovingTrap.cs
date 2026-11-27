using UnityEngine;

// Moves a trap back and forth between its starting position and an endpoint.
public class MovingTrap : MonoBehaviour
{
    [SerializeField] private Transform endPoint;
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool startMovingTowardEnd = true;

    private Vector3 startPoint;
    private bool isMovingTowardEnd;

    private void Awake()
    {
        startPoint = transform.position;
        isMovingTowardEnd = startMovingTowardEnd;
    }

    private void Update()
    {
        if (endPoint == null)
            return;

        Vector3 targetPosition = isMovingTowardEnd ? endPoint.position : startPoint;
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPosition) <= 0.01f)
        {
            isMovingTowardEnd = !isMovingTowardEnd;
        }
    }

    // Show the endpoint and path when the trap is selected in the editor.
    private void OnDrawGizmosSelected()
    {
        if (endPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, endPoint.position);
        Gizmos.DrawWireSphere(endPoint.position, 0.15f);
    }
}
