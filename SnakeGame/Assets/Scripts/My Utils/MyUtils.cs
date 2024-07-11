using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUtils : MonoBehaviour
{
    public static GameObject CreateSpriteGameObject(Vector3 position, Vector3 scale, Sprite sprite)
    {
        GameObject gameObject = new GameObject("CustomGameObject");
        gameObject.transform.position = position;
        gameObject.transform.localScale = scale;

        // Add a SpriteRenderer component and set its color
        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;

        return gameObject;
    }

    public static void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
