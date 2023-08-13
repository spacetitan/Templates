using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt = "Press 'E' to Toggle";
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
        Debug.Log("Toggle");
        return true;
    }
}
