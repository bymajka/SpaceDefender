using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeMagnitude;

    private Vector3 initialPosition;
    private static CameraShake cameraShake;

    private void Awake()
    {
        ManageSingleton();
    }
    private void ManageSingleton()
    {
        if (cameraShake != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            cameraShake = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        Health.onPlayerTakeDamage += Play;
        initialPosition = transform.position;
    }
    public void Play()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
    private void OnDisable()
    {
        Health.onPlayerTakeDamage -= Play;
    }
}
