using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private ButtonSetka buttonSet;
    [SerializeField] List<ButtonSetka> buttonSetkas;
    private int totalScore;



    private void Update()
    {
        foreach (var buttonSet in buttonSetkas)
        {
            buttonSet.OnScoreUpdated += UpdateScore;
        }
    }
    private void UpdateScore(int newScore)
    {
        totalScore = 0;
        foreach (var buttonSetka in buttonSetkas)
        {
            totalScore += buttonSetka.score;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        textScore.text = "У вас очков: " + totalScore.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
