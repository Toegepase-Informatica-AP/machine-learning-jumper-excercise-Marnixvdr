using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class Character : Agent
{
    public float force = 15f;
    public Transform posison = null;

    private Rigidbody rigidbody = null;

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
            Debug.Log("je springt");
        }
    }

    //wat er gedaan wordt bij elke action
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0;
        if(Input.GetKey(KeyCode.UpArrow) == true)
        {
            actionsOut[0] = 1;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "obstacle")
        {
            Destroy(collision.gameObject);
        }
    }

    //de posison van character terug zetten
    private void ResetCharacter()
    {
        this.transform.position = new Vector3(posison.position.x, posison.position.y, posison.position.z);
    }
    //de cgaracter laten springen
    private void Thrust()
    {
        rigidbody.AddForce(Vector3.up * force, ForceMode.Acceleration);
    }
}
