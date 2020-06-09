﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Despawner collision with " + collision.gameObject.name);
        Destroy(collision.gameObject);
    }
}
