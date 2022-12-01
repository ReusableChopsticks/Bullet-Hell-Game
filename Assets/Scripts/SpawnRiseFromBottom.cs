using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRiseFromBottom : MonoBehaviour
{
    // Start is called before the first frame update

    public System.Random rng;
    public SystemValues sysVals;

    [Range(0.0f, 5.0f)]
    public float moveTime;
    
    private Vector3 velocity = Vector3.zero;

    private float ranX;
    private float ranY;
    private Vector3 targetPos;

    void Start()
    {
        // calculate a random target point to rise up to
        //ranX = (float)(sysVals.rng.NextDouble() * (sysVals.maxWorldCoords.x - sysVals.minWorldCoords.x) + sysVals.minWorldCoords.x);
        //ranY = (float)(sysVals.rng.NextDouble() * (sysVals.maxWorldCoords.y - sysVals.minWorldCoords.y) + sysVals.minWorldCoords.y);

        // stupid way of waiting for thing to update?
        while (sysVals.maxWorldCoords.x == 0 || sysVals.minWorldCoords.y == 0)
        { } // do nothing

        ranX = Random.Range(sysVals.minWorldCoords.x, sysVals.maxWorldCoords.x);
        ranY = Random.Range(sysVals.minWorldCoords.y, sysVals.maxWorldCoords.y);

        Debug.Log(string.Format("min x: {0}", sysVals.minWorldCoords.x));
        Debug.Log(string.Format("max x: {0}", sysVals.maxWorldCoords.x));

        //spawn it just below visible part of screen
        gameObject.transform.position = new Vector3(ranX, sysVals.minWorldCoords.y - gameObject.GetComponent<SpriteRenderer>().bounds.size.y, sysVals.cameraZPos);
        targetPos = new Vector3(ranX, ranY, sysVals.cameraZPos);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, moveTime);
    }

    
}
