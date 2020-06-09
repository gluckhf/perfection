using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FollowPathNodes : MonoBehaviour
{
    public GameObject[] PathNode;
    public Rigidbody2D myRigidbody2D;
    public Transform myTransform;

    public float forceMagnitude;
    public float forceBrakingFactor;

    public float torqueMagnitude;
    public float torqueBrakingFactor;

    public int nextNode = 1;
    public float nodeCloseDistance;

    // Update is called once per frame
    void Update()
    {
        Vector3 directionVector = PathNode[nextNode].transform.position - myTransform.position;
        Vector3 normalizedVector = directionVector.normalized;

        myRigidbody2D.velocity = myRigidbody2D.velocity * forceBrakingFactor;
        myRigidbody2D.AddForce(normalizedVector * forceMagnitude);


        float angleDifference = Vector3.SignedAngle(myRigidbody2D.transform.right, directionVector, Vector3.forward);
        myRigidbody2D.angularVelocity = myRigidbody2D.angularVelocity * torqueBrakingFactor;
        myRigidbody2D.AddTorque(angleDifference * torqueMagnitude);

        if(directionVector.magnitude < nodeCloseDistance)
        {
            if(++nextNode >= PathNode.Count())
            {
                Destroy(this.gameObject);
            }
        }
    }
}
