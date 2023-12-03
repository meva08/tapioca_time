using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 3.0f;

    
    
    Rigidbody2D rigidbody2d; // This creates a new variable called rigidbody2d to store the Rigidbody and access it from anywhere inside your script.
    float horizontal; // use global varaiabl 
    float vertical;
    Vector2 lookDirection = new Vector2(1,0); 

    // Why are you storing the look direction? Because compared to the Robot, Ruby can stand still.  When she stands still, Move X and Y are both 0, so the State Machine doesn’t know which direction to use unless we tell it. 

    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); //include the game objet 

        


        // This code is inside the Start function, so it’s executed only once when the game starts. It tells Unity to give you the Rigidbody2D that is attached to the same GameObject that your script is attached to, which is your character.


        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

       
        Vector2 move = new Vector2(horizontal, vertical); //  you store the input amount in a Vector2 called move. 
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) // Check to see whether move.x or move.y isn’t equal to 0. 
        // Mathf.Approximately instead of == because the way computers store float numbers means there is a tiny loss in precision. 
        {
            lookDirection.Set(move.x, move.y);

            // If either x or y isn’t equal to 0, then Ruby is moving, set your look direction to your Move Vector and Ruby should look in the direction that she is moving. 
            // If she stops moving (Move x and y are 0) then that won’t happen and look will remain as the value it was just before she stopped moving. 
            lookDirection.Normalize();

            // Then call Normalize on your lookDirection to make its length equal to 1. -> length is not important here, so set it to one
            // As said before, Vector2 types store positions, but they can also store directions! 

        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Station"));
            if (hit.collider != null)
            {
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
            }
        }


    }

    void FixedUpdate() //FixedUpdate influences the physics system -> instead of the unstable Update, based on frame rate, this is fixed
    //however, fixed update does not read input since you might miss a player input in between intervals
    {
        Vector2 position = rigidbody2d.position; //In the FixedUpdate function, you’ve added the line of code that used to be in the Update function and adjusted it to use the Rigidbody position.
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);  
        // In the same way, instead of setting the new position with transform.position = position; you are now doing it with the Rigidbody position. 
        // This line of code will move the Rigidbody to where you want, but will stop it mid-way instead if it collides with another Collider in that movement.
    }
}