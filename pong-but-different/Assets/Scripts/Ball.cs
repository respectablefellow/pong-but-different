using UnityEngine;
//Script for the Ball Movement. 
public class Ball : MonoBehaviour
{
    //The starting Speed of the Ball in the beginning
    private float speed = 200.0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ResetPosition();
        AddStartingForce();
    }

    public void ResetPosition()
    {
        rb.position = Vector3.zero;
        rb.linearVelocity = Vector3.zero;
    }

    public void AddStartingForce()
    {
        //Randomises the start direction
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        //Randomises the start angle
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) :
                                        Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        rb.AddForce(direction * this.speed);  
    }

    //Used to access the rigidbody of the ball without making it public
    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }


}


