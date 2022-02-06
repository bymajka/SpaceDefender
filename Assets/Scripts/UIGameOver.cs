using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scorePanel;
    private ScoreKeeper scoreKeeper;

    private void Start()
    {
        //scorePanel = transform.GetComponentInChildren<TextMeshProUGUI>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        GetFinalScore();
    }
    private void GetFinalScore()
    {
        scorePanel.text = ($"You scored:\n") + scoreKeeper.CurrentScore.ToString();
    }
}
