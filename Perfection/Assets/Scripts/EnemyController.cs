using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform platePath;
    public GameObject[] PathNode;
    private float delayTimer_s = 0;
    public float plateSpawnDelay_s = 1.4f;

    public GameObject plate;
    public Transform spawnPoint;

    void Awake()
    {
        // Construct the pathing nodes for the plate path
        PathNode = new GameObject[platePath.childCount];
        for (int i = 0; i < platePath.childCount; i++)
        {
            PathNode[i] = platePath.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        delayTimer_s += Time.deltaTime;
        if(delayTimer_s > plateSpawnDelay_s)
        {
            delayTimer_s = 0;
            var spawnedPlate = Instantiate(plate, spawnPoint.position, spawnPoint.rotation);
            spawnedPlate.GetComponent<FollowPathNodes>().PathNode = PathNode;
        }
    }
}
