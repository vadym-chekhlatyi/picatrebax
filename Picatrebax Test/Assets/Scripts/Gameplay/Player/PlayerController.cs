using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private bool isGrounded;
    private bool direction;

    private RectTransform rectTransform;

    private void Start()
    {
        Instance = this;

        direction = false;
        rectTransform = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        // Check if ball is out of bounds
        if (rectTransform.anchoredPosition.y > Screen.height / 2 || rectTransform.anchoredPosition.y < -Screen.height / 2)
        {
            Gameplay.Instance.Lose();
        }
    }

    public void ChangeDirection()
    {
        if (isGrounded && Gameplay.Instance.gameActive)
        {
            isGrounded = false;
            direction = !direction;
            GetComponent<Rigidbody2D>().gravityScale = direction ? -1f : 1f;
        }
    }

    // If ball hits the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
