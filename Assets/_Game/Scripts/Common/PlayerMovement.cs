using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float laneDistance = 5f; // Distance between lanes
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravity = 1f;
    [SerializeField] private float slideDuration = 1f;
    [SerializeField] private float verticalVelocity = -1f;

    [SerializeField] private InputHandler _input;

    [Header("Sprite Arts")]
    [SerializeField] private Sprite _runningSprite;
    [SerializeField] private Sprite _slidingSprite;

    private CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;
    private int desiredLane = 1; // 0 = left, 1 = middle, 2 = right
    private bool isSliding = false;
    private bool isJumping = false;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (_input == null) return;

        // Read swipe input
        if (_input.TouchSwipeLeft)
        {
            MoveLane(false);
        }
        if (_input.TouchSwipeRight)
        {
            MoveLane(true);
        }
        if (_input.TouchSwipeUp)
        {
            Jump();
        }
        if (_input.TouchSwipeDown)
        {
            Slide();
        }

        // Forward Movement
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;

        Vector3 diff = targetPosition - transform.position;
        Vector3 move = Vector3.forward * moveSpeed;
        move.x = diff.x * moveSpeed;

        // Apply vertical (jump/fall)
        if (controller.isGrounded)
        {
            if (isSliding)
            {
                verticalVelocity = 0;
            }
            else if (isJumping)
            {
                verticalVelocity = jumpForce;
            }
            else
            {
                verticalVelocity = -1f;
            }
        }

       //apply gravity
       verticalVelocity += gravity * Time.deltaTime;
        

        move.y = verticalVelocity;

        // Move the player
        controller.Move(move * Time.deltaTime);
    }

    private void MoveLane(bool goingRight)
    {
        desiredLane += goingRight ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2); // Stay between 0-2
    }
    private void Jump()
    {
        StartCoroutine(JumpCoroutine());
       
       
    }
    private void Slide()
    {
        if (!isSliding && controller.isGrounded)
        {
            StartCoroutine(SlideCoroutine());
            // Swap to sliding sprite
            _spriteRenderer.sprite = _slidingSprite;

            // Optionally, after a small delay, go back to running sprite
            Invoke(nameof(ResetToRunning), 1.0f); // 1 second later
        }
    }
    private void ResetToRunning()
    {
        _spriteRenderer.sprite = _runningSprite;
    }
    private IEnumerator SlideCoroutine()
    {
        isSliding = true;

        // Save original values
        float originalHeight = controller.height;
        Vector3 originalCenter = controller.center;

        // Adjust height and center
        controller.height = originalHeight / 1.8f;
        controller.center = new Vector3(originalCenter.x, -1.03f, originalCenter.z);

        yield return new WaitForSeconds(slideDuration);

        // Reset height and center
        controller.height = originalHeight;
        controller.center = originalCenter;

        isSliding = false;
    }
    private IEnumerator JumpCoroutine()
    {
        isJumping = true;
        jumpForce = 10;
        Debug.Log("Jump!");

        yield return new WaitForSeconds(0.1f);

        //reset
        isJumping = false;
        jumpForce = 0;
    }
}

