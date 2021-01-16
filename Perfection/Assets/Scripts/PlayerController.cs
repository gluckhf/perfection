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
        Vector2 velocity = Time.deltaTime * (BoostSpeed + new Vector2(Input.GetAxis(HorizontalAxis) * Speed, Input.GetAxis(VerticalAxis) * Speed));

        // Raycast the movement to make sure the player doesn't clip through objects while moving quickly
        RaycastHit2D hit = Physics2D.Raycast(currentPosition, velocity.normalized, velocity.magnitude);
        Debug.DrawLine(currentPosition, currentPosition + velocity, Color.red, 0.2f, false);

        if (hit && hit.collider.gameObject != this.gameObject)
        {
            // Move it to where it collided
            transform.position = hit.point;
        }
        else
        {
            // Move the entire way
            transform.position = currentPosition + velocity;
        }
    }

    void Boost()
    {
        if (!Boosting)
        {
            if (Input.GetButtonDown(DashButton))
            {
                Boosting = true;
                BoostSpeed = new Vector2(Input.GetAxis(HorizontalAxis), Input.GetAxis(VerticalAxis)) * BoostSpeedMax;
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
