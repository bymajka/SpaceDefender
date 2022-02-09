using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScoreBoardItem", fileName = "NewScore")]
public class ScoreBoardItem : ScriptableObject
{
    [SerializeField] private string playerName = string.Empty;
    [SerializeField] private float score = 0f;

    public void SetData(string name, float score)
    {
        playerName = name;
        this.score = score;
    }
}
