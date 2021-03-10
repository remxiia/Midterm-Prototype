using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//code to end and/or restart the game when the skull is touched
//...at least, that's what it should be doing. which it isn't at the moment.

public class skullBehavior : MonoBehaviour
{

    BoxCollider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene("GameEnd");
        }
    }
}
