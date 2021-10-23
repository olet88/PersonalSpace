using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerDamage : MonoBehaviour
{

    //The box's current health point total
    public int currentHealth = 50;
    public Text texttext;

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;
        texttext.text = "Health: " + currentHealth.ToString();
        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            texttext.text="Game over";
            //if health has fallen below zero, deactivate it 
            gameObject.SetActive(false);
        }
    }
}