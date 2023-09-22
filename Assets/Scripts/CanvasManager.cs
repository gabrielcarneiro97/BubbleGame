using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    GameManager gameManager;
    public GameObject startButton;
    public GameObject gameOverButton;

    void Start()
    {
        gameManager = GameManager.instance;

        if (gameOverButton != null)
        {
            gameOverButton.SetActive(false);
            gameManager.SubscribeToGameStateChange(OnGameOver);
        }
    }

    void OnGameOver(GameState gameState)
    {
        if (gameState == GameState.GameOver) gameOverButton.SetActive(true);
    }

    public void StartGame()
    {
        gameManager.gameState = GameState.Playing;
        if (startButton != null) startButton.SetActive(false);
        if (gameOverButton != null) gameOverButton.SetActive(false);
    }
}
