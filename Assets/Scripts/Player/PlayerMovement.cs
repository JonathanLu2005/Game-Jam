using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Runtime.CompilerServices;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float startingSpeed = 5f;
    public float speed = 10f;
    private float jumpForce = 0f;
    private float jumpHoldForce = 10f;
    private float maxJumpTime = 0.25f;

    private float jumpTimeCounter;
    private bool isJumpingHeld;

    private Coroutine speedRoutine;
    private float speedRoutineTimeLeft;

    private bool jumping = false;
    private bool isFlipped = false;
    private bool isInvincible = false;
    private bool canParry = true;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;

    Coroutine iFrameRoutine;

    private void Awake()
    {
        speed = startingSpeed;
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        float move = 0f;
        
        if (PlayerData.iframesTime > 0f) PlayerData.iframesTime = Mathf.Max(PlayerData.iframesTime - Time.deltaTime, 0f);
        if (!isInvincible && PlayerData.iframesTime > 0f) {
            Debug.Log(PlayerData.iframesTime);
            isInvincible = true;

            // Don't start IFrame animation if invincible from parrying
            if (PlayerData.isParrying) {
                PlayerData.isParrying = false;
            }
            else
            {
                StartIFrames();
            }
            
        }
        ;

        if (isInvincible && PlayerData.iframesTime == 0f)
        {
            Debug.Log(PlayerData.iframesTime);
            isInvincible = false;
            StopIFrames();
        }
        if (Keyboard.current.aKey.isPressed) move = -1f;
        if (Keyboard.current.dKey.isPressed) move = 1f;
        body.linearVelocity = new Vector2(move * speed, body.linearVelocity.y);

        // Start jump
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !jumping)
        {
            jumping = true;
            isJumpingHeld = true;
            jumpTimeCounter = maxJumpTime;

            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump");
            Jump();
        }

        // Continue jump while held
        if (Keyboard.current.spaceKey.isPressed && isJumpingHeld)
        {
            if (jumpTimeCounter > 0)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, jumpHoldForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumpingHeld = false;
            }
        }

        // Stop jump early when released
        if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            isJumpingHeld = false;

            if (body.linearVelocity.y > 0)
                body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * 0.5f);
        }


        if (Keyboard.current.shiftKey.wasPressedThisFrame)
        {
            Debug.Log("Can Parry:" + canParry);
            // Set animation trigger for parry
            if (canParry) animator.SetTrigger("Parry");
            StartCoroutine(TempDisableParry());
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            StartCoroutine(DropThroughPlatform());
        }

        // Animate the player's movement
        AnimateMovement();
    }

    private IEnumerator TempDisableParry() {
        if (!canParry)
        {
            yield return null;
        }
        canParry = false;
        Debug.Log("Disabled Parry:"+canParry);
        yield return new WaitForSeconds(1.5f);
        canParry = true;
    }

    private void StartIFrames() {

        iFrameRoutine = StartCoroutine(IFrameVisual());
    }

    private void StopIFrames()
    {
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
        StopCoroutine(iFrameRoutine);
    }

    IEnumerator IFrameVisual()
    {
        while (true)
        {
            var currentColor = spriteRenderer.color;
            Debug.Log("Alpha Value:" + currentColor.a);
            if(currentColor.a == 1f)
            {
                currentColor.a = 0.5f;
                spriteRenderer.color = currentColor;
            } else if(currentColor .a == 0.5f)
            {
                currentColor.a = 1f;
                spriteRenderer.color = currentColor;
            }


            yield return new WaitForSeconds(0.1f);
        }
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

    private IEnumerator DropThroughPlatform()
    {
        LayerMask platformMask = LayerMask.GetMask("Platforms");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, platformMask);
        if (hit.collider != null && hit.collider.GetComponent<PlatformEffector2D>() != null)
        {
            Collider2D platformCollider = hit.collider;
            Physics2D.IgnoreCollision(playerCollider, platformCollider, true);
            yield return new WaitForSeconds(0.75f);
            Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        }
    }
}
