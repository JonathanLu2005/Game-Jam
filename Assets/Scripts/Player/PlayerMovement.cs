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

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        // Animate the player's movement
        AnimateMovement();
    }

    public void AnimateMovement()
    {
        // Set animation parameter float
        animator.SetFloat("Speed", Mathf.Abs(body.linearVelocityX));

        if (body.linearVelocityX < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (body.linearVelocityX > 0)
        {
            spriteRenderer.flipX = false;
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
