using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool isShooting,
        isRotating;

    public bool SetBool(KeyCode key, bool input)
    {
        if(Input.GetKeyDown(key))
        {
            input = !input;
        }
        return input;
    }
}
