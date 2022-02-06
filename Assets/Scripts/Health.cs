using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthPoints;
    [SerializeField] private ParticleSystem hitEffect;

    [SerializeField] private bool isPlayer;
    private AudioPlayer audioPlayer;
    private ScoreKeeper scoreKeeper;
    private LevelManager levelManager;

    public static event OnPlayerTakeDamage onPlayerTakeDamage;
    public delegate void OnPlayerTakeDamage();

    private void Start()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDiller damageDiller = other.GetComponent<DamageDiller>();

        if (damageDiller != null)
        {
            TakeDamage(damageDiller.GetDamage());
            audioPlayer.PlayExplosionClip();
            PlayHitEffect();
            damageDiller.Hit();
            if (isPlayer)
            {
                onPlayerTakeDamage.Invoke();
            }
        }
    }
    private void TakeDamage(float damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            if (!isPlayer)
            {
                scoreKeeper.AddScore(scoreKeeper.ScoreForEnemy);
            }
            else
            {
                levelManager.LoadGameOverScreen();
            }
            Destroy(gameObject);
        }
    }
    private void PlayHitEffect()
    {
        if (hitEffect!= null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    public float GetCurrentHealth()
    {
        return healthPoints;
    }
}
