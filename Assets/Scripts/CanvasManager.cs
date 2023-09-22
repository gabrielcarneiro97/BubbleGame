using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasManager : MonoBehaviour
{
    GameManager gameManager;
    public GameObject startButtonGameObject;
    public GameObject gameOverButtonGameObject;
    public GameObject scoreTextGameObject;
    private TMP_Text scoreText;

    void Start()
    {
        gameManager = GameManager.instance;

        if (gameOverButtonGameObject != null)
        {
            gameOverButtonGameObject.SetActive(false);
            gameManager.SubscribeToGameStateChange(OnGameOver);
        }

        if (scoreTextGameObject != null)
        {
            scoreText = scoreTextGameObject.GetComponent<TMP_Text>();
            gameManager.SubscribeToScoreChange(OnScoreChange);
        }
    }

    void OnScoreChange(int score)
    {
        if (scoreTextGameObject != null) scoreText.text = score.ToString();
    }

    void OnGameOver(GameState gameState)
    {
        if (gameState == GameState.GameOver) gameOverButtonGameObject.SetActive(true);
    }

    public void StartGame()
    {
        gameManager.gameState = GameState.Playing;
        if (startButtonGameObject != null) startButtonGameObject.SetActive(false);
        if (gameOverButtonGameObject != null) gameOverButtonGameObject.SetActive(false);
    }
}
