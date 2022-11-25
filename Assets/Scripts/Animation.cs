using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        /*if (GetComponent<Rigidbody>().velocity.magnitude > 1f)
        {
            GetComponent<Animator>().SetBool("walk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("walk", false);
        }*/
    }

    void OnCollisionEnter(Collision collison)
    {
        if(collison.gameObject.name == "Personnage")
        {
            GetComponent<Animator>().SetBool("attack", true);
        }
    }
}

