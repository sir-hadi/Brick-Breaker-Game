using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * speed);
        if (transform.position.y < -6f) {
            // saying just gameObject just return this current game object ( the power up game object). 
            // in other words it is a getter method and since this class is related to something it , it does not need an object of it self to get a method from it self get it?
            // like if ther is a method1 and a method2 in a class called Test, and lets say in method2 it is calling method1, so we just type "method1;" somewhare in the block of code in method2
            // we dont called method1 like -> "Test1 varName = new (bla, bla); varName.method1;" this is dumb and you should get this already
            Destroy(gameObject); 
        }
    }
}
