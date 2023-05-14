using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewVegetationSpawnData", menuName = "VegetationData")]
public sealed class PopulateSquareWithVegetationData : ScriptableObject
{

    [SerializeField] float _density;
    public float density { get { return _density; } }
    public GameObject[] _vegetationPrefabs;

    [SerializeField] float _offset;
   public float offset { get { return _offset + Random.Range(-0.5f, 0.5f); } }


}
