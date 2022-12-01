using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SystemValues : ScriptableObject
{
    private Camera MainCamera;
    private Vector2 screenBounds;

    public Vector3 minWorldCoords;
    public Vector3 maxWorldCoords;
    public float cameraZPos;

    // Calculate min and max world coordinates based off screen
    // aka converts screen to world point
    // world coords: (0, 0) is in the centre of the screen (if the camera hasnt been moved)
    // screen coords: (0, 0) is the bottom left of the screen
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        minWorldCoords = new Vector3(-screenBounds.x, -screenBounds.y, MainCamera.transform.position.z);
        maxWorldCoords = new Vector3(screenBounds.x, screenBounds.y, MainCamera.transform.position.z);

        cameraZPos = MainCamera.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
