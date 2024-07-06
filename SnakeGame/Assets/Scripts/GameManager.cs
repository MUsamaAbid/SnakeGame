using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils; 

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        GameObject snakeHeadGameObject = new GameObject();
        SpriteRenderer SnakeHeadSpriteRenderer = snakeHeadGameObject.AddComponent<SpriteRenderer>();
        SnakeHeadSpriteRenderer.sprite = GameAssets.Instance.snakeHeadSprite;
    }
}
