using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask obstacleLayer;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public float moveSpeed = 2f;

    private float verticalVelocity = 0f;
    private Animator animator;
    private bool isWalking;
    private bool facingRight = true;

    private int numberOfRays = 36;
    private float rayDistance = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0 && facingRight)
        {
            FlipSprite(); 
        }
        else if (horizontalInput > 0 && !facingRight)
        {
            FlipSprite(); 
        }

        Vector2 raycastOrigin = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y, 0f);

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, 0.05f, groundLayer);

        Debug.DrawRay(raycastOrigin, Vector2.down * 0.05f, hit.collider != null ? Color.green : Color.red);

        Draw360DegreeRays();

        if (hit.collider != null) // Grounded 
        {
            verticalVelocity = 0f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        if (!IsObstacleInDirection(Vector2.right * horizontalInput))
        {
            transform.Translate(Vector3.right * (horizontalInput * moveSpeed * Time.deltaTime));
        }

        transform.Translate(Vector3.up * (verticalVelocity * Time.deltaTime));

        isWalking = Mathf.Abs(horizontalInput) > 0.1f;
        animator.SetBool("isWalking", isWalking);
    }

    void Draw360DegreeRays()
    {
        float angleStep = 10f;
        float rayLength = 1f;

        Collider2D characterCollider = GetComponent<Collider2D>();
        Vector2 characterPosition = characterCollider.bounds.center;

        for (int i = 0; i < numberOfRays; i++)
        {
            float angle = i * angleStep;

            float radians = angle * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));

            RaycastHit2D hit = Physics2D.Raycast(characterPosition, direction, rayLength, obstacleLayer);

            Color rayColor = hit.collider != null ? Color.red : Color.green;

            Debug.DrawRay(characterPosition, direction * rayLength, rayColor);
        }
    }

    void Jump()
    {
        verticalVelocity = jumpForce;
    }

    bool IsObstacleInDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayDistance, obstacleLayer);

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, direction * hit.distance, Color.red);
            return true;
        }

        Debug.DrawRay(transform.position, direction * rayDistance, Color.green);
        return false;
    }

    void FlipSprite()
    {
        facingRight = !facingRight;
        
        Vector3 scale = transform.localScale;
        
        scale.x *= -1;
        
        transform.localScale = scale;
    }
}
