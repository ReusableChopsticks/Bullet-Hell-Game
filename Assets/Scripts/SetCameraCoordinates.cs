using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraCoordinates : MonoBehaviour
{
    public SystemValues systemValues;
    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = gameObject.GetComponent<Camera>();
        Vector3 screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));
        systemValues.minWorldCoords = new Vector3(-screenBounds.x, -screenBounds.y, mainCam.transform.position.z);
        systemValues.maxWorldCoords = new Vector3(screenBounds.x, screenBounds.y, mainCam.transform.position.z);

        systemValues.cameraZPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

