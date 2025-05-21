using TMPro;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TextMeshProUGUI livesText;

    private void OnEnable()
    {
        PlayerHealth.onLifeChanged += UpdateLives;
    }

    private void OnDisable()
    {
        PlayerHealth.onLifeChanged -= UpdateLives;
    }

    void Start()
    {
        UpdateLives(); // Початкове відображення життів
    }

    void UpdateLives()
    {
        livesText.text = "Життя: " + playerHealth.lives;
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        Color originalColor = livesText.color;

        for (int i = 0; i < 3; i++)
        {
            livesText.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            livesText.color = originalColor;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
