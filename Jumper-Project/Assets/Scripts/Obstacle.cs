using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 10f;
    //private Character character;

    private bool hit = false;

    private void Update()
    {
        
        Move();
        
    }

    private void Move()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "end")
        {
            hit = true;
            Destroy(gameObject);
           //character = character.HitCollider(hit);
            

        }
        
    }
}
