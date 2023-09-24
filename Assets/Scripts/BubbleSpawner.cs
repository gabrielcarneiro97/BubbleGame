using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public GameObject leftLimit;
    public GameObject rightLimit;

    private float rightLimitX;
    private float leftLimitX;

    private GameManager gameManager;

    private List<GameObject> bubbles = new List<GameObject>();

    void Start()
    {
        gameManager = GameManager.instance;
        rightLimitX = rightLimit.transform.position.x;
        leftLimitX = leftLimit.transform.position.x;
        gameManager.SubscribeToGameStateChange(OnGameStateChange);
        gameManager.SubscribeToBubbleDestroyed(OnBubbleDestroyed);
    }

    void OnGameStateChange(GameState gameState)
    {
        if (gameState == GameState.Restarting)
        {
            bubbles.ForEach(bubble =>
            {
                if (bubble != null) gameManager.AddBubbleToPool(bubble);
            });
            bubbles.Clear();
            StopAllCoroutines();
            gameManager.gameState = GameState.Playing;
        }
        if (gameState == GameState.Playing) StartCoroutine(SpawnBubbles());
    }

    public void OnBubbleDestroyed(GameObject bubble, int score)
    {
        bubbles.Remove(bubble);
        gameManager.score += score;
    }

    IEnumerator SpawnBubbles()
    {
        float randomX = Random.Range(leftLimitX, rightLimitX);
        var spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        var bubble = gameManager.PopBubbleFromPool();
        if (bubble == null) bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
        else bubble.transform.position = spawnPosition;
        bubbles.Add(bubble);
        yield return new WaitForSeconds(Random.Range(.3f, .5f));

        if (gameManager.gameState == GameState.Playing) StartCoroutine(SpawnBubbles());
    }
}
