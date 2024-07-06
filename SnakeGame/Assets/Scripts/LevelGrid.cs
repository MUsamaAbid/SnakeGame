using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class LevelGrid
{
    GameObject foodGameObject;

    private Vector2Int foodGridPosition;
    private int width;
    private int height;

    private Snake snake;

    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
    }

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
    private void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (snake.GetGridPosition() == foodGridPosition);

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.Instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    public void SnakeMoved(Vector2Int snakeGridPosition)
    {
        if(snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            CMDebug.TextPopupMouse("Snake Ate Food");
        }
    }
}
