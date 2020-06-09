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
            targetPoint.z = 0;
            Vector3 directionVector = (targetPoint - spawnPoint.position).normalized;
            Debug.Log("Spawning bullet targeting " + targetPoint.ToString() + " from " + spawnPoint.position + ", vector " + directionVector.ToString());

            Vector3 spawnOffset = directionVector * spawnDistance;

            var spawnedBullet = Instantiate(bullet, spawnPoint.position + spawnOffset, spawnPoint.rotation);
            spawnedBullet.GetComponent<Rigidbody2D>().AddForce(directionVector * bulletForce);
        }
    }
}
