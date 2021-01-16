using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    public float Speed;
    public float BoostSpeedMax;
    public string DashButton = "J1_A";
    public string HorizontalAxis = "J1_Horizontal";
    public string VerticalAxis = "J1_Vertical";
    
    
    private bool Boosting = false;
    private Vector3 BoostSpeed = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Boost();

        Vector3 velocity = BoostSpeed + new Vector3(Input.GetAxis(HorizontalAxis) * Speed, Input.GetAxis(VerticalAxis) * Speed, 0);
        transform.position += velocity * Time.deltaTime;
    }

    void Boost()
    {
        if (!Boosting)
        {
            if (Input.GetButtonDown(DashButton))
            {
                Boosting = true;
                BoostSpeed = new Vector3(Input.GetAxis(HorizontalAxis), Input.GetAxis(VerticalAxis), 0) * BoostSpeedMax;
            }
        }
        else
        {
            BoostSpeed *= (0.95f - Time.deltaTime);
            if(BoostSpeed.magnitude < BoostSpeedMax/2)
            {
                BoostSpeed *= 0f;
                Boosting = false;
            }
        }
    }
}
