using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float sceneLoadDelay;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject menuCanvas;
    private ScoreKeeper scoreKeeper;
    
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    
    public void LoadGame()
    {
        if (scoreKeeper != null)
        {
            scoreKeeper.ResetScore();
        }
        SceneManager.LoadScene(1);
    }

    public void ShowSettings()
    {
        settingsCanvas.SetActive((true));
        menuCanvas.SetActive(false);
    }
    public void ReturnToMenu()
    {
        settingsCanvas.SetActive((false));
        menuCanvas.SetActive(true);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameOverScreen()
    {
        StartCoroutine(WaitAndLoad(2, sceneLoadDelay));
    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator WaitAndLoad(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
}
