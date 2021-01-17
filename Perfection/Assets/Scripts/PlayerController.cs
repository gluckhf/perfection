using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float Speed;
    public float Torque;
    public float BoostSpeedMultiplier;
    public string DashButton = "J1_A";
    public string HorizontalAxis = "J1_Horizontal";
    public string VerticalAxis = "J1_Vertical";

    public float BodyAngle;
    public float TargetAngle;
    public float Diff;
    public float Diff2;

    private Rigidbody2D body;
    private bool Boosting = false;
    private Vector2 BoostSpeed = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Boost();

        Vector2 currentPosition = transform.position;
        body.AddForce(body.mass * Time.deltaTime * (BoostSpeed + new Vector2(Input.GetAxis(HorizontalAxis) * Speed, Input.GetAxis(VerticalAxis) * Speed)));
        if (body.velocity.magnitude > 0.5)
        {
            BodyAngle = body.rotation;
            Diff = Vector2.SignedAngle(Vector2.right, body.velocity) - BodyAngle;

            Vector2 BodyAngleAsVector = (Vector2)(Quaternion.Euler(0, 0, BodyAngle) * Vector2.right);
            Diff2 = Vector2.SignedAngle(BodyAngleAsVector, body.velocity);

            body.AddTorque(Torque * Time.deltaTime * Diff2, ForceMode2D.Impulse);
        }
    }

    void Boost()
    {
        if (!Boosting)
        {
            if (Input.GetButtonDown(DashButton))
            {
                Boosting = true;
                BoostSpeed = new Vector2(Input.GetAxis(HorizontalAxis), Input.GetAxis(VerticalAxis)) * BoostSpeedMultiplier * Speed;
            }
        }
        else
        {
            BoostSpeed *= (0.95f - Time.deltaTime);
            if(BoostSpeed.magnitude < (BoostSpeedMultiplier * Speed )/ 2)
            {
                BoostSpeed *= 0f;
                Boosting = false;
            }
        }
    }
}
