using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePoppups : MonoBehaviour
{
    // R�f�rence � l'objet de texte qui sera utilis� pour afficher les popups
    public GameObject damageTextPrefab;

    // Fonction appel�e lorsqu'un ennemi subit des d�g�ts
    public void ShowDamagePopup(int damage)
    {
        // Instancie un nouvel objet de texte pour afficher les d�g�ts
        GameObject damageText = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);

        // D�finit le texte de l'objet pour afficher les d�g�ts
        damageText.GetComponent<TextMesh>().text = damage.ToString();

        // D�place l'objet de texte vers le haut de l'�cran pour cr�er l'effet de popup
        damageText.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
    }
}
