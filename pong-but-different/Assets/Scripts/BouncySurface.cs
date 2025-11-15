using UnityEngine;
//Used to change the speed of the ball when it collides with certain Surfaces
public class BouncySurface : MonoBehaviour
{
    public float bounceStrength;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>(); 
        if(ball != null) //If ball was the Object that colided with the surface
        {
            Vector2 normal = collision.GetContact(0).normal; //Vector pointing away from the surface at that point
            ball.AddForce(-normal * this.bounceStrength);
        }
    }
}
