using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MCController : MonoBehaviour
{
    public static MCController Instance;
    [SerializeField] private int health;
    private int maxHealth;

    [SerializeField] private TextMeshProUGUI mcText;
    public bool isConfused = false; 
    #region Singleton
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        maxHealth = health;
        mcText.enabled = false; 
    }
    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
    #endregion

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

    public void Confused()
    {
        mcText.enabled = true;
    }

    private void GameOver()
    {
        string corpsePosition = gameObject.transform.position.ToString();
        GameManager.Instance.UpdateCorpse(corpsePosition); 
        UIManager.Instance.GameOver();
    }
}
