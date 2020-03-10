using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Flashlight : MonoBehaviour
{
  
    public static bool hasLight = false;
    public static bool flashlight_On = false;
    public GameObject flashlight;


    // Update is called once per frame
    void Update()
    {
        if (hasLight)
        {

        
            if (flashlight_On)
            {
                
                flashlight.SetActive(true);
            }
            else
            {
               // Debug.Log("Flash off");
                flashlight.SetActive(false);
            }
        }

    }
}
