using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigList;
    [SerializeField] private float timeBetweenWaves = 0f;
    private bool isLooping = true;
    private WaveConfig currentWave;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }
    private IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (var wave in waveConfigList)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), 
                        currentWave.GetStartingWayPoint().position, 
                        Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }
}
