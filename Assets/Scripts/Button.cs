using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEditor.Build;

public class ButtonSetka : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        Destroy(gameObject);
    }

}
