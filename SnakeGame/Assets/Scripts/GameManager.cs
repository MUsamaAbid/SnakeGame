using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils; 

public class GameManager : MonoBehaviour
{
    [SerializeField] private Snake snake;

    private LevelGrid levelGrid;

    private void Start()
    {
        //GameObject snakeHeadGameObject = new GameObject();
        //SpriteRenderer SnakeHeadSpriteRenderer = snakeHeadGameObject.AddComponent<SpriteRenderer>();
        //SnakeHeadSpriteRenderer.sprite = GameAssets.Instance.snakeHeadSprite;

        levelGrid = new LevelGrid(20, 20);
        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
    }
}
