using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "UIManager";
                    instance = go.AddComponent<UIManager>(); 
                    DontDestroyOnLoad(go);
                }
            }

            return instance; 
        }
    }
    
    [Header("Health Bar")]
    [SerializeField] private Image healthBar;

    [SerializeField] private Color32 goodHealth;
    [SerializeField] private Color32 mediumHealth;
    [SerializeField] private Color32 lowHealth;

    [Header("Panels")] 
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private Canvas gameOverPanel; 
   
   
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }


    public void UpdateHealth(float newValue)
    {
        healthBar.fillAmount = newValue;

        if (healthBar.fillAmount < 0.3f) healthBar.color = lowHealth;

        else if (healthBar.fillAmount < 0.6f) healthBar.color = mediumHealth; 

        else if (healthBar.fillAmount > 0.6f) healthBar.color = goodHealth; 
    }

    public void GameOver()
    {
        gameOverPanel.enabled = true; 
        
        
    }

    public void GamePause()
    {
        if (pauseMenu.enabled == false)
        {
            pauseMenu.enabled = true;
            Time.timeScale = 0f;
        } 
        
        else if (pauseMenu.enabled == true)
        {
            pauseMenu.enabled = false; 
            Time.timeScale = 1f; 
            
        }
    }
}