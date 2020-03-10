using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PickUpTrigger : MonoBehaviour
{

    public GameObject textPanel;
    public Text hintText;
    GameObject parent;
    public static string hint;
    private bool pickup = false;
    private bool touching = false;
    public static bool SafeCode = false;
    public GameObject safeOverlay;

    private void Start()
    {
        try
        {
            parent = GameObject.Find(gameObject.transform.parent.name);
        }
        catch
        {
            //Object doesn't have parent. That's fine. Will execute other code later
        }
       
    }

    private void Update()
    {
        if(hint== "That must be a code...")
        {
            setTrue(hint);
            hint = "";
            Invoke("SetBlank", 3);
        }
        if (Input.GetKeyDown(KeyCode.E)&&touching)
        {
            setFalse();

            if (parent != null)
            {
                switch (parent.name)//check what object player just picked up and provide appropriate text
                {
                    case "Flashlight":
                        RigidbodyFirstPersonController.hasLight = true;
                        hint = "Press [F] to toggle flashlight";
                        setTrue(hint);
                        parent.SetActive(false);
                        Invoke("SetBlankDestroy", 3);//disappear text after 3 seconds
                        break;
                    case "SafeTrigger":
                        if (SafeCode)
                        {
                            hint = "I think I know the combo";
                            safeOverlay.SetActive(true);
                        }
                        else
                        {
                            hint = "I don't know the combo...";
                        }
                        
                        setTrue(hint);
                        Invoke("SetBlank", 3);//disappear text after 3 seconds
                        break;
                    case "Key":
                        hint = "I have the key!";
                        setTrue(hint);
                        RigidbodyFirstPersonController.hasKey = true;
                        parent.SetActive(false);
                        Invoke("SetBlank", 3);
                        break;
                    case "Door":
                        if (!RigidbodyFirstPersonController.hasKey)
                        {
                            hint = "It's locked. I don't have a key.";
                            setTrue(hint);
                            Invoke("SetBlank", 3);
                        }
                        else
                        {
                            parent.GetComponent<Animator>().SetTrigger("Open");
                            gameObject.SetActive(false);
                        }
                        
                        break;
                }
            }
            else
            {
                gameObject.SetActive(false);
            }

            
        }
    }

    private void SetBlank()
    {
        textPanel.SetActive(false);
        hintText.text = "";
    }

    private void SetBlankDestroy()
    {
        textPanel.SetActive(false);
        hintText.text = "";
        Destroy(parent);//destroy trigger
    }

    private void OnDestroy()
    {
        if (hintText != null)
        {
            hintText.text = "";
            textPanel.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Setting hint E");
            hint = "[E]";
            setTrue(hint);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            setFalse();
        }
    }

    private void setFalse()
    {
        hintText.text="";
        textPanel.SetActive(false);
        touching = false;
    }

    private void setTrue(string hint)
    {
        hintText.text=hint;
        textPanel.SetActive(true);
        touching = true;
    }
}
