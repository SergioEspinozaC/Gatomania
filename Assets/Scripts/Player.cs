using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    public float pushForce = 10f;
    public bool tool = false;
    public bool toolGrab = false;

    private Vector2 direction;
    private Rigidbody2D rigidBody;
    private GameObject insideHouse;
    private GameObject axe;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            direction.y = 0;
        }
        else
        {
            direction.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.Z) && insideHouse)
        {
            transform.position = insideHouse.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Z) && tool)
        {
            axe.gameObject.SetActive(false);
            Debug.Log("tiene el hacha : " + tool);
            toolGrab = true;
        }
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + direction * velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "DoorA" || collider.name == "DoorB")
        {
            GameObject warp = collider.transform.parent.gameObject;
            if (collider.name == "DoorA")
            {
                insideHouse = warp.transform.Find("DoorB").gameObject;
            }
            else
            {
                insideHouse = warp.transform.Find("DoorA").gameObject;
            }
        }

        if(collider.name == "Axe")
        {
            
            tool = true;
            axe = collider.gameObject;
            Debug.Log("tiene el hacha : " + tool + axe);

        }
        

    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.name == "DoorA" || collider.name == "DoorB")
        {
            insideHouse = null;
        }
         if(collider.name == "Axe")
        {
            
            tool = false;
            axe = null;
            Debug.Log("NO tiene el hacha : " + tool + axe);

        }
    }

}