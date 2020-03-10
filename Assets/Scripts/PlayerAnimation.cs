using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
   
    private int initialStand=0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (initialStand < 1)
            {
                initialStand++;
                anim.SetBool("Stand",true);
                //rb.transform.rotation = Quaternion.identity;
                //rb.constraints = RigidbodyConstraints.FreezeAll;
                
               // gameObject.GetComponent<Animator>().enabled = false;
            }
            
        }
    }
}
