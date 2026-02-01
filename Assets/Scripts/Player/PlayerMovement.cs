using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 5f;
    public float jumpForce = 5f;
    public int startingHealth = 100;
    public int health = 100;
    public int lives = 3;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float move = 0f;

        if (Keyboard.current.aKey.isPressed) move = -1f;
        if (Keyboard.current.dKey.isPressed) move = 1f;
        body.linearVelocity = new Vector2(move * speed, body.linearVelocity.y);

        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }
    }

    public void ModifyHealth(int damage) {
        health += damage;

        if (health <= 0) {
            lives--;
            health = startingHealth;
            transform.position = new Vector2(0,0);
        } else if (health >= startingHealth) {
            health = startingHealth;
        }
    }
}
