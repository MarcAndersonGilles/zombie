using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Damagable : MonoBehaviour
{
    public int MaxHealth = 100;
    public GameObject damageTextPrefab;
    public int health = 0;
    public Slider slider;
    public GameObject enemyObject;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }

    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;

    private void Start()
    {
        if (health == 0) {
            Health = MaxHealth;
            slider.value = health;
        }
        health = MaxHealth;
    }

    
    public void Hit(int damagePoints)
    {
        health -= damagePoints;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            slider.value = health;
            DamageScriptText indicator = Instantiate(damageTextPrefab, transform.position, Quaternion.identity).GetComponent<DamageScriptText>();
            indicator.SetDamageText(damagePoints);
        }
        slider.value = health;
    }

    public void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
    }
     public void ShowDamagePopup(int damagePoints)
    {
        // Créer un GameObject pour afficher le texte du pop-up
        var popup = new GameObject("DamagePopup");
        popup.transform.position = transform.position;

        // Ajouter un composant Text pour afficher le texte
        var text = popup.AddComponent<Text>();
        text.text = damagePoints.ToString();

        // Ajouter un composant pour faire disparaître le pop-up au bout de quelques secondes
        var destroyTimer = popup.AddComponent<DestroyTimer>();
        destroyTimer.Lifetime = 2.0f;
    }
    


    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Enemy" && collision.gameObject.tag == "bullet")
        {
            // Affiche le nom de l'objet en collision dans la console
            Debug.Log("Collision detected with object: " + collision.gameObject.name);
            Hit(5);
            

        }
            
    }


void Update()
    {
        if (health > MaxHealth)
        {
            health = MaxHealth;
        }
       
    }
}