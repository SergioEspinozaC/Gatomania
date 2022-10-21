using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool tool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tool && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
           // player.tool;
            Debug.Log(player.tool);
            tool = player.tool;
        }
    }

    public void Hit()
    {
        
        Destroy(gameObject);
        
    }
}
