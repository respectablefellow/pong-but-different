using UnityEngine;

public class Paddle : MonoBehaviour
{
    public enum PaddleType {Player, Computer} //Aufzählung
    public PaddleType paddleType = PaddleType.Player; //speichert welche Steuerung das Paddle hat

    public float speed = 10f;
    public int sideDirection = 1;

    private Rigidbody2D ball;
    private Rigidbody2D rb;
    private Vector2 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
    }

    public void TogglePaddleType(PaddleType type)
    {
        paddleType = type;
    }

    private void Update()
    {
        if (paddleType == PaddleType.Player)
        {
            HandlePlayerInput();
        }
    }
    private void FixedUpdate()
    {
        if (moveDir.sqrMagnitude != 0) { 
                rb.AddForce(moveDir * speed);
        }
        else if (paddleType == PaddleType.Computer)
        {
            HandleComputerMovement();
        }
    }

    private void HandleComputerMovement()
    {
  
        if (ball == null) return;

        bool movingTowardComputer = ball.linearVelocity.x * sideDirection >= 0f;


        if (movingTowardComputer) 
        {
            if (ball.position.y > transform.position.y) //If the ball position is above paddle, move up
            {
                rb.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < transform.position.y) //If ball is below paddle, move down
            {
                rb.AddForce(Vector2.down * speed);
            }
        }
        else //When ball moves away
        {
            if (transform.position.y > -1f)
            {
                rb.AddForce(Vector2.down * speed);
            }
            else if (transform.position.y < -1f)
            {
                rb.AddForce(Vector2.up * speed);
            }
        }
    }


    private void HandlePlayerInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDir = Vector2.down;
        }
        else
        {
            moveDir = Vector2.zero;
        }
    }

    public void ResetPosition()
    {
        //rb.position = new Vector2(rb.position.x, 0f);
        rb.linearVelocity = Vector2.zero;
    }
}
 