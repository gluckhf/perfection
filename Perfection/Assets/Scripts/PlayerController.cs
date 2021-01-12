using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    public float Speed;
    public float BoostSpeedMax;
    protected bool Boosting = false;
    protected Vector3 BoostSpeed = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Boost();

        Vector3 velocity = BoostSpeed + new Vector3(Input.GetAxis("Horizontal") * Speed, Input.GetAxis("Vertical") * Speed, 0);
        transform.position += velocity * Time.deltaTime;
    }

    void Boost()
    {
        if (!Boosting)
        {
            if (Input.GetButtonDown("A"))
            {
                Boosting = true;
                BoostSpeed = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * BoostSpeedMax;
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
