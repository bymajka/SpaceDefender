using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private Collider2D powerUpCollider;

    private void Start()
    {
        powerUpCollider = transform.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other != null)
        {
            other.GetComponent<Shooter>().MinFiringRate = 0.2f;
        }
    }
}
