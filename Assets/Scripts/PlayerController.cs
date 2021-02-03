using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Properties")]
    public float speed = 10;

    [Header("References")]
    public SpriteRenderer sprite;

    private float inputX;
    private bool stopMovement = true;
    private float dashCooldown;
    private BoxCollider2D playerCollider;

    private void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if (stopMovement == true)
        {
            inputX = Input.GetAxisRaw("Horizontal");
        }

        Vector2 movement = new Vector2(inputX * speed, -3);
        movement *= Time.fixedDeltaTime;

        if (inputX == 1)
        {
            sprite.flipX = false; 
        }

        if (inputX == -1)
        {
            sprite.flipX = true;
        }

        transform.Translate(movement);

        if (dashCooldown >= 0f)
        {
            dashCooldown = dashCooldown - Time.deltaTime;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && dashCooldown <= 0f)
        {
            StartCoroutine(DashTime());
        }
    }

    IEnumerator DashTime()
    {
        dashCooldown = 1.2f;
        speed = speed + 20f;
        stopMovement = false;
        yield return new WaitForSeconds(0.2f);
        stopMovement = true;
        speed = speed - 20f;
    }
}
