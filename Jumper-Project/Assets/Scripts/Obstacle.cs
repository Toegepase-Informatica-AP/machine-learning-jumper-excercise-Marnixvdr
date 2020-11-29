using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed;
    //private Character character;

    private bool hit = false;

    private void Update()
    {
        
        Move();
        
    }

    private void Move()
    {
        speed = Random.Range(1f, 15f);
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
