using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    public float pushForce = 10f;

    private Vector2 direction;
    private Rigidbody2D rigidBody;
    private GameObject insideHouse;
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

    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.name == "DoorA" || collider.name == "DoorB")
        {
            insideHouse = null;
        }
    }

}
