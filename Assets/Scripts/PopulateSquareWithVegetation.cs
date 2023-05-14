using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public sealed class PopulateSquareWithVegetation : MonoBehaviour
{
   [Tooltip("Ground surface to populate with vegetation")] [SerializeField] Transform _squareObject;


  [SerializeField] PopulateSquareWithVegetationData _vegetationData;
    
   [SerializeField] Vector3 _size;
     MeshRenderer _meshRenderer;
  
    List<Transform> _vegetation = new List<Transform>();


    float _offset;
    float _density;
    int _prefabsArrayLength;


    private void Awake()
    {
        if(_squareObject.TryGetComponent(out MeshRenderer meshRenderer)) _meshRenderer = meshRenderer;
        _size = _meshRenderer.bounds.size;

        _offset = _vegetationData.offset;
        _density = _vegetationData.density;
        _prefabsArrayLength = _vegetationData._vegetationPrefabs.Length;
    }
    
    private void Start()
    {
        if (_vegetationData.density <= 0 || _vegetationData._vegetationPrefabs.Length < 1) return;
        else StartCoroutine(nameof(PopulateSquareCorutine));
    }

    float time;

    IEnumerator PopulateSquareCorutine()
    {
        for (float i = -(float)0.5 * _size.x; i < _size.x - 0.5 * _size.x; i += _density)
        {
            for (float j = -(float)0.5 * _size.z; j < _size.z - 0.5 * _size.z; j += _density)
            {
                var temp = Instantiate(_vegetationData._vegetationPrefabs[Random.Range(0, _prefabsArrayLength)], transform.position, Quaternion.identity, transform.parent = transform);
                temp.transform.position = new Vector3(i + _offset, 0f, j + _offset);
                time += Time.deltaTime;

        
                if (time > 500f)
                {
                    Debug.Log($"Vegetation instantiate process is taking too long, operation stopped: {this}");
                    break;
                }
            }
        }
        yield return null;
    }


/*

#if (UNITY_EDITOR)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; 
        Gizmos.DrawCube(transform.position, new Vector3(_size.x, _size.y, _size.z));
    }
#endif
*/
}
