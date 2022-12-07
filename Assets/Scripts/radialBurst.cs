using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radialBurst : MonoBehaviour
{
    public GameObject bullet;
    
    private SpawnRiseFromBottom spawnScript;

    [Range(0.0f, 10.0f)]
    public float bulletSpeed;
    [Range(0.0f, 2 * Mathf.PI)]
    public float rotateSpeed;
    public int bulletAmount;
    public float fireInterval;
    
    [Range(0.0f, 10.0f)]
    public float attackDuration;
    float currAttackTime = 0;

    [Range(0.0f, 5.0f)]
    public float exitTime = 3;
    float currExitTime = 0;
    
    float currTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        currTime = 0;
        spawnScript = gameObject.GetComponent<SpawnRiseFromBottom>();
    }

    private void Fire()
    {
        float increment = (2 * Mathf.PI) / bulletAmount;
        float currAngle = 0f;

        for (int i = 0; i < bulletAmount; i++)
        {
            Bullet bulletScript = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Bullet>();
            Vector3 target = new Vector3(Mathf.Cos(currAngle), Mathf.Sin(currAngle), 0);
            target = transform.rotation * target;
            target *= 50;
            bulletScript.SetTarget(target);
            bulletScript.speed = bulletSpeed;
            currAngle += increment;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        currAttackTime += Time.deltaTime;

        if (currTime > fireInterval & currAttackTime < attackDuration)
        {
            Fire();
            currTime = 0;
        }

        if (currAttackTime > attackDuration)
        {
            spawnScript.enabled = false;
            exitScreen();
        }

        //transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
        transform.Rotate(0, 0, rotateSpeed, Space.Self);
    }

    private void exitScreen()
    {
        currExitTime += Time.deltaTime;
        if (currExitTime < exitTime) // ease flower down back to starting pos, out of view
        {
            //float interpolate = Mathf.Pow(2f, (1/exitTime) * currExitTime) - 1;
            float interpolate = Mathf.Pow((1/exitTime) * currExitTime, 5);
            transform.position = Vector3.Lerp(spawnScript.targetPos, spawnScript.initialPos, interpolate);
            Debug.Log(interpolate);
        } else
        {
            // everything is finished. suicide.
            Destroy(gameObject);
            
        }



    }
}
