using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class Character : Agent
{
    public float force = 15f;
    public Transform posison = null;

    private Rigidbody rigidbody = null;
    
    //private bool hitcollisin = false;
    // start
    public override void Initialize()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    //wat er moet gebeuren bij elke episode
    public override void OnEpisodeBegin()
    {
        ResetCharacter();
    }
    //wat er moet gebeuren bij elke action
    public override void OnActionReceived(float[] vectorAction)
    {
        if(vectorAction[0] == 1)
        {
            Thrust();
            
        }
    }

    //wat er gedaan wordt bij elke action
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0;
        if(Input.GetKey(KeyCode.UpArrow) == true)
        {
            actionsOut[0] = 1;
            AddReward(-0.001f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "obstacle")
        {
            AddReward(-1.0f);
            Destroy(collision.gameObject);
            EndEpisode();
        }else if(collision.collider.tag == "wall")
        {
            AddReward(-0.1f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "wallreward")
        {
            AddReward(0.5f);
        }
    }
    //de posison van character terug zetten
    private void ResetCharacter()
    {
        this.transform.position = new Vector3(posison.position.x, posison.position.y, posison.position.z);
    }
    //de character laten springen
    private void Thrust()
    {
        rigidbody.AddForce(Vector3.up * force, ForceMode.Acceleration);
    }
}
