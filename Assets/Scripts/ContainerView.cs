using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Events;

public class ContainerView : AbstractInteractiveObject
{
    [SerializeField] RecyclingObjectsType recyclingObjectsType;
    [SerializeField] Collider _triggerCollider;
    public override void OnInteractButtonPressed()
    {
        return;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<IHoldRecyclingItem>() != null)
        {
            if(Input.GetMouseButtonDown(0))
            {
                AddPointForRecyclingobject(other.gameObject.GetComponent<IHoldRecyclingItem>().ItemType(), other.gameObject);
            }
        }
    }

    void AddPointForRecyclingobject(RecyclingObjectsType type, GameObject contexObject)
    {
        if (type != recyclingObjectsType) return;
           switch(type)
        {
            case RecyclingObjectsType.Null
                : break;

            case RecyclingObjectsType.Paper:
                GameEvents.OnPaperPointsChanged.Invoke();
                contexObject.GetComponent<IHoldRecyclingItem>().RemoveObjectFromHand();
                break;

            case RecyclingObjectsType.Can:
                GameEvents.OnCanPointsChanged.Invoke();
                contexObject.GetComponent<IHoldRecyclingItem>().RemoveObjectFromHand();
                break;

            case RecyclingObjectsType.Plastic:
                GameEvents.OnPlasticPointsChanged.Invoke();
                contexObject.GetComponent<IHoldRecyclingItem>().RemoveObjectFromHand();
                break;
        }


    }

}

public enum RecyclingObjectsType {Null, Plastic, Can, Paper }

internal record TagNames
{
    internal const string playerTagName = "Player";
}