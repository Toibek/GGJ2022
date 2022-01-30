using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "UIManager";
                    instance = go.AddComponent<GameManager>(); 
                    DontDestroyOnLoad(go);
                }
            }

            return instance; 
        }
    }
    [SerializeField] private List<Vector2> corpsePositions = new List<Vector2>();
    [SerializeField] private Vector2 testPosition; 
    [SerializeField] private bool saveTrigger = false;
    [SerializeField] private bool loadTrigger = false;
    [SerializeField] private GameObject corpsePrefab; 
    
    private int corpseCount;

    private void Awake()
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

    private void Start()
    {
        corpseCount = PlayerPrefs.GetInt("CorpseCount"); 
        LoadCorpses();
    }

    private void Update()
    {
        if (saveTrigger)
        {
            UpdateCorpse(testPosition.ToString());
            saveTrigger = false;
        }

        if (loadTrigger)
        {
            LoadCorpses();
            loadTrigger = false; 
        }
    }


    private void LoadCorpses()
    {
        corpsePositions = new List<Vector2>();
        for (int i = 0; i < corpseCount ; i++)
        {
            string corpseData =  PlayerPrefs.GetString($"Corpse{(i + 1).ToString()}");
            string[] corpseVec = corpseData.Substring(1, corpseData.Length - 2).Split(',');
            Vector2 corpsePosition = new Vector2(float.Parse(corpseVec[0]), float.Parse(corpseVec[1])); 
            corpsePositions.Add(corpsePosition);

            Instantiate(corpsePrefab, corpsePosition, Quaternion.identity);
            corpsePrefab.GetComponent<TextMeshProUGUI>().text = $"No. {i + 1}"; 
        }
    }
    
    public void UpdateCorpse(string newCorpsePosition)
    {
        corpseCount++; 
        PlayerPrefs.SetInt("CorpseCount", corpseCount);
        PlayerPrefs.SetString($"Corpse{corpseCount.ToString()}", newCorpsePosition);

    }
    
}
