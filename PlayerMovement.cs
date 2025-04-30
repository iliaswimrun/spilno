using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        // Проєкція на горизонтальну площину
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = camForward * vertical + camRight * horizontal;

        // Рух гравця
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        // Поворот гравця в напрямку руху
        if (moveDir != Vector3.zero)
        {
            transform.forward = moveDir;
        }
    }
}
