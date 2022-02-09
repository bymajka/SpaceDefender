using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private PauseAction action;
    private bool gameIsPaused = false;

    private void Awake()
    {
        action = new PauseAction();
    }
    private void Start()
    {
        action.Pause.PauseGame.performed += _ => DeterminePause();
    }
    private void DeterminePause()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    private void OnEnable()
    {
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
    }
}
