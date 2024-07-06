using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    #region Instance
    public static GameAssets Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    public Sprite snakeHeadSprite;
    public Sprite foodSprite;
}
