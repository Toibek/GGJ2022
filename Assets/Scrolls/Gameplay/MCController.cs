using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    void GameOver()
    {
        string corpsePosition = gameObject.transform.position.ToString();
        GameManager.Instance.UpdateCorpse(corpsePosition); 

    }
}
