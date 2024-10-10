using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlScript : MonoBehaviour
{
    private Vector2 movementVector;
    private Rigidbody2D rb;

    private bool onGround;
    private bool doubleUsed = false;

    [SerializeField] int speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = 5 * movementVector;
        rb.velocity = new Vector2(speed * movementVector.x, rb.velocity.y);
    }

    void OnMove(InputValue value) {
        movementVector = value.Get<Vector2>();
        Debug.Log(movementVector);
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.CompareTag("he bounce")) {
            Debug.Log("Yippeeeeee");
            rb.AddForce(new Vector2(0, 600));
        }
        onGround = true;
        doubleUsed = false;
    }

    void OnCollisionExit2D(Collision2D collision) {
        onGround = false;
    }

    void OnJump() {
        if (onGround) { 
            rb.AddForce(new Vector2(0, 400));
        }
    }

    void OnDoubleJump() {
        if (!onGround && !doubleUsed) {
            rb.AddForce(new Vector2(0, 400));
            doubleUsed = true;
        }
    }

    void OnDash() {
        movementVector = movementVector * 4;
    }
}
