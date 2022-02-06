using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")] 
    [SerializeField] private AudioClip shootingSFX;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;
    [SerializeField] private AudioClip explosionSFX;
    [SerializeField] [Range(0f, 1f)] float explosionVolume = 1f;

    private static AudioPlayer audioPlayer;

    private void Awake()
    {
        ManageSingelton();
    }

    private void ManageSingelton()
    {
        if (audioPlayer != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            audioPlayer = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingSFX, shootingVolume);
    }
    public void PlayExplosionClip()
    {
        PlayClip(explosionSFX, explosionVolume);
    }
    public void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
