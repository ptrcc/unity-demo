using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Joystick joystick; 
    public float moveSpeed = 5f; 
    public float jumpForce = 10f;
    public GameObject player;
    private Rigidbody2D rb;

    private bool jump = false;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            Jump();
        }
    }
    
    private void jumpMovement()
    {
        rb.AddForce(new Vector2(0, jumpForce),ForceMode2D.Impulse);
        jump = false;
    }

    public void Jump()
    {
        jump = true;
    }
    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(joystick.Horizontal * moveSpeed, rb.velocity.y);
        if (jump)
        {
            jumpMovement();
        }
    }

}