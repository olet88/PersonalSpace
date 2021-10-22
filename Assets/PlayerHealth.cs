using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 80;
 
    void Start()
    {
        currentHealth = maxHealth;
    }
 
 
    void Update()
    {
       
    }
}