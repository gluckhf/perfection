using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulation : MonoBehaviour
{
    public string InteractButton = "J1_X";

    private void Update()
    {
        if (!Input.GetButton(InteractButton))
        {
            Component[] joints = gameObject.GetComponents<FixedJoint2D>() as Component[];
            foreach (Component joint in joints)
            {
                Destroy(joint as FixedJoint2D);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown(InteractButton) && collision.gameObject.GetComponent("Rigidbody2D"))
        {
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>() as FixedJoint2D;
            joint.connectedBody = (Rigidbody2D)collision.gameObject.GetComponent("Rigidbody2D");
            joint.enableCollision = false;
        }
    }
}
