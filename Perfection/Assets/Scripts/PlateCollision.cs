using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Plate collision with " + collision.gameObject.name);
        Destroy(this.gameObject);
    }
}
