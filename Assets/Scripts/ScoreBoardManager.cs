using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    private ScoreBoardManager scoreBoardManager;
    private List<ScoreBoardItem> scoreBoardList = new List<ScoreBoardItem>();
    public List<ScoreBoardItem> ScoreBoardList {get { return scoreBoardList; }}
    
    private void Awake()
    {
        CreateSingleton();
    }
    private void CreateSingleton()
    {
        if (scoreBoardManager != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            scoreBoardManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
}
