using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateLevel1 : MonoBehaviour
{ 

    //Rotation Value
    float rotX=90;
    float rotY;
    // Update is called once per frame
    void Update()
    {

        rotX += Input.GetAxis("Mouse X") * 2;
        rotY += Input.GetAxis("Mouse Y") * 2;
        rotY = Mathf.Clamp(rotY, -45, 35);

        rotX = Mathf.Clamp(rotX, 5, 175);
        // transform.rotation = Quaternion.Euler(-rotY, 0f, 0f);
        transform.rotation = Quaternion.Euler(-rotY, rotX, 0f);
    }
}
