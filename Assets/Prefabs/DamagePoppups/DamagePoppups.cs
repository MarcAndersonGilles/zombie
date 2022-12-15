using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePoppups : MonoBehaviour
{
    // Référence à l'objet de texte qui sera utilisé pour afficher les popups
    public GameObject damageTextPrefab;

    // Fonction appelée lorsqu'un ennemi subit des dégâts
    public void ShowDamagePopup(int damage)
    {
        // Instancie un nouvel objet de texte pour afficher les dégâts
        GameObject damageText = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);

        // Définit le texte de l'objet pour afficher les dégâts
        damageText.GetComponent<TextMesh>().text = damage.ToString();

        // Déplace l'objet de texte vers le haut de l'écran pour créer l'effet de popup
        damageText.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
    }
}
