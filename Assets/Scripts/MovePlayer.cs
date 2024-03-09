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
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        
        if (jump)
        {
            jumpMovement();
        }
    }
    
    private void jumpMovement()
    {
        rb.AddForce(Vector2.up * jumpForce);
        jump = false;
    }

    public void Jump()
    {
        Debug.Log("Jump");
        Debug.Log(jumpForce);
        Debug.Log(Vector2.up);
        Debug.Log(player.transform.position);
        jump = true;
    }
    
    
    private void FixedUpdate()
    {
        float horizontalInput = joystick.Horizontal;
        Vector2 movement = new Vector2(horizontalInput, 0f);
        rb.velocity = movement * moveSpeed;

    }

}