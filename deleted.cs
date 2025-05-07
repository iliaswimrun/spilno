tedusing UnityEngine;

public class deleted : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Знищує цей об'єкт
        }
    }
}
