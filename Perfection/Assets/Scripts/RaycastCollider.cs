using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCollider : MonoBehaviour
{
    
    public Transform myTransform;

    private Vector2 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 thisPosition = myTransform.position;
        Vector2 direction = thisPosition - lastPosition;

        RaycastHit2D hit = Physics2D.Raycast(lastPosition, direction.normalized, direction.magnitude);
        Debug.DrawLine(lastPosition, thisPosition, Color.red, 0.2f, false);

        if (hit && hit.collider.gameObject != this.gameObject)
        {
            // Move it back to where it collided
            myTransform.position = hit.point;
        }

        lastPosition = thisPosition;
    }
}
