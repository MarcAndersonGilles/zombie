using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TypingArea : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject leftTypingHand;
    public GameObject rightTypingHand;

    private void OnTriggerEnter(Collider other)
    {
     //   GameObject hand = other.GetComponentInParent<OVRGrabber>().gameObject;
    }

}
