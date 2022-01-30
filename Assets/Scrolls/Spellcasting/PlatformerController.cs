using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    public GameObject Character;
    Transform charTrans;
    Rigidbody2D charRb;
    Animator CharAnim;

    public static PlatformerController Instance;
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
    public PlayerController[] Players = new PlayerController[2];
    public bool addController(PlayerController cont)
    {
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i] == null)
            {
                Players[i] = cont;
                return true;
            }
        }
        return false;
    }

    private void Start()
    {
        charTrans = Character.transform;
        charRb = Character.GetComponent<Rigidbody2D>();
        CharAnim = Character.GetComponent<Animator>();
    }

}
