using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Interfaces;

public class PlayerObjectGrabbing : MonoBehaviour, IHoldRecyclingItem
{
    [SerializeField] Collider _triggerCollider;

    Actions _actions;
   [SerializeField] InputHandler _inputHandler;
  
    [SerializeField] GameObject[] recyclingObjects;

    bool _isHoldingObject;

    GameObject objectToGrab;
    RecyclingObjectsType _recyclingObjectHeld;

    private void Start()
    {
        _actions = _inputHandler?.actions;
    }
    private void Update()
    {
        if (_actions != null)
        {
            WaitForInput();
            if (!_isHoldingObject) ValidObjectsInRange();
        }
    }

    /// <summary>
    /// Simplify input for presentation purpose 
    /// TO DO: change to new input system
    /// </summary>
    void WaitForInput()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            if(!_isHoldingObject && objectToGrab != null) ActivateRelatedObjectInHand(objectToGrab.GetComponent<IGrabbable>().ObjectType());
        }
    }
    Collider[] colliders;
    public void ValidObjectsInRange()
    {

        Collider coll = _triggerCollider.GetComponent<Collider>();

       colliders = Physics.OverlapBox(coll.bounds.center, coll.bounds.extents, coll.transform.rotation);

        foreach (Collider c in colliders)
        {
            if (c.gameObject.GetComponent<IGrabbable>() != null)
            {
                objectToGrab = c.gameObject;
            }
        }

        if (objectToGrab != null) Events.GameEvents.ToggleGrabAction.Invoke(true);
        else Events.GameEvents.ToggleGrabAction.Invoke(false);


        if (objectToGrab != null && colliders.Contains(objectToGrab.gameObject.GetComponent<Collider>()) == false) objectToGrab = null;        
    }


    void ActivateRelatedObjectInHand(RecyclingObjectsType recyclingObjectsType)
    {
        switch(recyclingObjectsType)
        {
            case RecyclingObjectsType.Null:
                _recyclingObjectHeld = recyclingObjectsType;
                _isHoldingObject = false;
                break;

            case RecyclingObjectsType.Paper:
                recyclingObjects[0]?.SetActive(true);
                recyclingObjects[1]?.SetActive(false);
                recyclingObjects[2]?.SetActive(false);
                objectToGrab?.GetComponent<IGrabbable>().HideObject();
                _recyclingObjectHeld = recyclingObjectsType;
                Events.GameEvents.ToggleGrabAction.Invoke(false);
                _isHoldingObject = true;
                break;

            case RecyclingObjectsType.Can:
                recyclingObjects[0]?.SetActive(false);
                recyclingObjects[1]?.SetActive(true);
                recyclingObjects[2]?.SetActive(false);
                objectToGrab?.GetComponent<IGrabbable>().HideObject();
                _recyclingObjectHeld = recyclingObjectsType;
                Events.GameEvents.ToggleGrabAction.Invoke(false);
                _isHoldingObject = true;
                break;

            case RecyclingObjectsType.Plastic:
                recyclingObjects[0]?.SetActive(false);
                recyclingObjects[1]?.SetActive(false);
                recyclingObjects[2]?.SetActive(true);
                objectToGrab?.GetComponent<IGrabbable>().HideObject();
                _recyclingObjectHeld = recyclingObjectsType;
                Events.GameEvents.ToggleGrabAction.Invoke(false);
                _isHoldingObject = true;
                break;
        }
    }
    public RecyclingObjectsType ItemType()
    {
        return _recyclingObjectHeld;
    }

   public void RemoveObjectFromHand()
    {
        _recyclingObjectHeld = RecyclingObjectsType.Null;
        recyclingObjects[0]?.SetActive(false);
        recyclingObjects[1]?.SetActive(false);
        recyclingObjects[2]?.SetActive(false);
        _isHoldingObject = false;
    }

}
