using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WallColliderScaler : MonoBehaviour
{
    [SerializeField] float width = 2f;

    private void Start()
    {

        SetWalls();
    }

    private void SetWalls()
    {
        SpriteRenderer spriteRenderer = GetComponentInParent<SpriteRenderer>();
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();

        float xSize = spriteRenderer.size.x;
        float ySize = spriteRenderer.size.y;

        float xOffset = xSize / 2 + (width / 2);
        float yOffset = ySize / 2 + (width / 2);

        colliders[0].size = new Vector2(xSize, width);
        colliders[0].offset = new Vector2(0, yOffset);

        colliders[1].size = new Vector2(width, ySize);
        colliders[1].offset = new Vector2(xOffset, 0);

        colliders[2].size = new Vector2(xSize, width);
        colliders[2].offset = new Vector2(0, -yOffset);

        colliders[3].size = new Vector2(width, ySize);
        colliders[3].offset = new Vector2(-xOffset, 0);
    }
}
