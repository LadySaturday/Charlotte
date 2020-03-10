using System;
using UnityEngine;
using UnityEngine.UI;


public class SafeOverlay : MonoBehaviour
{
    public Text safeText;
    private string text;
    public GameObject safeCam;
    public GameObject player;
    public GameObject key;
    public string safeCode = "196124";
    private void OnEnable()
    {
        Time.timeScale = 0f;
        player.SetActive(false);
        safeCam.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Cursor should be visible");
    }
    


    public void numPressed(int num)
    {
        if (num >= 0)
        {
            safeText.text += num.ToString();
        }
        else
        {
            Debug.Log("delete");

            text = safeText.text.Substring(0,safeText.text.Length-1);

                safeText.text = text;
            

            
        }


    }

    public void enter()
    {
        
        if (safeText.text == safeCode)
        {
            Time.timeScale = 1f;
            Debug.Log("YAAAAS");
            Cursor.visible = false;
            player.SetActive(true);
            safeCam.SetActive(false);
            //set open animation and instantiate the key
            GameObject [] triggers=GameObject.FindGameObjectsWithTag("Trigger");

            foreach(GameObject trigger in triggers)
            {
                Destroy(trigger);
            }
            GameObject.Find("Safe").GetComponent<Animator>().SetTrigger("Open");
            key.SetActive(true);
            gameObject.SetActive(false);

            
        }
        else
        {
            safeText.text = "";
        }
    }

    public void back()
    {
        Time.timeScale = 1f;
        player.SetActive(true);
        safeCam.SetActive(false);
        Cursor.visible = false;
        gameObject.SetActive(false);
    }
}