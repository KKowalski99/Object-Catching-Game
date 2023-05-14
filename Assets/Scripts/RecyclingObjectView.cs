using UnityEngine;
using Interfaces;
using System;
public class RecyclingObjectView : MonoBehaviour, IGrabbable
{
    [SerializeField] RecyclingObjectsType recyclingObjectsType;
    Action NotifyIfDisable;
    public RecyclingObjectsType ObjectType()
    {
        return recyclingObjectsType;
    }
    public void HideObject()
    {
        if (NotifyIfDisable != null) NotifyIfDisable.Invoke();
        gameObject.SetActive(false);
    }
    
   public void ObjectDisableCallback(Action callback)
    {

        NotifyIfDisable = callback;
    }

}
