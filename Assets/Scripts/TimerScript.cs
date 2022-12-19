using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public Text TimerTxt;

    public GameObject Boss;

    public Material Dissolvematerial;
    public string PropertyName;
    public float LowValue = 0;
    public float HighValue = 5;
    private float DissolveSpeed = 0.03f;
    private float MixValue = 0;

    //Dissolve dissolve;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;

        //dissolve = GameObject.FindGameObjectWithTag("Dissolve").GetComponent<Dissolve>();
        //dissolve.startDissolve();
    }

    public void Awake()
    {
        MixValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Dissolvematerial.SetFloat(PropertyName, MixValue);

        if(TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                Boss.SetActive(true);
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);
    }
}
