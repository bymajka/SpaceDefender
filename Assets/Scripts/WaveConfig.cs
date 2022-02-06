using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu (menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private float minTimeBetweenSpawn = 0.2f;
    [SerializeField] private float timeVariance;

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetListOfWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }

        return wayPoints;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public float GetRandomSpawnTime()
    {
        var randomSpawnTime = Random.Range(timeBetweenSpawn - timeVariance, timeBetweenSpawn + timeVariance);
        return Mathf.Clamp(randomSpawnTime, minTimeBetweenSpawn, float.MaxValue);
    }
}
