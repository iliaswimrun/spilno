using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float jumpForce = 7f;
    public float obstacleCheckDistance = 1f;
    public LayerMask groundLayer;
    public LayerMask obstacleLayer;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        FollowPlayer();
        CheckGrounded();
        CheckObstacleAndJump();
    }

    void FollowPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Щоб ворог не "літав" вгору
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }

    void CheckGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }

    void CheckObstacleAndJump()
    {
        Vector3 rayStart = transform.position + Vector3.up * 0.5f;
        Vector3 forward = transform.forward;

        if (Physics.Raycast(rayStart, forward, obstacleCheckDistance, obstacleLayer))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
