using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject dialogBox;
    //spublic GameObject textobject;
    public Text DialogText;
    //public string dialog;
    public bool playerinRange;
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && playerinRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                //textobject.active = false;
                DialogText.enabled = false;
            }
            else {
                dialogBox.SetActive(true);
                DialogText.enabled = true;
                //textobject.active =true;
                //DialogText.text=dialog;
                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            playerinRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            playerinRange = false;
            dialogBox.SetActive(false);
            //textobject.active=false;
        }
    }
}
