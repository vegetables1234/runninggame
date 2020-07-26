using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;         //variables used for player movement 
    private float moveSpeedStore;
    public float jumpForce;


    public float speedMultiplier;       //variables used for increasing player speed
    public float speedIncreaseMilestone;                //the distance that needs to be reached before speed increases
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;      
    private float speedMilestoneCountStore;

    private Rigidbody2D myRigidBody;        //variable used to describe the player body
    

    public bool grounded;               //public variables aim to keep the player on the ground
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;


    private Collider2D myCollider;


    public float jumpTime;                  //variables used for allowing player to jump only once
    private float jumptTimeCounter;

    private bool stoppedJumping;        //used to make smoother jumping system 10/7/20

    public GameManager theGameManager;

    private Animator anim;              //variable used for animating the player


    //public GameObject gameManager; 


    public GameObject cube;             //variables used for creating new ground and for placing the player
    public Vector3 newBoxLocation;
    public GameObject player;


    private bool stopNewGround;         //variable used for creating spaces between the platforms


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();        //searches for collider in Unity   


        jumptTimeCounter = jumpTime;        //used for jumping only once


        StartMakeBox(0.3f);
        newBoxLocation = new Vector3(this.transform.position.x-1, -2, 0);


        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;                 //used to reset speed once player has died
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        anim = GetComponent<Animator>();            //for the animator section in unity (used for jumping animation)

        stoppedJumping = true;
        
        


    }

    // Update is called once per frame
    void Update()
    {
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);                //checks if collider is touching any other object (boolean value) - used for allowing player to jump only once
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        newBoxLocation.x = this.transform.position.x+7;               //used to create new platforms and where to place them
        newBoxLocation.y = (Random.Range(-3, 1));



        if(transform.position.x > speedMilestoneCount)      //checks if the distance of the player is greater than the distance milestone
        {
            speedMilestoneCount += speedIncreaseMilestone;          //then increases count

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;     //this increases the milestone distance (Creates a regular time interval before speed picks up) 

            moveSpeed = moveSpeed * speedMultiplier;            //then increases speed of player
        }

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);          //speed of the player


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))             //when the player presses down space, the player will jump
        {

            if (grounded)                                           //if the player is touching the ground, they will jump
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                stoppedJumping = false;
            }
        }


        if (grounded)               //maybe merge this and the previous if statement
        {
            jumptTimeCounter = jumpTime;
        }


        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)             //timer for when player holds down space button + adjusts height of jump in accordance to how long the player presses down the space button
        {
            if (jumptTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumptTimeCounter -= Time.deltaTime;
            }
        }


        


        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButton(0))           //prevents the player from double jumping!
        {
            jumptTimeCounter = 0;
            stoppedJumping = true;
        }

        if(Input.GetKeyDown(KeyCode.P))         //these two functions were an attempt to stop the platforms from generating for a brief amount of time
        {
            SetStopNewGround(true);
            System.Random ran = new System.Random();
            double rantime = ran.NextDouble()+10;
            SetStopNewGround(false);
            StartMakeBox(rantime);
            print("Hello");
        }

        

        



        if (grounded == true)               //this function was used to create a smooth transition between the jumping and running animation by the use of triggers
        {
            anim.SetTrigger("isOnGround");
        }
        else
        {
            anim.SetTrigger("isJumping");
        }


    }

    void OnCollisionEnter2D(Collision2D other)      //when two different box colliders touch, 
    {
        if (other.gameObject.tag == "killbox")
        {
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;                     //the next three lines focusses on reseting speed and speed multiplier once player dies
            speedMilestoneCount = speedMilestoneCountStore;              
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }



    IEnumerator MakeBox(float waitTime)         //method to help generates holes between the platforms
    {
        while (true)
        {
            Instantiate(cube, newBoxLocation, gameObject.transform.rotation);
            if (stopNewGround == true) yield break;              
            yield return new WaitForSeconds(Random.Range(0.5f, 1.6f));
            //waitTime
        }

    }

    void SetStopNewGround(bool b)
    {
        stopNewGround = b;
    }

    void StartMakeBox(double waittime)
    {
        StartCoroutine("MakeBox", waittime);
    }

    
}
