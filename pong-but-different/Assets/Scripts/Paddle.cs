using UnityEngine;

public class Paddle : MonoBehaviour
{
    public enum PaddleType {Player, Computer} //Aufzählung
    public PaddleType paddleType = PaddleType.Player; //speichert welche Steuerung das Paddle hat

    public float speed = 10f;
    private Rigidbody2D ball;

    private Rigidbody2D rb;
    private Vector2 direction;

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
    {//sqr.Magnitude = is it moving?
        if (paddleType == PaddleType.Player)
        {
            if (direction.sqrMagnitude != 0)
                rb.AddForce(direction * speed);
        }
        else if (paddleType == PaddleType.Computer)
        {
            HandleComputerMovement();
        }
    }

    private void HandleComputerMovement()
    {
        if (ball == null) return;

        if (ball.linearVelocity.x > 0.0f) //If ball is moving towards ComputerPaddle
        {
            if (ball.position.y > transform.position.y) //If the ball position is above our paddle, move up
            {
                rb.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < transform.position.x) //If ball is below paddle, move down
            {
                rb.AddForce(Vector2.down * speed);
            }
        }
        else //When ball moves away
        {
            if (transform.position.y > 0.0f)
            {
                rb.AddForce(Vector2.down * speed);
            }
            else if (transform.position.y < 0.0f)
            {
                rb.AddForce(Vector2.up * speed);
            }
        }
    }


    private void HandlePlayerInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    public void ResetPosition()
    {
        //rb.position = new Vector2(rb.position.x, 0f);
        rb.linearVelocity = Vector2.zero;
    }
}
 