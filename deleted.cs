using UnityEngine;

public class DestroyOnPlayerTouch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Знищує цей об'єкт
        }
    }
}
