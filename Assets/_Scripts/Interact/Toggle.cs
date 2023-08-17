using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt = "Press 'E' to Toggle";
    [SerializeField] private float _time = 0;
    public string interactPrompt => this._prompt;
    public float interactTime => this._time;
    private float _interactTimer = 0f;
    private bool _isToggled = false;

    void Start()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Interact"); //make sure layer is added
    }

    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
        if(this.interactTime > 0.0f)
        {
            if(this._interactTimer < this._time)
            {
                this._interactTimer += Time.smoothDeltaTime;
                return false;
            }
            else
            {
                this._isToggled = true;
                return true;
            }
        }
        else
        {
            if(this._isToggled)
            {
                this._isToggled = false;
                Debug.Log("Toggle: false");
                return false;
            }
            else
            {
                this._isToggled = true;
                Debug.Log("Toggle: true");
                return true;
            }
        }
    }
}
