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
    [SerializeField] private Image healthBar; 

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
    }
}
