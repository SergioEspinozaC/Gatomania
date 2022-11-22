using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cage : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject continuar;
    GameObject cage_1;
    GameObject cage_2;
    GameObject cage_3;
    public Text dialogueText;
    public string dialogue;

    private int cajasActivas = 0;
    private bool allOpen = false;

    // Start is called before the first frame update
    void Start()
    {
         cage_1 = GameObject.Find("Cage");
         cage_2 = GameObject.Find("Cage_2");
         cage_3 = GameObject.Find("Cage_3");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(cajasActivas == 3 && !allOpen)
        {
            allOpen = true;
            dialoguePanel.SetActive(true);
            dialogue = "Has liberado todos los gatos";
            dialogueText.text = dialogue;
        }
    }

    public void OpenCage()
    { 
        cajasActivas += 1;
        dialoguePanel.SetActive(true);
        dialogue = "Has liberado " + cajasActivas + "/3 jaulas";
        dialogueText.text = dialogue;
    }

    public void ClosePanel()
    {
        dialoguePanel.SetActive(false);
    }
}
