using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == GameState.Playing && Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        var bubble = hit.collider.gameObject.GetComponent<Bubble>();
                        bubble.OnHit();
                    }
                }
            }
        }
    }
}
