using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRiseFromBottom : MonoBehaviour
{
    // Start is called before the first frame update

    public System.Random rng;
    public SystemValues sysVals;

    radialBurst attackScript;

    [Range(0.0f, 3.0f)]
    public float moveTime;

    float timeBeforeAttack;

    private Vector3 velocity = Vector3.zero;

    private float ranX;
    private float ranY;

    // these need to be public to be accessed by radialBursts
    [HideInInspector]
    public Vector3 targetPos;
    [HideInInspector]
    public Vector3 initialPos;


    void Start()
    {
        float extentsX = gameObject.GetComponent<SpriteRenderer>().bounds.extents.x;
        float extentsY = gameObject.GetComponent<SpriteRenderer>().bounds.extents.y;

        // disable attack first
        attackScript = gameObject.GetComponent<radialBurst>();
        attackScript.enabled = false;

        // attack will always start after finishing entry animation
        timeBeforeAttack = moveTime;
        
        // calculate a random target point to rise up to
        ranX = UnityEngine.Random.Range(sysVals.minWorldCoords.x + extentsX, sysVals.maxWorldCoords.x - extentsX);
        ranY = UnityEngine.Random.Range(sysVals.minWorldCoords.y + extentsY, sysVals.maxWorldCoords.y - extentsY);

        Debug.Log(string.Format("min x: {0}", sysVals.minWorldCoords.x));
        Debug.Log(string.Format("max x: {0}", sysVals.maxWorldCoords.x));

        //spawn it just below visible part of screen
        initialPos = new Vector3(ranX, sysVals.minWorldCoords.y - gameObject.GetComponent<SpriteRenderer>().bounds.size.y, transform.position.z);
        gameObject.transform.position = initialPos;
        targetPos = new Vector3(ranX, ranY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, moveTime);
        timeBeforeAttack -= Time.deltaTime;
        
        // after wind up time is finished, add the script for the attack
        if (timeBeforeAttack < 0)
        {
            attackScript.enabled = true;
        }
    }

    
}
