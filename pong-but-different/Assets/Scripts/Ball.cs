using UnityEngine;
//Script for the Ball Movement. 
public class Ball : MonoBehaviour
{
    //The starting Speed of the Ball in the beginning
    private float speed = 200.0f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        AddStartingForce();
    }

    private void AddStartingForce()
    {
        //Randomises the start direction
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        //Randomises the start angle
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) :
                                        Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.speed);  
    }
}


