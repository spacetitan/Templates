using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Transform interactPoint = null;
    public float interactRadius = 0.5f;
    public LayerMask interactMask;

    public Transform carryPoint = null;
    public IInteractable carriedObject = null;
    public GameObject carriedGameObject = null;

    private readonly Collider[] _colliders = new Collider[4];
    private int _numFound = 0;

    void Start()
    {
        if(this.interactPoint == null)
        {
            this.interactPoint = this.transform;
        }

        if(this.carryPoint == null)
        {
            this.carryPoint = this.transform;
        }
    }

    void Update()
    {  
        this._numFound = Physics.OverlapSphereNonAlloc(this.interactPoint.position, this.interactRadius, this._colliders, this.interactMask);
        if(this._numFound > 0)
        {
            IInteractable interactable = this._colliders[0].GetComponent<IInteractable>();

            if(interactable != null)
            {
                if(interactable.interactTime > 0 && InputManager.Instance.InteractInputHold())
                {
                    Interact(interactable);
                }
                else if(InputManager.Instance.InteractInput())
                {
                    Interact(interactable);
                }
            }
        }
        else if(InputManager.Instance.InteractInput())
        {
            DropItem();
        }
    }

    private void Interact(IInteractable interactable)
    {
        if(interactable != this.carriedObject)
        {
            interactable.Interact(this);
        }
        else
        {
            DropItem();
        }
    }

    void DropItem()
    {
         if(this.carriedGameObject != null && InputManager.Instance.InteractInput())
        {
            Debug.Log("Dropping Item");
            this.carriedObject = null;
            this.carriedGameObject.transform.SetParent(null);
            this.carriedGameObject = null;
        }
    }

    void OnDrawGizmos()
    {
        if(this.interactPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(this.interactPoint.position, this.interactRadius);
        }
    }
}
