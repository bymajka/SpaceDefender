using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI textScore;
    private bool looping = true;

    private void Start()
    {
        healthSlider.maxValue = FindObjectOfType<Player>().GetComponent<Health>().GetCurrentHealth();
        StartCoroutine(UpdateUI());
    }
    IEnumerator UpdateUI()
    {
        while (looping)
        {
            if (FindObjectOfType<Player>() != null)
            {
                healthSlider.value = FindObjectOfType<Player>().GetComponent<Health>().GetCurrentHealth();
            }
            else
            {
                healthSlider.value = healthSlider.minValue;
            }
            textScore.text = FindObjectOfType<ScoreKeeper>().CurrentScore.ToString("0000");
            yield return new WaitForEndOfFrame();
        }
    }
}
