using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightTrigger : MonoBehaviour
{
    private GameObject[] lights;
    private bool touching=false;
    private bool lightsOn=true;
    private GameObject player;
    public GameObject codeText;
    public GameObject textPanel;
    public Text hintText;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lights = GameObject.FindGameObjectsWithTag("Light");
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("LightOn", lightsOn);
        if (touching&&Input.GetKeyDown(KeyCode.E))
        {
            if (lightsOn)
            {
                lightsOn = false;
                foreach (GameObject light in lights)
                {
                    light.SetActive(false);
                }
                if (codeText != null)
                {
                    codeText.SetActive(true);
                }
            }
            else
            {
                lightsOn = true;
                foreach (GameObject light in lights)
                {
                    light.SetActive(true);
                }
                if (codeText != null)
                {
                    codeText.SetActive(false);
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hintText.text = "[E]";
            textPanel.SetActive(true);
            touching = true;
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        hintText.text = "";
        textPanel.SetActive(false);
        touching = false;
    }
}
