using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool hit = false;
    float depth = 0.30F;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!hit)
        {
            ArrowStick(other);
            hit = true;
        }
    }
    void ArrowStick(Collision2D col)
    {

        // move the arrow deep inside the enemy or whatever it sticks to
        col.transform.Translate(depth * -Vector2.right);
        // Make the arrow a child of the thing it's stuck to
        transform.parent = col.transform;
        //Destroy the arrow's rigidbody2D and collider2D
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<Collider2D>());
    }
}

