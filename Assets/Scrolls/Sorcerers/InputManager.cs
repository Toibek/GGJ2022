using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void PlayerJoined(PlayerInput input)
    {
        input.defaultControlScheme = input.currentControlScheme;
        Debug.Log(input.currentControlScheme);

    }
}
