using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] private Vector2 scrollDirection;

    private Vector2 offset;
    private Material material;
    private bool applyScroll = true;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Start()
    {
        StartCoroutine(Scrolling());
    }

    IEnumerator Scrolling()
    {
        while (applyScroll)
        {
            offset = scrollDirection * Time.deltaTime;
            material.mainTextureOffset += offset;
            yield return new WaitForEndOfFrame();
        }
    }
}
