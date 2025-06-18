using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameTimer timer;
    public TextMeshProUGUI finalTimeText;

    public void GameOver()
    {
        timer.StopTimer();
        gameOverPanel.SetActive(true);
        finalTimeText.text = "Час: " + timer.FormatTime(timer.GetTimeElapsed());
    }
}
