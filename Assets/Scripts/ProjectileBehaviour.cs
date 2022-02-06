using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5f;
    private Rigidbody2D projectileRB;

    private void Start()
    {
        projectileRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        projectileRB.velocity += new Vector2(0f, projectileSpeed * Time.deltaTime);
    }
}
