using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inject : MonoBehaviour
{
    public GameObject niddle;
    public float depth = 0.008123F;
    public bool isInside = false;
    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = gameObject.transform.position;
        niddle = GameObject.Find("Niddle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Acupunctures")
        {
            Debug.Log("Inject");
            if(isInside)
                transform.Translate(depth * Vector3.down);
            niddle.GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = collision.transform;
        }
        
        if(collision.gameObject.tag == "WrongPoint")
        {
            Debug.Log("reset pos");
            gameObject.transform.position = originalPos;
            niddle.GetComponent<Rigidbody>().isKinematic = false;
            //Destroy(niddle.GetComponent<Rigidbody>());
            transform.parent = null;
        }
    }
}
