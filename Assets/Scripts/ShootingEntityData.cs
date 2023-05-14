using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEntityData", menuName = "ShootingEntityData")]
public class ShootingEntityData : ScriptableObject
{

    [SerializeField] GameObject[] _bulletPrefabs;
    public GameObject bulletPrefab { get { return _bulletPrefabs[Random.Range(0,_bulletPrefabs.Length)]; } }


}


