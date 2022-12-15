using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float Lifetime = 1.0f;

    void Start()
    {
        Destroy(gameObject, Lifetime);
    } 
    } 
