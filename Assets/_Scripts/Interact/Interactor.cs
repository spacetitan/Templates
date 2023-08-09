using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Transform interactPoint = null;
    public float interactRadius = 0.5f;
    public LayerMask interactMask;

    public Transform carryPoint = null;
    public GameObject carriedObject = null;

    private readonly Collider[] _colliders = new Collider[4];
    private int _numFound = 0;

    void Update()
    {
        DropItem();
       
        this._numFound = Physics.OverlapSphereNonAlloc(this.interactPoint.position, this.interactRadius, this._colliders, this.interactMask);
        if(this._numFound > 0)
        {
            IInteractable interactable = this._colliders[0].GetComponent<IInteractable>();

            if(interactable != null && InputManager.Instance.InteractInput())
            {
                interactable.Interact(this);
            }
        }
    }

    void DropItem()
    {
         if(this.carriedObject != null && InputManager.Instance.InteractInput())
        {
            this.carriedObject.transform.SetParent(null);
            this.carriedObject = null;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(this.interactPoint.position, this.interactRadius);
    }
}
