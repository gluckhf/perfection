using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    public float Speed;
    public float BoostSpeedMultiplier;
    public string DashButton = "J1_A";
    public string HorizontalAxis = "J1_Horizontal";
    public string VerticalAxis = "J1_Vertical";
    
    
    private bool Boosting = false;
    private Vector2 BoostSpeed = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Boost();

        Vector2 currentPosition = transform.position;
        body.AddForce(body.mass * Time.deltaTime * (BoostSpeed + new Vector2(Input.GetAxis(HorizontalAxis) * Speed, Input.GetAxis(VerticalAxis) * Speed)));
        body.velocity /= 2;
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
