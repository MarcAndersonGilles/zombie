using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Damagable : MonoBehaviour
{
    public int MaxHealth = 100;
    public GameObject damageTextPrefab;
    public int health = 0;
    public Slider slider;
    public Animator animtor;
    public GameObject enemyObject;
    public List<GameObject> enemyObjects;
    public bool enemyIsDead = false;
    public GameObject enemyHealthBarInvisible;
    public GameObject enemyCorpsInvisible;
    public float inactiveDuration = 2f;
    public float activeDuration = 2f;
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
        enemyIsDead = false;
        GetComponent<Dissolve>().enabled = false;
        enemyHealthBarInvisible.SetActive(true);
        enemyCorpsInvisible.SetActive(true);
        InvokeRepeating("InactiveEnemy", activeDuration, activeDuration + inactiveDuration);
        health = MaxHealth;
    }

    
    public void Hit(int damagePoints)
    {
        health -= damagePoints;
        if (health <= 0)
        {
            GetComponent<AiController>().enabled = false;
            GetComponent<Animator>().SetBool("death", true);
            Destroy(gameObject, 2f);
        }
        else
        {
            slider.value = health;
            DamageScriptText indicator = Instantiate(damageTextPrefab, transform.position, Quaternion.identity).GetComponent<DamageScriptText>();
            indicator.SetDamageText(damagePoints);
        }
        slider.value = health;
    }
    public void Hit2(int damagePoints)
    {
        health -= damagePoints;
        if (health <= 0)
        {
            Invoke("LoadSceneMort", 2f);
        }
        else
        {
            slider.value = health;
            DamageScriptText indicator = Instantiate(damageTextPrefab, transform.position, Quaternion.identity).GetComponent<DamageScriptText>();
            indicator.SetDamageText(damagePoints);
        }
        slider.value = health;
    }
    public void HitBoss(int damagePoints)
    {
        health -= damagePoints;
        if (health <= 0)
        {
            Debug.Log("Scene appele");
            GetComponent<Animator>().SetBool("death", true);
            GetComponent<Dissolve>().enabled = true;
            
            Invoke("LoadSceneVictoire", 3f);
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
        // Cr�er un GameObject pour afficher le texte du pop-up
        var popup = new GameObject("DamagePopup");
        popup.transform.position = transform.position;

        // Ajouter un composant Text pour afficher le texte
        var text = popup.AddComponent<Text>();
        text.text = damagePoints.ToString();

        // Ajouter un composant pour faire dispara�tre le pop-up au bout de quelques secondes
        var destroyTimer = popup.AddComponent<DestroyTimer>();
        destroyTimer.Lifetime = 2.0f;
    }
    


    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Enemy" && collision.gameObject.tag == "bullet")
        {
            // Affiche le nom de l'objet en collision dans la console
            Debug.Log("Collision detected with object: " + collision.gameObject.name);
            Hit(15);
        }
        if (gameObject.tag == "Hero" && collision.gameObject.tag == "Enemy")
        {
            Hit2(15);
            
        }
        if (gameObject.tag == "Boss" && collision.gameObject.tag == "bullet")
        {
            HitBoss(15);

        }

    }


void Update()
    {
        enemyIsDead = true;
        if (health > MaxHealth)
        {
            health = MaxHealth;
        }
        foreach (GameObject enemy in enemyObjects)
        {
            if (enemy != null)
            {
                enemyIsDead = false;
                break;
            }
        }
        if (enemyIsDead)
        {
            //Invoke("sceneVictoire", 5f);
        }



    }
    void ReappearEnemy()
    {
        enemyCorpsInvisible.SetActive(true);
        enemyHealthBarInvisible.SetActive(true);
    }
    void InactiveEnemy()
    {
        enemyCorpsInvisible.SetActive(false);
        enemyHealthBarInvisible.SetActive(false);
        Invoke("ReappearEnemy", inactiveDuration);
    }
    void LoadSceneVictoire()
    {
        // Load the specified scene
        SceneManager.LoadScene("sceneVictoire");
    }
    void LoadSceneMort()
    {
        // Load the specified scene
        SceneManager.LoadScene("sceneMort");
    }
}