using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCollision : MonoBehaviour
{
    public float lossOnHit;
    public SpriteRenderer mySpriteRenderer;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            float newAlpha = Mathf.Max(mySpriteRenderer.color.a - lossOnHit, 0f);

            if (newAlpha == 0f)
            {
                Destroy(this.gameObject);
            }
            else
            {
                mySpriteRenderer.color = new Color(mySpriteRenderer.color.r, mySpriteRenderer.color.g, mySpriteRenderer.color.b, newAlpha);
            }
        }
    }
}
