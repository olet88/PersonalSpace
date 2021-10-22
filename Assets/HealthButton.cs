using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class HealthButton : MonoBehaviour
{
    public float heal;
    public PlayerHealth playerhealth;
    public HealthBar healthBar;
    public GameObject effect;
    private Transform player;
 
 
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
 
    public void Use()
    {
        HealPlayer(10);
        Instantiate(effect, player.position, Quaternion.identity);
        Destroy(gameObject);
       
    }
 
    public void HealPlayer(int heal)
    {
 
 
        playerhealth.currentHealth += heal;
 
        healthBar.slider.value = playerhealth.currentHealth;
    }
}