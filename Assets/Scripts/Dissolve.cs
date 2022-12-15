using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public Material Dissolvematerial;
    public string PropertyName;
    public float LowValue = 0;
    public float HighValue = 5;
    private float DissolveSpeed = 0.03f;
    private float MixValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        MixValue = 0;
    }

    void Update()
    {
        Dissolvematerial.SetFloat(PropertyName, MixValue);
        MixValue += DissolveSpeed;

    }
}
