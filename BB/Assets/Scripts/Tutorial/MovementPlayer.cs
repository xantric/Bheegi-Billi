using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementPlayer : MonoBehaviour
{   
    public TMP_Text tutorialText;
    bool canMoveRight = true;
    bool canMoveLeft = false;
    bool canJump = false;
    bool canDash = false;
    
    bool checkL1 = true;

    bool checkJ1 = true;

    bool checkD1 = true;

    bool checkA1 = true;

    int obstaclecollision = 0;

    public float moveSpeed = 50f;
    public float jumpSpeed = 100f;

    public float delayTime = 1f;

    private bool isGrounded = true;
    //public float destroyTIme = 0.2f;

    public GameObject DashObject;

    public GameObject Appear;

    public GameObject AfterLevel;

    public GameObject Button;

    bool isMovement = false;
    Rigidbody2D rb;
    private Animator anime;
    private int Anime_State;

    void Start()
    {
        anime=GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        DisplayMessage("Press D to go right");
    }

    // Update is called once per frame
    void Update()
    {
        //setAnimeState();
        if(!isMovement)
        {    
            if(Input.GetKeyDown(KeyCode.D) && canMoveRight && checkL1){
                checkL1 = false;
                RightMovement();
            }else if(Input.GetKey(KeyCode.D) && canMoveRight){
                RightMovement();
                if(obstaclecollision == 1 ){
                    DisplayLeftMovementMessage();
                }
                if(obstaclecollision == 3 ){
                    DisplayDashMessage();
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) && canMoveLeft && checkJ1)
            {
                checkJ1 = false;
                LeftMovement();
            }else if (Input.GetKey(KeyCode.A) && canMoveLeft)
            {
                LeftMovement();
                if(obstaclecollision == 2 ){
                    DisplayJumpMessage();
                }
                if(obstaclecollision == 3 ){
                    DisplayDashMessage();
                }
            }else if(Input.GetKeyDown(KeyCode.Space) && canJump && checkD1)
            {
                checkD1 = false;
                if(isGrounded)
                {
                    Jump();
                }
            }else if(Input.GetKeyDown(KeyCode.Space) && canJump){
                if(isGrounded)
                {
                    Jump();
                }
                if(obstaclecollision == 3 ){
                    DisplayDashMessage();
                }
            }else if(Input.GetMouseButtonDown(0) && canDash && checkA1)
            {   
                obstaclecollision = 4;
                checkA1 = false;
                Invoke("DisplayRegenerationMessage", delayTime);
            }else if(Input.GetMouseButtonDown(0) && canDash){
                Dash();
            }else if(isMovement)
            {
                this.GetComponent<Movement>().enabled = true;
            }
        }
        

        if(obstaclecollision == 5){
            ItselfBreakMessage();
        }
        if(obstaclecollision == 6){
            BreakBlockMessage();
        }
        if(obstaclecollision == 7 && (!Appear)){
            SideWallMessage();
            AfterLevel.SetActive(true);
        }
        if(obstaclecollision == 8){
            DisplayMessage("Tutorial Complete");
            Button.SetActive(true);
        }
    }

    void DisplayLeftMovementMessage()
    {
        DisplayMessage("Press A to go left");
        canMoveLeft = true;
    }

    void DisplayJumpMessage()
    {
        DisplayMessage("Press space to jump and reach to the center of the platform");
        canJump = true;
    }

    void DisplayDashMessage()
    {
        DisplayMessage("Left-click to show the arrow, release for a dash in that direction. Use this to go to above Platform's center");
        Dash();
        canDash = true;
    }

    void DisplayRegenerationMessage()
    {
        DisplayMessage("Note : Dash takes some time to regenerate");
    }

    void SideWallMessage()
    {
        DisplayMessage("You can jump from side walls also.");
    } 

    void BreakBlockMessage()
    {
        DisplayMessage("By using Dash you can pass through platforms");
        obstaclecollision = 7;
    }
    
    void ItselfBreakMessage(){
        DisplayMessage("Note : In game as soon as you land on a platform it breaks after some time");
        Invoke("Destroy", delayTime/16);
        Invoke("Appears", 4f*delayTime);
    }

    void Appears(){
        Appear.SetActive(true);
        obstaclecollision = 6;
    }

    void Destroy(){
        Destroy(GameObject.FindWithTag("breakableBlock"));
    }

    void LeftMovement()
    {
        //Vector3 targetPosition = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
        rb.velocity=new Vector2(-moveSpeed,rb.velocity.y);
    }

    void RightMovement()
    {
        //Vector3 targetPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
        rb.velocity=new Vector2(moveSpeed,rb.velocity.y);
    }

    void Jump(){
        //Vector3 targetPosition = transform.position + Vector3.up * jumpSpeed * Time.deltaTime;
        rb.velocity=new Vector2(rb.velocity.x,jumpSpeed);
    }

    void Dash(){
        DashObject.GetComponent<Dash>().enabled = true;
    }

    void DisplayMessage(string message)
    {
        tutorialText.text = message;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "obstacle1".
        if (collision.gameObject.CompareTag("obstacle1"))
        {
            obstaclecollision = 1;
            Destroy(GameObject.FindWithTag("obstacle1"));
            Debug.Log("Collision with obstacle1 detected!");
        }else if (collision.gameObject.CompareTag("obstacle2"))
        {
            obstaclecollision = 2;
            Debug.Log("Collision with obstacle2 detected!");
            Destroy(GameObject.FindWithTag("obstacle2"));
        }else if (collision.gameObject.CompareTag("obstacle3"))
        {
            obstaclecollision = 3;
            Debug.Log("Collision with obstacle3 detected!");
            Destroy(GameObject.FindWithTag("obstacle3"));
        }else if (collision.gameObject.CompareTag("obstacle4"))
        {
            obstaclecollision = 5;
            Debug.Log("Collision with obstacle4 detected!");
            Destroy(GameObject.FindWithTag("obstacle4"));
        }else if (collision.gameObject.CompareTag("TutENd"))
        {
            obstaclecollision = 8;
        }



        if(collision.gameObject.CompareTag("groundTut") || collision.gameObject.CompareTag("breakableBlock"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("groundTut") || collision.gameObject.CompareTag("breakableBlock"))
        {
            isGrounded = false;
        }
    }
    private void setAnimeState()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.A) )
            {
                Anime_State = -1;
            }
            else if (Input.GetKeyDown(KeyCode.D) )
            {
                Anime_State = 1;
            }
            else Anime_State = 0;
        }
        else if (!isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.D)) 
            {
                Anime_State = 2;
            }
            else if( Input.GetKeyDown(KeyCode.A)) 
            {
                Anime_State = -2;
            }
            else Anime_State = 0;
        }
    }
    
}