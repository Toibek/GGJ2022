using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int Health;
    private int startingHealth; 
    public int maxHealth;

    private void Start()
    {
        maxHealth = Health; 
    }

    public void ReduceHealth(int damage)
    {
        int tempHealth = Health;
        Health = tempHealth - damage;
        
        UIManager.Instance.UpdateHealth((float) Health / maxHealth); 
    }
    
    public void IncreaseHealth(int boost)
    {
        if (Health < maxHealth)
        {
            int tempHealth = Health;
            Health = tempHealth + boost; 
        }

        UIManager.Instance.UpdateHealth((float)Health / maxHealth); 
    }
}
