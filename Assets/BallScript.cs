using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddlePosition;
    public float speed;
    public Transform explosion;
    public Transform powerup;
    public GameManager gm;
    AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver) {
            return;
        }
        if(!inPlay){
            transform.position = paddlePosition.position;
        }

        if(Input.GetButtonDown("Jump") && !inPlay){
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("bottomScreen")){
            Debug.Log("Ball Hit Bottom of Screen");
            rb.velocity = Vector2.zero; //kiil all the velocity and momentum that the ball has
            inPlay = false;
            gm.updateLives(-1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) { // other is easy to define as something you/i just hit
        // on colision you cant just do compareTag only, you need transform
        if(other.transform.CompareTag("Brick")){ // so if what i just hit was a brick...

            BrickScript brickScript = other.gameObject.GetComponent<BrickScript>();

            if (brickScript.hitsToBreak > 1) {
                brickScript.breakBrick();
                brickScript.changeColor();
            } else {
                // ---- Random.Range(x,y) explanation ----
                // lets say the parameter format is (x,y) with x is inclusive and y is exclusive, which mean x <= rand < y, 
                // meaning the varible rand can be equal to x but can be to y, it can be equal to the value that is lower than y
                int rand = Random.Range(1, 101);
                if (rand >= 50) {
                    Instantiate(powerup, other.transform.position, other.transform.rotation);
                }


                gm.updateScore(brickScript.points);
                gm.reduceNumberOfBricks();

                Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation); // this create the explosion effect with the position of the brick
                Destroy(newExplosion.gameObject, 2f);
                Destroy(other.gameObject); //...then destroy it this other cause other is pointing at the brick
            }

            audio.Play();
        }
    }
}
