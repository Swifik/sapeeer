using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ButtonSetka : MonoBehaviour
{
    private Button button;
    public int score { get; set; } = 0;
    public delegate void ScoreUpdated(int newScore);
    public event ScoreUpdated OnScoreUpdated;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        score += 1;
        OnScoreUpdated?.Invoke(score);
        gameObject.SetActive(false);
    }

}
