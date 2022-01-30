using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] GameObject rightLeg;
    [SerializeField] GameObject leftLeg;
    [Space]
    [SerializeField] GameObject rightArm;
    [SerializeField] GameObject leftArm;
    public static CharacterManager Instance;
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
    public GameObject Leg(PlayerController cont)
    {
        if (Players[0] == cont)
            return rightLeg;
        else
            return leftLeg;
    }
    public GameObject Arm(PlayerController cont)
    {
        if (Players[0] == cont)
            return rightArm;
        else
            return leftArm;
    }
    public bool addController(PlayerController cont)
    {
        for (int i = 0; i < Players.Length; i++)
        {
            if(Players[i] == null)
            {
                Players[i] = cont;
                return true;
            }
        }
        return false;
    }

}
