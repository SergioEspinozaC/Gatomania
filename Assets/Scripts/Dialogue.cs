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
    public GameObject cage_1;
    public GameObject cage_2;
    public GameObject cage_3;
    

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
            dialogue[0] = "¡Muchas gracias por los tomates!";
            dialogue[1] = "Te deje la llave sobre la mesa.";
            if (keyGrabbed)
            {
                key.SetActive(true);
                keyGrabbed = false;
            }
            
        }
         if (npc.name == "Melissa" && cage_1.activeInHierarchy==false && cage_2.activeInHierarchy==false && cage_3.activeInHierarchy==false)
        {
            dialogue[0] = "Ese señor se fue corriendo de aquí.";
            dialogue[1] = "Ahora podré ir a recorrer la cueva."; 
        }

         if (npc.name == "Billy" && cage_1.activeInHierarchy==false )
        {
            dialogue[0] = "¡Mi gatito está de vuelta!";
            dialogue[1] = "Gracias por ayudarme, señor.";
        }
        
         if (npc.name == "Darwin" && cage_1.activeInHierarchy==false )
        {
            dialogue[0] = "¡Regresó Gumball a casa!";
            dialogue[1] = "Estoy tan feliz, te compraré todo el atún que quieras.";
        }

         if (npc.name == "Betty" && cage_3.activeInHierarchy==false)
        {
            dialogue[0] = "Mi vecino llegó apurado y salió con muchas maletas.";
            dialogue[1] = "No sé que habrá pasado pero me alegro que mi gatito volviera.";
            
        }
        if (npc.name == "Jessica" && cage_2.activeInHierarchy==false)
        {
            dialogue[0] = "Ahora que Fluffy regresó, no lo dejaré salir nunca más.";
            dialogue[1] = "¡Ven Fluffy, quédate cerca mío!";
        }
        if (npc.name == "Esmeralda" && cage_3.activeInHierarchy==false)
        {
            dialogue[0] = "Me alegro que mi esposo encontrara el gato cerca de la huerta.";
            dialogue[1] = "Por cierto, ¿Te gustaron los tomates que te llevaste?";
        }
        if (npc.name == "Coronel" && cage_1.activeInHierarchy==false && cage_2.activeInHierarchy==false && cage_3.activeInHierarchy==false)
        {
            dialogue[0] = "¡Bienvenido a Pueblo Persa!";
            dialogue[1] = "La población de gatos ha vuelto a la normalidad.";
        }
         if (npc.name == "Karen" && cage_2.activeInHierarchy==false)
        {
            dialogue[0] = "¿Sabes quién estaba detrás del robo de los gatos...?";
            dialogue[1] = "LO SABÍA, mis sospechas eran correctas.";
        }
         if (npc.name == "Steve" && cage_2.activeInHierarchy==false)
        {
            dialogue[0] = "Carmen me dijo que la ayudaste con su receta.";
            dialogue[1] = "La sopa estaba deliciosa.";
        }
         if (npc.name == "Emma" && cage_2.activeInHierarchy==false)
        {
            dialogue[0] = "¡MI MISHI ESTÁ DE VUELTA!";
            dialogue[1] = "Iré a jugar con él.";
        }
        if (npc.name == "Flor" && cage_3.activeInHierarchy==false)
        {
            dialogue[0] = "Parece que Kiwi no tiene ningun rasguño.";
            dialogue[1] = "Me alegro, porque puede ser muy agresivo con otros gatos.";
        }
         if (npc.name == "McDonald" && cage_1.activeInHierarchy==false && cage_2.activeInHierarchy==false && cage_3.activeInHierarchy==false)
        {
            dialogue[0] = "Veo que todavía tienes el hacha.";
            dialogue[1] = "Me alegra que le estés dando un buen uso.";
        }
         if (npc.name == "Edwin" && cage_1.activeInHierarchy==false )
        {
            dialogue[0] = "Mi gato está sano y salvo.";
            dialogue[1] = "Gracias por ayudarme a encontrarlo, vecino.";
        }
        if (npc.name == "Laura" && cage_1.activeInHierarchy==false)
        {
            dialogue[0] = "ESTÁS TODO SUCIO.";
            dialogue[1] = "TENDRÉ QUE LLEVARTE A UNA ESTÉTICA PARA QUE TE BAÑEN.";
        }
         if (npc.name == "Roberto" && cage_3.activeInHierarchy==false)
        {
            dialogue[0] = "Parece que los gatos están de vuelta.";
            dialogue[1] = "Me pregunto si tendrá algo que ver con el señor del sombrero.";
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
