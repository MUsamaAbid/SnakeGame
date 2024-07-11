using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;

    private float gridMoveTimer;
    private float gridMoveTimerMax;

    private float snakeBodySize;
    private List<Vector2Int> snakeMovePositionList;

    private LevelGrid levelGrid;

    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    } 

    private void Awake()
    {
        gridPosition = new Vector2Int(0, 0);
        gridMoveTimerMax = 0.33f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);

        snakeMovePositionList = new List<Vector2Int>();
        snakeBodySize = 1f;
    }
    
    private void Update()
    {
        HandleInput();

        HandleGridMovement();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != 1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -1)
            {
                gridMoveDirection.x = 1;
                gridMoveDirection.y = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != 1)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }
    }

    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;

            snakeMovePositionList.Insert(0, gridPosition);

            gridPosition += gridMoveDirection;

            if (snakeMovePositionList.Count >= snakeBodySize + 1)
            {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);
            }

            for (int i = 0; i < snakeMovePositionList.Count; i++)
            { 
                Vector2Int snakeMovePosition = snakeMovePositionList[i];

                //World_Sprite worldSprite = World_Sprite.Create(new Vector3(snakeMovePosition.x, snakeMovePosition.y), Vector3.one * .5f, Color.white);
                //FunctionTimer.Create(worldSprite.DestroySelf, gridMoveTimerMax);

                GameObject snakeBody = MyUtils.CreateSpriteGameObject(new Vector3(snakeMovePosition.x, snakeMovePosition.y), new Vector3(0.5f, 0.5f, 1), GameAssets.Instance.snakeBodySprite);
                FunctionTimer.Create(() => MyUtils.DestroyGameObject(snakeBody), gridMoveTimerMax);

            }

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) + 90);

            levelGrid.SnakeMoved(gridPosition);
        }
    }

    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }
}
