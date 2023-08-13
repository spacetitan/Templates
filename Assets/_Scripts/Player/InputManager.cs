using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance {get; private set;}

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //To Do
    //add saving/loading keycodes to player prefs
    private Dictionary<KeyBinding, KeyCode> keyBindings = new Dictionary<KeyBinding, KeyCode>();

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

    public bool InteractInputHold()
    {
        return Input.GetButton("Interact"); //add to Input Manager
    }
}
