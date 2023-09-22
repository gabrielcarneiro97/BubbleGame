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

    void Start()
    {
        gameManager = GameManager.instance;
        rightLimitX = rightLimit.transform.position.x;
        leftLimitX = leftLimit.transform.position.x;
        gameManager.SubscribeToGameStateChange(StartSpawning);
    }

    public void StartSpawning(GameState gameState)
    {
        if (gameState == GameState.Playing) StartCoroutine(SpawnBubbles());
    }

    IEnumerator SpawnBubbles()
    {
        float randomX = Random.Range(leftLimitX, rightLimitX);
        var spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(.3f, .5f));

        if (gameManager.gameState == GameState.Playing) StartCoroutine(SpawnBubbles());
    }
}
