using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasManager : MonoBehaviour
{
    GameManager gameManager;
    public GameObject startButtonGameObject;
    public GameObject gameOverButtonGameObject;
    public GameObject winTextGameObject;
    public GameObject scoreTextGameObject;
    private TMP_Text scoreText;

    public GameObject lifesGameObject;
    public List<GameObject> lifes = new List<GameObject>();

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

        if (lifesGameObject != null)
        {
            gameManager.SubscribeToPlayerLifeChange(OnPlayerLifeChange);
        }

    }

    void OnPlayerLifeChange(int life)
    {
        lifes.ForEach(lifeGameObject => lifeGameObject.SetActive(false));
        for (int i = 0; i < life; i++)
        {
            lifes[i].SetActive(true);
        }
    }

    void OnScoreChange(int score)
    {
        if (scoreTextGameObject != null) scoreText.text = score.ToString();
    }

    void OnGameOver(GameState gameState)
    {
        if (gameState == GameState.GameOver) gameOverButtonGameObject.SetActive(true);
        if (gameState == GameState.Win)
        {
            winTextGameObject.SetActive(true);
            gameOverButtonGameObject.SetActive(true);
        }
    }

    public void StartGame()
    {
        gameManager.gameState = GameState.Playing;
        if (startButtonGameObject != null) startButtonGameObject.SetActive(false);
        if (gameOverButtonGameObject != null) gameOverButtonGameObject.SetActive(false);
        if (winTextGameObject != null) winTextGameObject.SetActive(false);
    }
}
