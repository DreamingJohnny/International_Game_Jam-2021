using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Properties")]
    public float speed = 10;
    private bool stopMovement = true;
    private float dashCooldown;
    public float inputX;
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

        Debug.Log(dashCooldown.ToString());
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
