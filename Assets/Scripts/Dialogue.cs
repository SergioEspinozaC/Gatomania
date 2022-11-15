using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject continuar;
    public GameObject npc;
    public GameObject key;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool isClose;

    public bool food;
    public bool keyGrabbed = true;
    

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == dialogue[index] && dialogueText.text != "")
        {
            continuar.SetActive(true);
        }

        
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        continuar.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            isClose = true;

        }

        Player player = collider.GetComponent<Player>();

        if (player != null)
        {
            food = player.tomatoGrab;
        }

        if (npc.name == "Carmen" && food)
        {
            Debug.Log("Encontre el dialogo");
            dialogue[0] = "¡Muchas gracias por los tomates!";
            dialogue[1] = "Te deje la llave sobre la mesa.";
            if (keyGrabbed)
            {
                key.SetActive(true);
                keyGrabbed = false;
            }
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            isClose = false;
            zeroText();
        }
    }


}
