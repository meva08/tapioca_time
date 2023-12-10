using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    Animator animator;   
    Rigidbody2D rigidbody2d; //store the Rigidbody and access it from anywhere inside your script.
    float horizontal; // refer to the player inputs
    float vertical;
    Vector2 lookDirection = new Vector2(1,0); // create Vector for lookdirection 
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // get components 

        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); // store player input values into variables
        vertical = Input.GetAxis("Vertical");
    
        Vector2 move = new Vector2(horizontal, vertical); //  you store the input amount in a Vector2 called move. 
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) // Check to see whether move.x or move.y isn’t equal to 0. 

        {
            lookDirection.Set(move.x, move.y);
            // If either x or y isn’t equal to 0 (player is moving) set look direction
            // If player stops moving (Move x and y are 0) lookDirection will remain as the value it was just before she stopped moving. 
            
            lookDirection.Normalize();
            // vector length is not important here, so normalize it to one
        }

        animator.SetFloat("Move X", lookDirection.x); // send values back to Animator component
        animator.SetFloat("Move Y", lookDirection.y);
       
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Station"));
            // Raycast is sent to see if it hits something
            if (hit.collider != null)
            {
                // depending on what it hit, call its function:

                NewBobaStation RBstation = hit.collider.GetComponent<NewBobaStation>();
                if (RBstation != null)
                {
                    RBstation.DisplayDialog();
                }
                PoppingBobaStation PBstation = hit.collider.GetComponent<PoppingBobaStation>();
                if (PBstation != null)
                {
                    PBstation.DisplayDialog();
                }
                BlackTeaStation BTstation = hit.collider.GetComponent<BlackTeaStation>();
                if (BTstation != null)
                {
                    BTstation.DisplayDialog();
                }
                ThaiTeaStation TTstation = hit.collider.GetComponent<ThaiTeaStation>();
                if (TTstation != null)
                {
                    TTstation.DisplayDialog();
                }
                WholeFridge WMstation = hit.collider.GetComponent<WholeFridge>();
                if (WMstation != null)
                {
                    WMstation.DisplayDialog();
                }
                SkimFridge SMstation = hit.collider.GetComponent<SkimFridge>();
                if (SMstation != null)
                {
                    SMstation.DisplayDialog();
                }
                Sink sink = hit.collider.GetComponent<Sink>();
                if (sink != null)
                {
                    sink.DisplayDialog();
                }
                BobaShakerGame game = hit.collider.GetComponent<BobaShakerGame>();
                if (game != null)
                {
                    game.hit = true;
                }
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
            }
        }


    }

    void FixedUpdate() // instead of the unstable Update, based on frame rate, this is fixed

    {
        Vector2 position = rigidbody2d.position; // find the position of player
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);  
        // set new position of player and move
    }
}