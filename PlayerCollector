using UnityEngine;
using UnityEngine.UI; // Якщо використовуєш Text
using UnityEngine.SceneManagement;

public class PlayerCollector : MonoBehaviour
{
    public int targetCount = 5;
    private int collected = 0;

    public Text countText; // або TMP_Text
    public string nextSceneName = "NextLevel"; // Назва наступної сцени

    void Start()
    {
        UpdateUI();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            collected++;
            Destroy(other.gameObject);
            UpdateUI();

            if (collected >= targetCount)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    void UpdateUI()
    {
        countText.text = "Зібрано: " + collected + "/" + targetCount;
    }
}
