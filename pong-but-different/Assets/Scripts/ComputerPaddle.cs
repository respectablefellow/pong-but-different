using UnityEngine;

//ComputerPaddle Movement script. When the ball comes towards this paddle,
//it moves depending on the position of it and when the ball gets away,
//the computer comes back to the middle.
public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;

    private void FixedUpdate()
    {
        if (this.ball.linearVelocity.x > 0.0f) //If ball is moving towards ComputerPaddle
        {
            if (this.ball.position.y > this.transform.position.y) //If the ball position is above our paddle, move up
            {
                rb.AddForce(Vector2.up * this.speed);
            }
            else if (this.ball.position.y < this.transform.position.x) //If ball is below paddle, move down
            {
                rb.AddForce(Vector2.down * this.speed);
            }
        } 
        else //When ball moves away
        {
            if (this.transform.position.y > 0.0f)
            {
                rb.AddForce(Vector2.down * this.speed);
            }
            else if(this.transform.position.y < 0.0f)
            {
               rb.AddForce(Vector2.up * this.speed);
            } 
        }
    }
}
