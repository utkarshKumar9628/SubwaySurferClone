using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private bool isGrounded;
    private bool isJumping;
    private Rigidbody rb;
    private Animator anim; // Change from Animation to Animator

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>(); // Change from Animation to Animator
    }

    void Update()
    {
        // Move the cube forward endlessly
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the cube is grounded and not currently jumping
            if (isGrounded && !isJumping)
            {
                anim.SetBool("Jumping", true);
                Jump();
            }
        }
    }

    void Jump()
    {
        // Apply force to make the cube jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
        isJumping = true;

        // Invoke a method to reset the jumping state after a delay (e.g., 1 second)
        Invoke("ResetJumping", 1f);
    }

    void ResetJumping()
    {
        isJumping = false;
        anim.SetBool("Jumping", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the cube collides with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        // Check if the cube collides with hurdles
        else if (collision.gameObject.CompareTag("Hurdles"))
        {
            // Game over
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("collision");
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}