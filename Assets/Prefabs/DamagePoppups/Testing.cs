using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Transform pfDamagePoppup;
    private void Start()
    {
    Transform damagePopupTransform = Instantiate(pfDamagePoppup, Vector3.zero, Quaternion.identity);
        DamagePoppups damagePopup = damagePopup = damagePopupTransform.GetComponent<DamagePoppups>();
        damagePopup.Setup(300);
    }
}
