using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDespawner : MonoBehaviour
{
    GameManager gameManager;
    public int lifeLoss = 1;

    void Start()
    {
        gameManager = GameManager.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            var bubble = other.gameObject.GetComponent<Bubble>();
            bubble.Despawn();
            gameManager.playerLife -= lifeLoss;
        }
    }
}
