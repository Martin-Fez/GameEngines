using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Portal : MonoBehaviour
{

    public string connectingPortal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if(!collision.gameObject.GetComponent<PlayerControl2D>().teleported)
            {
                GameObject portal = GameObject.Find(connectingPortal);
                collision.gameObject.transform.position = portal.transform.position;
                collision.gameObject.GetComponent<PlayerControl2D>().teleported = true;
                //new WaitForSecondsRealtime(5);
                //new WaitForSeconds(5);
            }
            else
            {
                collision.gameObject.GetComponent<PlayerControl2D>().teleported = false;
            }




        }
    }

}
