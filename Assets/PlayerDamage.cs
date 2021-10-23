using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{

    //The box's current health point total
    public int currentHealth = 50;

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            Debug.Log("Game over");
            //if health has fallen below zero, deactivate it 
            gameObject.SetActive(false);
        }
    }
}