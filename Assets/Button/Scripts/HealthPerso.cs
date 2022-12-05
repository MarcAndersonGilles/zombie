using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPerso : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator anim;

    public float Health = 1f;
    public static GameObject LocalPlayerInstance;
    [SerializeField]
    private GameObject playerUiPrefab;
    [SerializeField]
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (!other.name.Contains("Beam"))
        {
            return;
        }
        this.Health -= .1f;
    }
    private void OnTriggerStay(Collider other)
    {
       
        if (!other.name.Contains("Beam"))
        {
            return;
        }
        this.Health -= .1f * Time.deltaTime;
    }
    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth < 0)
        {// death

        }
    } 
 }
