using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private float currentScore = 0f;
    [SerializeField] private float scoreForEnemy = 200f;

    private static ScoreKeeper scoreKeeper;

    private void Awake()
    {
        ManageSingleton();
    }
    private void ManageSingleton()
    {
        if (scoreKeeper != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            scoreKeeper = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public float CurrentScore
    {
        get { return currentScore; }
    }
    public float ScoreForEnemy
    {
        get { return scoreForEnemy; }
    }
    public void AddScore(float value)
    {
        currentScore += value;
        Mathf.Clamp(currentScore, 0, float.MaxValue);
        Debug.Log(currentScore);
    }
    public void ResetScore()
    {
        currentScore = 0f;
    }
}
