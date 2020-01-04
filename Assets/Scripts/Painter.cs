using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum Direction
{
    Left,
    Right,
    Up,
    Down,
    None
}

public class Painter : MonoBehaviour
{

    public float speed = 10.0f;
    private Rigidbody rb;
    private Direction moveDirection = Direction.None;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude < .5f)
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            moveDirection = Direction.Up;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            moveDirection = Direction.Down;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            moveDirection = Direction.Right;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            moveDirection = Direction.Left;
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        switch (moveDirection)
        {
            case Direction.Right:
                rb.velocity = new Vector3(speed, 0, 0);
                return;
            case Direction.Left:
                rb.velocity = new Vector3(-speed, 0, 0);
                return;
            case Direction.Up:
                rb.velocity = new Vector3(0, 0, speed);
                return;
            case Direction.Down:
                rb.velocity = new Vector3(0, 0, -speed);
                return;
            default:
                rb.velocity = Vector3.zero;
                return;
        }
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        rb.velocity = Vector3.zero;
        moveDirection = Direction.None;
    }
}
