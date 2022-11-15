using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    public float pushForce = 10f;
    public bool tool = false;
    public bool toolGrab = false;
    public bool tomato = false;
    public bool tomatoGrab = false;
    public bool keyCollision = false;
    public bool keyGrab = false;
    public bool keyCollision_1 = false;
    public bool keyGrab_1 = false;
    public bool keyCollision_2 = false;
    public bool keyGrab_2 = false;

    private Vector2 direction;
    private Rigidbody2D rigidBody;
    private GameObject insideHouse;
    private GameObject axe;
    private GameObject food;
    private GameObject key;
    private GameObject key_1;
    private GameObject key_2;
    private float movimientoX;
    private float movimientoY;
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        /*
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
*/

        movimientoX = Input.GetAxisRaw("Horizontal");
        movimientoY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("MovimientoX", movimientoX);
        animator.SetFloat("MovimientoY", movimientoY);
        if (movimientoX != 0 || movimientoY != 0)
        {
            animator.SetFloat("UltimoX", movimientoX);
            animator.SetFloat("UltimoY", movimientoY);
        }

        direction = new Vector2(movimientoX, movimientoY).normalized;

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

        if (Input.GetKeyDown(KeyCode.Z) && tomato)
        {
            food.gameObject.SetActive(false);
            Debug.Log("tiene el tomato : " + tomato);
            tomatoGrab = true;
        }

        if (Input.GetKeyDown(KeyCode.Z) && keyCollision)
        {
            key.gameObject.SetActive(false);
            Debug.Log("tiene la llave");
            keyGrab = true;
        }

        if (Input.GetKeyDown(KeyCode.Z) && keyCollision_1)
        {
            key_1.gameObject.SetActive(false);
            Debug.Log("tiene la llave");
            keyGrab_1 = true;
        }

        if (Input.GetKeyDown(KeyCode.Z) && keyCollision_2)
        {
            key_2.gameObject.SetActive(false);
            Debug.Log("tiene la llave");
            keyGrab_2 = true;
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

        if (collider.name == "Axe")
        {

            tool = true;
            axe = collider.gameObject;

        }

        if (collider.name == "Tomato")
        {
            tomato = true;
            food = collider.gameObject;
        }

        if(collider.name == "Key")
        {
            keyCollision = true;
            key = collider.gameObject;
        }

        if (collider.name == "Key_1")
        {
            keyCollision = true;
            key = collider.gameObject;
        }

        if (collider.name == "Key_2")
        {
            keyCollision = true;
            key = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.name == "DoorA" || collider.name == "DoorB")
        {
            insideHouse = null;
        }

        if (collider.name == "Axe")
        {
            tool = false;
            axe = null;
        }

        if (collider.name == "Tomato")
        {
            tomato = false;
            food = null;
        }

        if (collider.name == "Key")
        {
            keyCollision = false;
            key = null;
        }

        if (collider.name == "Key_1")
        {
            keyCollision = false;
            key = null;
        }

        if (collider.name == "Key_2")
        {
            keyCollision = false;
            key = null;
        }
    }

}