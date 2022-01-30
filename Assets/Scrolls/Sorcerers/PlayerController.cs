using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject arm;
    [SerializeField] private GameObject leg;
    [SerializeField] private PlayerController otherPlayer;

    public bool ArmIsStunned = false;
    public bool LegIsStunned = false;

    private float armCooldown;
    private float legCooldown; 
    void Start()
    {
        
    }


    void Update()
    {

    }
    

    public void Stunned(GameObject target, int duration)
    {
        
    }
    public void Move(InputAction.CallbackContext context)
    {
        if (LegIsStunned == false)
        {
            
        }
    }
    public void Action1(InputAction.CallbackContext context)
    {

    }
    public void Action2(InputAction.CallbackContext context) 
    {

    }
    public void Action3(InputAction.CallbackContext context) 
    {

    }
    public void Action4(InputAction.CallbackContext context) 
    {

    }
    public void Join(InputAction.CallbackContext context) 
    {

    }
}
