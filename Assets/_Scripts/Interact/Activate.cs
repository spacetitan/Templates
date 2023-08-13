using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt = "Press 'E' to Activate";
    [SerializeField] private float _time = 0f;
    public string interactPrompt => this._prompt;
    public float interactTime => this._time;

    private float _interactTimer = 0f;
    private bool _isInteractable = true;

    void Start()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Interact"); //make sure layer is added
    }

    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
        if(this._isInteractable)
        {
            if(this._interactTimer < this._time)
            {
                this._interactTimer += Time.smoothDeltaTime;
                return false;
            }
            else
            {
                this._interactTimer = 0.0f;
                Debug.Log("Activating");
                this._isInteractable = false;
                return true;
            }
        }
        return false;
    }
}
