using System;
using UnityEngine;

public class RayCastExample : MonoBehaviour
{
    public LayerMask groundLayer;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    private float verticalVelocity = 0f;
    private float moveSpeed = 2f;
    private Animator animator;
    private bool isWalking;
    private bool facingRight; 

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.05f, groundLayer);

        if (hit.collider != null) // grounded
        {
            verticalVelocity = 0f; 

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else // not grounded
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * (horizontalInput * moveSpeed * Time.deltaTime));

        transform.Translate(Vector3.up * (verticalVelocity * Time.deltaTime));

        // Check for movement and update facing direction
        isWalking = Mathf.Abs(horizontalInput) > 0.1f;
        animator.SetBool("isWalking", isWalking);

        
    }

    void Jump()
    {
        verticalVelocity = jumpForce;
    }

   
}