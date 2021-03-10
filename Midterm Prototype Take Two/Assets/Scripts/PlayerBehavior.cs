using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //need this so I can reference Text

public class PlayerBehavior : MonoBehaviour
{
    
    public Text KeyText; //gonna need this to get text to show up to the game screen, I think
    public float speed; //honestly not sure if I'm gonna need this, might get deleted later
    public Sprite walkSprite;

    public enum directionState{ //def gonna need this, gotta get my char to move somehow
        up,
        down,
        left,
        right,
        none
    }

    //component ref(s)
    BoxCollider2D myCollider;
    SpriteRenderer myRenderer;

    public directionState currentState = directionState.none; //currently not moving (I think....)
    public static bool faceLeft = true; //start the game facing left (hopefully)

    private Text firstText; //****SHOULD help to start getting the text to show on screen when the char bumps into an obj

    // Start is called before the first frame update
    void Start()
    {
        myCollider = gameObject.GetComponent<BoxCollider2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        firstText.enabled = false; 

    }

    void FixedUpdate() //fixedUpdate stops the jittery-walking effect
    {
        CheckKey();
        MoveMe();
    }

    void CheckKey(){ //changes the walking state
        if(Input.GetKey(KeyCode.W)){
            currentState = directionState.up;
        } else if(Input.GetKey(KeyCode.S)){
            currentState = directionState.down;
        } else if(Input.GetKey(KeyCode.A)){
            faceLeft = false;
            myRenderer.flipX = false;
            currentState = directionState.left;
        } else if(Input.GetKey(KeyCode.D)){
            faceLeft = true;
            myRenderer.flipX = true;
            currentState = directionState.right;
        } else {
            currentState = directionState.none;
        }
    }

    void MoveMe(){ // state machine that checks the walking state, moves the player in that direction
        switch(currentState){
            case directionState.up:
                transform.Translate(Vector3.up * Time.deltaTime * speed);
                Debug.Log("W key pressed");
                break;
            case directionState.down:
                transform.Translate(Vector3.down * Time.deltaTime * speed);
                Debug.Log("S key pressed");
                break;
            case directionState.left:
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                Debug.Log("A key pressed");
                break;
            case directionState.right:
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                Debug.Log("D key pressed");
                break;
            default:
                Debug.Log("Nothing pressed");
                break;
        }
    }

    //NONE of the below are working at all!!
    
    //because it's in the wrong script, past-Sarah. keeping it here for reference.

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     //if(collision.gameObject.tag == "Item"){
    //         //firstText.enabled = true;
    //     //}

    //     if(other.gameObject.tag == "Item"){
    //         Destroy(gameObject); //okay for some reason this is destroying the PLAYER, not the obj tagged IT. or it was, now it doesn't do anything. heck.
    //         Debug.Log("bumped");
    //     }
    // }
}
