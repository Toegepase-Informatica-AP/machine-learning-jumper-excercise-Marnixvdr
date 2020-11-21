using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 10f;

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
            Destroy(gameObject);
            Debug.Log("we hit an object");
        }
        
    }
}
