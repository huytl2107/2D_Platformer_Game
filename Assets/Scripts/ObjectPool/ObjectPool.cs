using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    private List<GameObject> _poolObjects = new List<GameObject>();
    [SerializeField] private int _amountToBool = 1;
    [SerializeField] private GameObject _bullet;
    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i<_amountToBool; i++)
        {
            GameObject obj = Instantiate(_bullet);
            obj.SetActive(false);
            _poolObjects.Add(obj);
        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i<_poolObjects.Count; i++)
        {
            if(!_poolObjects[i].activeInHierarchy)
            {
                return _poolObjects[i];
            }
        }
        return null;
    }
}
