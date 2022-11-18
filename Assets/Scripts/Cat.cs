using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    // Start is called before the first frame update*/

    public GameObject[] cats;
    public GameObject cage;

    public bool key_1;
    public bool key_2;
    public bool key_3;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (key_1 && key_2 && key_3 && Input.GetKeyDown(KeyCode.Z))
        {
            cage.gameObject.SetActive(false);
            for (int i = 0; i < 4; i++)
            {
                cats[i].gameObject.SetActive(true);
            }
            
        }
       
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();

        if (player != null)
        {
            key_1 = player.keyGrab;
            key_2 = player.keyGrab_1;
            key_3 = player.keyGrab_2;
        }
    }

}
