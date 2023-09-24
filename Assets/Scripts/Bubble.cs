using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    Rigidbody rb;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
    }

    public void Despawn()
    {
        gameManager.BubbleDestroyed(gameObject, 0);
        gameManager.AddBubbleToPool(gameObject);
    }

    public void OnHit()
    {
        gameManager.BubbleDestroyed(gameObject, 1);
        gameManager.AddBubbleToPool(gameObject);
    }
}
