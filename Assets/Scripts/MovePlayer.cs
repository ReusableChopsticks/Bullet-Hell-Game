using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public int speed;
    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    public ManageHealth healthManager;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Use this for initialization
    void Start(){
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2

        healthManager = healthManager.GetComponent<ManageHealth>();
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(gameObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed * Time.deltaTime);
        
        Vector3 viewPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        viewPos.z = 0;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        transform.position = viewPos;

        /* move this check to bullet.cs?
        if (cc2d.IsTouchingLayers(Physics2D.AllLayers))
        {
            healthManager.subtractHealth();
        }
        */
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        healthManager.subtractHealth();
        Destroy(collision.gameObject);
    }

}
