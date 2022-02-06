using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Paddings")]
    [SerializeField] private float leftPadding;
    [SerializeField] private float rightPadding;
    [SerializeField] private float topPadding;
    [SerializeField] private float bottomPadding;

    [SerializeField] private float playerSpeed;

    private Vector2 rawInput;
    private Vector2 minBounds;
    private Vector2 maxBounds;

    private Shooter shooter;
    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        InitBounds();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector2 delta = rawInput * playerSpeed * Time.deltaTime;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + leftPadding, maxBounds.x - rightPadding);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + bottomPadding, maxBounds.y - topPadding);
        transform.position = newPosition;
    }
    private void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.IsFiring = value.isPressed;
        }
    }
}
