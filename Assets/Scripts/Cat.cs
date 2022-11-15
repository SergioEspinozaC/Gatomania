using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    private GameObject catPosition;
    public GameObject cage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && catPosition)
        {
            transform.position = catPosition.transform.position;
            Debug.Log("deberia teletransportarse pero no lo hago");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "PointA" || collider.name == "PointB")
        {
            GameObject warp = collider.transform.parent.gameObject;
            if (collider.name == "PointA")
            {
                catPosition = warp.transform.Find("PointB").gameObject;
            }
            else
            {
                catPosition = warp.transform.Find("PointA").gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.name == "PointA" || collider.name == "PointB")
        {
            catPosition = null;
        }
    }

    }
