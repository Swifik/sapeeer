using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button endButton;



    private void Start()
    {
        panel.SetActive(false);
        endButton.onClick.AddListener(OnEndGameButtonClick);
    }

    private void OnEndGameButtonClick()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

}
