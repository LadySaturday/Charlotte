using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastFlashlight : MonoBehaviour
{
    private int count = 0;
    void FixedUpdate()
    {
        if (count < 1)
        {      
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, fwd, out hit, 7))
            {
                
                if (hit.collider.name == "SafeCode")
                {
                    Debug.Log(hit.collider.name);
                    PickUpTrigger.SafeCode = true;
                    count++;

                    PickUpTrigger.hint = "That must be a code...";
                
                }
                    
            }
        }

    }
}
