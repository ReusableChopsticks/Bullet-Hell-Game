using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radialBurst : MonoBehaviour
{
    public GameObject bullet;
    [Range(0.0f, 10.0f)]
    public float bulletSpeed;
    [Range(0.0f, 2 * Mathf.PI)]
    public float rotateSpeed;
    public int bulletAmount;
    public float fireInterval;
    
    float currTime;

    // Start is called before the first frame update
    void Start()
    {
        currTime = 0;
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
        if (currTime > fireInterval)
        {
            Fire();
            currTime = 0;
        }

        //transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
        transform.Rotate(0, 0, rotateSpeed, Space.Self);
    }
}
