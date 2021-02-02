using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Properties")]
    public float speed = 10;

    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(inputX * speed, -3);
        movement *= Time.fixedDeltaTime;

        transform.Translate(movement);
    }
}
