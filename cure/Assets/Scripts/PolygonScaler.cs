using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonScaler : MonoBehaviour
{
    PolygonCollider2D polyCollider;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        polyCollider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        float x = spriteRenderer.size.x / 2;
        float y = spriteRenderer.size.y / 2;
        Vector2[] points = new[]
        {
            new Vector2(-x,y),
            new Vector2(-x,-y),
            new Vector2(x,-y),
            new Vector2(x,y)
        };
        polyCollider.SetPath(0, points);
    }
}
