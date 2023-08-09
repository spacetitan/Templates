using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt = "Press 'E' to carry";
    public string interactPrompt => throw new System.NotImplementedException();
    
    void Start()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Interact"); //make sure layer is added
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Pick up");
        if(interactor.carriedObject == null)
        {
            interactor.carriedObject = this.gameObject;
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
