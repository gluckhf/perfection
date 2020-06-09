using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float spawnDistance;
    public float firingDelay_s;
    public float bulletForce;

    protected Vector3 targetPoint;

    private bool fire = false;
    private float delayTimer_s = 0;

    void Update()
    {
        delayTimer_s += Time.deltaTime;

        if (Input.GetButtonDown("Fire0"))
        {
            fire = true;
        }

        else if(Input.GetButtonUp("Fire0"))
        {
            fire = false;
        }

        if (fire && delayTimer_s > firingDelay_s)
        {
            delayTimer_s = 0;
            targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 directionVector = targetPoint - spawnPoint.position;
            Vector3 spawnOffset = directionVector.normalized * spawnDistance;

            var spawnedBullet = Instantiate(bullet, spawnPoint.position + spawnOffset, spawnPoint.rotation);
            spawnedBullet.GetComponent<Rigidbody2D>().AddForce(directionVector * bulletForce);
        }
    }
}
