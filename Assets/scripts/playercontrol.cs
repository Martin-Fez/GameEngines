using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour
{

    public float force;
    public Rigidbody playerRB;
    public GUIStyle mystyle;
    public GameObject obstaclesCollisionEffect;

    public float health;
    public float highPoint;
    public bool goingDown;
    public float damage;

    public Vector3 startPostition;

    // Start is called before the first frame update
    void Start()
    {
        mystyle.normal.textColor = Color.white;
        mystyle.fontSize = 16;
        startPostition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            force += 20 * Time.deltaTime;
        }

        if(Input.GetMouseButtonUp(0))
        {
            // this will transform mouse position from screen location to 3d world location
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Debug.Log(mousePos);
            //direction from the mouse to the player is calculated using B-A vector locations
            Vector3 dir = (mousePos - transform.position).normalized;

            if(dir.y < 0)
            {
                dir *= -1;
            }

            Launch(force, dir);

        }

        // let's check every frame when the ball starts to come down
        if (playerRB.velocity.y < -0.01 && goingDown == false)
        {
            // this is the frame the balls starts falling
            GetComponent<Renderer>().material.color = Color.red;
            goingDown = true;
            highPoint = transform.position.y;
        }

    }



    void Launch(float forceAmt, Vector3 forceDir) 
    {
        //playerRB.AddForce(Vector3.up * forceAmt, ForceMode.Impulse);
        GetComponent<Renderer>().material.color = Color.white;
        playerRB.AddForce(forceDir * forceAmt, ForceMode.Impulse);
        force = 0;
        goingDown = false;
    }

    private void OnCollisionEnter(Collision collision) // part of unity, adding extra code to what happens once you hit
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Hit a plotform,  taking damge :)");
            if (goingDown == true)
            {
                damage = Mathf.Sqrt(2f * Mathf.Abs(Physics.gravity.y)) * Mathf.Abs( highPoint - transform.position.y);
                TakeDamage(damage);
            }
        }

        if(collision.gameObject.CompareTag("Obstacle"))
        {
            // if player object is colliding with an object that has a tag "obstacle" on it.
            // Instansiate the particle effect
            GameObject obsEffect = Instantiate(obstaclesCollisionEffect, transform.position, Quaternion.identity);
            Destroy(obsEffect, 3);

            TakeDamage(20);
        }

        if (collision.gameObject.CompareTag("LevelEnd"))
        {
            // This is run if player hits Level End.
            // Read NextLevel value from Level End Object's end script and open a scene named that.
            SceneManager.LoadScene(collision.gameObject.GetComponent<levelEnd>().nextLevel); // put code that get NextLevel string value from collission object's Level End component

        }
    }

    void TakeDamage(float dmgTaken)
    {
        health -= dmgTaken;
        if(health < 0)
        {
            Die();
        }
    }

    void Die()
    {
        // :)
        
        transform.position = startPostition;
        health = 100;

        playerRB.velocity = Vector3.zero;
        // let's go all though platforms and reset them
        GameObject[] allPlatforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach(GameObject singlePlatforms in allPlatforms)
        {
            singlePlatforms.layer = LayerMask.NameToLayer("Platform inactive");
            //singlePlatforms.GetComponent<Renderer>().material.color = Color.white;

        }



    }

    private void OnGUI()
    {
        // this is just for debugging
        GUI.Label(new Rect(10, 10, 200, 20), "Force: " + force,mystyle);
        GUI.Label(new Rect(10, 30, 200, 20), "High point: " + highPoint,mystyle);
        GUI.Label(new Rect(10, 50, 200, 20), "Going down: " + goingDown,mystyle);
        GUI.Label(new Rect(10, 70, 200, 20), "damage: " + damage,mystyle);
        GUI.Label(new Rect(10, 90, 200, 20), "Health: " + health,mystyle);
        GUI.Label(new Rect(10, 110, 200, 20), "velocity y: " + playerRB.velocity.y,mystyle);

    }
}
