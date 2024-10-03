using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public GameObject player; // our player in the scene


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //check every frame if the player is higher than this game object then change this
        // game object layer to active layer
        if (transform.position.y < player.transform.position.y - transform.localScale.y - player.transform.localScale.y/2)
        {
            // change layer and the color of the platform
            gameObject.layer = LayerMask.NameToLayer("Platform active");
            GetComponent<Renderer>().material.color = Color.cyan;
        }

    }


}
