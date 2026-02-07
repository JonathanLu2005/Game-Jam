using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float startingSpeed = 5f;
    public float speed = 10f;
    public float jumpForce = 10f;
    private Coroutine speedRoutine;
    private float speedRoutineTimeLeft;

    private bool jumping = false;
    private bool isFlipped = false;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        speed = startingSpeed;
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float move = 0f;

        if (PlayerData.iframesTime > 0f) PlayerData.iframesTime = Mathf.    Max(PlayerData.iframesTime-Time.deltaTime,0f);
        if (Keyboard.current.aKey.isPressed) move = -1f;
        if (Keyboard.current.dKey.isPressed) move = 1f;
        body.linearVelocity = new Vector2(move * speed, body.linearVelocity.y);

        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            // Set animation trigger for jump
            animator.SetTrigger("Jump");
        }

        if (Keyboard.current.shiftKey.wasPressedThisFrame)
        {
            // Set animation trigger for jump
            animator.SetTrigger("Parry");
        }

        // Animate the player's movement
        AnimateMovement();
    }

    public void Jump()
    {
        if (!jumping)
        {
            jumping = true;
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }
    }

    public void Grounded()
    {
        jumping = false;
        //Debug.Log("Grounded");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            jumping = false;
            //Debug.Log("On da ground");
        }
    }
    public void AnimateMovement()
    {
        // Set animation parameter float
        animator.SetFloat("Speed", Mathf.Abs(body.linearVelocityX));

        // Set animation parameter for ySpeed
        animator.SetFloat("ySpeed", body.linearVelocityY);

        if (body.linearVelocityX < 0 && !isFlipped)
        {
            GameObject.FindGameObjectWithTag("Player").transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        if (body.linearVelocityX > 0 && isFlipped)
        {
            GameObject.FindGameObjectWithTag("Player").transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
    }

    public void SpeedOverTimeRoutine(int value, int duration) {
        speedRoutineTimeLeft = duration;

        if (speedRoutine == null) {
            speedRoutine = StartCoroutine(SpeedOverTime(value));
        }
    }

    IEnumerator SpeedOverTime(int value) {
        while (speedRoutineTimeLeft > 0) {
            speed = value;
            speedRoutineTimeLeft -= 1f;
            yield return new WaitForSeconds(1f);
        }

        speed = startingSpeed;
        speedRoutine = null;
    }
}
