using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MCController : MonoBehaviour
{
    public static MCController Instance;
    #region Singleton
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
    #endregion

    [SerializeField] private int health;
    private int maxHealth;


    private void Start()
    {
        maxHealth = health; 
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ReduceHealth(1);
        }
    }
    public void ReduceHealth(int damage)
    {
        health -= damage;
        UIManager.Instance.UpdateHealth((float) health / maxHealth); 
        if (health <= 0) GameOver();
        
        
    }
    
    public void IncreaseHealth(int boost)
    {
        if (health < maxHealth)
        {
            health += boost; 
        }
        UIManager.Instance.UpdateHealth((float)health / maxHealth);
    }

    private void GameOver()
    {
        string corpsePosition = gameObject.transform.position.ToString();
        GameManager.Instance.UpdateCorpse(corpsePosition); 
        UIManager.Instance.GameOver();
    }
}
