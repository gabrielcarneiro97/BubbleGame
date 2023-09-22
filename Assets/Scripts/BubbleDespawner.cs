using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDespawner : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            Destroy(other.gameObject);
            gameManager.playerLife--;
        }
    }
}
