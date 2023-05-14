using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public sealed class ShootingEntity : MonoBehaviour
{
    [SerializeField] ShootingEntityData _shootingEntityData;

    List<Projectile> projectiles = new List<Projectile>();

    [Range(0, 100)] [SerializeField] float _parabolaHeight;
    [Range(0, 100)] [SerializeField] float _fireRate = 10;

    [SerializeField] Transform _target;
    [SerializeField] Transform _control;
    Transform bullet;

    bool _nextShotIsReady = true;
    private void Start()
    {
        InvokeRepeating(nameof(LookAtTarget), 0, 0.1f);
    }


    public event Action<Projectile> _action = delegate { };

    float time;
    void Update()
    {
        if (!_target) return;

        time += Time.deltaTime;

        if (time > _fireRate && _nextShotIsReady)
        {
            _action -= ProjectileHasReachedTarget;
            _action += ProjectileHasReachedTarget;

            _control.position = (_target.position + transform.position)/2 + new Vector3(0,_parabolaHeight, 0);

            bullet = Instantiate(_shootingEntityData.bulletPrefab?.transform, transform.position, Quaternion.identity);
    

           var projectile = gameObject.AddComponent<Projectile>();
            projectile.SetupProjectile(transform.position, _target.position, bullet, _control, _action);
            projectiles.Add(projectile);
            time = 0;
            _nextShotIsReady = false;
        }
    }

   void LookAtTarget() => transform.LookAt(_target.transform);
   

    void ProjectileHasReachedTarget(Projectile projectile)
    {
        _nextShotIsReady = true;
    }

}
