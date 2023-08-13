using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt = "Press 'E' to carry";
    [SerializeField] private float _time = 0;
    public string interactPrompt => this._prompt;
    public float interactTime => this._time;

    void Start()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Interact"); //make sure layer is added
    }

    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Pick up");
        if(interactor.carriedObject == null)
        {
            interactor.carriedObject = this;
            interactor.carriedGameObject = this.gameObject;
            this.transform.SetParent(interactor.carryPoint, false);
            this.transform.position = interactor.carryPoint.position;
            return true;
        }
        else
        {
            return false;
        }
    }
}
