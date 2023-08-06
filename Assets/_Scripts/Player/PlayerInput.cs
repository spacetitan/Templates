using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput
{
    //To Do
    //add saving/loading keycodes to player prefs
    private Dictionary<KeyBinding, KeyCode> keyBindings = new Dictionary<KeyBinding, KeyCode>();

    void Awake(){}

    public float CameraXInput()
    {
        return Input.GetAxis("Mouse X");
    }
    public float CameraYInput()
    {
        return Input.GetAxis("Mouse Y");
    }

    public float MovementZInput()
    {
        return Input.GetAxis("Vertical");
    }
    public float MovementXInput()
    {
        return Input.GetAxis("Horizontal");
    }

    public bool JumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    public bool InteractInput()
    {
        return Input.GetButtonDown("Interact"); //add to Input Manager
    }
}
