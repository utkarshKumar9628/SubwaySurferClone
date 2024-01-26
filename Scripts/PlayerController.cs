using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int numberOfCoins; 

    public CharacterController characterController;

    private Vector3 direction;
    public float forwardSpeed = 10f;
    public float maxSpeed;
    private int desiredlane = 1;
    public float laneDistance = 4;
    public float jumpForce = 5;
    public float slideDuration = 1.3f;
    public float slideColliderHeight = 0.5f;
    public float gravity = -20;
    public Animator animator;
    

    private bool isJumping = false;
    private bool isSliding = false;

    private float originalControllerHeight; // Store the original height for resetting

    public void Start()
    {
        originalControllerHeight = characterController.height;
        numberOfCoins = 0;
        
    }

    public void Update()
    {
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }

        direction.z = forwardSpeed;
        direction.y += gravity * Time.deltaTime;

        if (characterController.isGrounded)
        {
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }

        if (SwipeManager.swipeDown)
        {
            Slide();
        }

        if (SwipeManager.swipeRight)
        {
            ChangeLane(1);
        }

        if (SwipeManager.swipeLeft)
        {
            ChangeLane(-1);
        }

        // Check if player is on the ground and not currently performing a jump or slide
        if (characterController.isGrounded && !isJumping && !isSliding)
        {
            // Set the "Jump" and "Slide" parameters in the animator to false
            animator.SetBool("Jump", false);
            animator.SetBool("Slide", false);

            // Reset the character controller height to normal
            characterController.height = originalControllerHeight;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredlane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredlane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        // Use Move instead of directly setting position to handle collisions
        characterController.Move(targetPosition - transform.position);
    }

    public void FixedUpdate()
    {
        // Move forward
        characterController.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        if (characterController.isGrounded)
        {
            // Set the "Jump" parameter in the animator to true
            animator.SetBool("Jump", true);
            // Set a flag to indicate that the player is currently jumping
            isJumping = true;

            // Start a coroutine to handle returning to the running state after a delay
            StartCoroutine(ReturnToRunningState());

            direction.y = jumpForce;
        }
    }

    private void Slide()
    {
        if (characterController.isGrounded && !isSliding)
        {
            // Set the "Slide" parameter in the animator to true
            animator.SetBool("Slide", true);
            // Set a flag to indicate that the player is currently sliding
            isSliding = true;

            // Reduce the character controller height during the slide
            characterController.height = slideColliderHeight;

            // Start a coroutine to handle returning to the running state after a delay
            StartCoroutine(ReturnToRunningState());
        }
    }

    private void ChangeLane(int delta)
    {
        desiredlane += delta;
        desiredlane = Mathf.Clamp(desiredlane, 0, 2);
    }

    private IEnumerator ReturnToRunningState()
    {
        // Wait for a certain duration, then set the "Jump" and "Slide" parameters to false
        yield return new WaitForSeconds(slideDuration);
        animator.SetBool("Jump", false);
        animator.SetBool("Slide", false);

        // Reset the flags indicating that the player is no longer jumping or sliding
        isJumping = false;
        isSliding = false;

        // Reset the character controller height to normal
        characterController.height = originalControllerHeight;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        { 
        
        PlayerManager.gameOver = true;
        
        }
    }
}