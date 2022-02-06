using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private float projectileLifeTime = 3f;
    
    [Header("AI")]
    [SerializeField] private bool useAI;
    [SerializeField] private float minFiringRate = 0.5f;
    [SerializeField] private float baseFiringRate = 0.2f;
    [SerializeField] private float firingRateVariance;
    
    private bool isFiring;
    private Coroutine firingCoroutine;
    private AudioPlayer audioPlayer;
    public bool IsFiring
    {
        get { return isFiring;}
        set { isFiring = value;}
    }
    public float MinFiringRate
    {
        get { return minFiringRate; }
        set { minFiringRate = value; }
    }

    private void Start()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        if (useAI)
        {
            isFiring = true;
        }
    }
    private void Update()
    {
        Fire();
    }
    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContiniously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }
    IEnumerator FireContiniously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, quaternion.identity);
            if (audioPlayer != null && !useAI)
            {
                audioPlayer.PlayShootingClip();
            }
            Destroy(instance, projectileLifeTime);

            Rigidbody2D projectileRB = instance.GetComponent<Rigidbody2D>();
            if (projectileRB != null && !useAI)
            {
                projectileRB.velocity = Vector2.up * projectileSpeed;
            }
            else if(projectileRB != null && useAI)
            {
                projectileRB.velocity = Vector2.down * projectileSpeed;
            }
            yield return new WaitForSeconds(GetRandomProjectileSpawnTime());
        }
    }
    public float GetRandomProjectileSpawnTime()
    {
        var timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
        timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minFiringRate, float.MaxValue);
        return timeToNextProjectile;
    }
}
