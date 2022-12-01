using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    public float speed {
        get { return _speed; }
        set { 
            if (value < 0) {
                _speed = 1;
            } 
            else {
                _speed = value; } // no negative speeds. default speed of 1
            }
    }

    //public ManageHealth healthManager;
    public Player player;
    private Vector3 target;
    


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7); //destroy self after amount of time

        //healthManager = healthManager.GetComponent<ManageHealth>(); //is this even needed?
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.health -= 1;
        Destroy(gameObject);
    }
    */

    void DestroyIfOutOfBounds()
    {
        
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }
}
