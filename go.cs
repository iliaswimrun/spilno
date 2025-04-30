using UnityEngine;

public class GO : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    public float jumpForce = 5f;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
    
if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
{
    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    isGrounded = false;
}

        Vector3 movement = new Vector3(moveX, 0, moveZ) * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

int collected = 0;
void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
    }
}

void OnCollisionExit(Collision collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = false;
    }
}

void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Pickup"))
    {
        collected++;
        Destroy(other.gameObject);
        Debug.Log("Зібрано: " + collected);
    }
}
}
