using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    GameManager gameManager;
    public GameObject startButton;


    void Start()
    {
        gameManager = GameManager.instance;
    }

    public void StartGame()
    {
        gameManager.gameState = GameState.Playing;
        startButton.SetActive(false);
    }
}
