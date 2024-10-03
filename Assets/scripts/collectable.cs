using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            gameObject.SetActive(false);
            if (CompareTag("health"))
            {
                collision.gameObject.GetComponent<PlayerControl2D>().health += 10;
            }

            if (CompareTag("Grow")) 
            {
                collision.gameObject.transform.localScale *= 2;
            }

            if (CompareTag("Shrink"))
            {
                collision.gameObject.transform.localScale /= 2;

            }

            if (CompareTag("Gravity"))
            {
                Physics2D.gravity = new Vector2(0,-15);
            }


    
            }
        }

}
