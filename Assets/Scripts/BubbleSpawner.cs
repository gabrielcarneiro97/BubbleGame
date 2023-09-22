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
        StartCoroutine(SpawnBubbles());
    }

    IEnumerator SpawnBubbles()
    {
        float randomX = Random.Range(leftLimitX, rightLimitX);
        var spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(.3f);
        if (gameManager.playerLife > 0)
        {
            StartCoroutine(SpawnBubbles());
        }
    }
}
