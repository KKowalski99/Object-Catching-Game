using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#nullable enable
public sealed class Projectile : MonoBehaviour
{

    Vector3 _startPoint;
    Vector3 _endPoint;
    Transform _bullet;
    Transform _control;
    float t;
    float _speed = 0.5f;
    Action<Projectile> OnBulletReachingTarget;
    RecyclingObjectView _bulletObjectReferance;

    bool bulletIsMoving;

   public event Action callback = delegate { };
    private void Start()
    {
        _bulletObjectReferance = _bullet.gameObject.GetComponent<RecyclingObjectView>();

        if(_bulletObjectReferance != null)
        {
            callback -= BulletDisable;
            callback += BulletDisable;
            _bulletObjectReferance.ObjectDisableCallback(callback);
        }
       

    }
    private void FixedUpdate()
    {
        if (bulletIsMoving == false)
        {
            Debug.LogWarning($"Object {this} has not been destroyed after reaching target");
            return;
        }
        
            t += Time.deltaTime * _speed;

            _bullet.transform.position = evaluate(t);
            _bullet.transform.forward = evaluate(t /+ 0.001f) - _bullet.transform.position;

            if(t >= 1)
            {
                bulletIsMoving = false;
                DestroySelf(true);
            }
    }

    public void SetupProjectile(Vector3 startPoint, Vector3 endPoint, Transform bullet, Transform control, Action<Projectile> callback)
    {
        _startPoint = startPoint;
        _endPoint = endPoint; 
        _bullet = bullet;
        _control = control;
        OnBulletReachingTarget = callback;
        bulletIsMoving = true;

    }
    Vector3 evaluate(float t)
    {
        Vector3 ac = Vector3.Lerp(_startPoint, _control.position, t);
        Vector3 cb = Vector3.Lerp(_control.position, _endPoint, t);
        return Vector3.Lerp(ac, cb, t);
    }

    void DestroySelf(bool countAsMissed)
    {

        OnBulletReachingTarget.Invoke(this);
       if(countAsMissed) Events.GameEvents.OnMissedObjectCountChanged.Invoke();
        Destroy(_bullet.gameObject);
        Destroy(this);
    }

    void BulletDisable()
    {
     
        DestroySelf(false);
    }

}
