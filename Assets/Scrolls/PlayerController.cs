using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject arm;
    [SerializeField] private GameObject leg; 

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            
        }
    }

    
    public void Stunned(GameObject target, int duration)
    {
        
    }
    
}
