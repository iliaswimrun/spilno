using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;

    public delegate void OnLifeChanged();
    public static event OnLifeChanged onLifeChanged;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            lives--;
            Debug.Log("Удар ворога! Життів залишилось: " + lives);

            onLifeChanged?.Invoke();

            if (lives <= 0)
            {
                Debug.Log("Гравець загинув.");
                Destroy(gameObject);
            }
        }
    }
}
