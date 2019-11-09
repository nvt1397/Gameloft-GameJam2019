using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private static ObjectPooling _instance;
    private List<GameObject> _pool;
    private GameObject _objToPool;
    public int getPoolSize()
    {
        return _pool.Count;
    }
    void Awake()
    {
        _instance = this;
    }
    public ObjectPooling myInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ObjectPooling();       
            }
            return _instance;
        }
    }
    public void InitPool(int poolSize,GameObject objToPool)
    {
        _objToPool = objToPool;
        _pool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(objToPool);       
            obj.SetActive(false);
            _pool.Add(obj);
        }

    }

    public GameObject GetObjFromPool(Vector2 pos,Quaternion rot)
    {
        GameObject obj;
        if (_pool.Count == 0)
            _pool.Add(Instantiate(_objToPool));
            obj = _pool[_pool.Count - 1];   
        obj.transform.position = pos;
        obj.transform.rotation = rot;
        obj.SetActive(true);
        _pool.RemoveAt(_pool.Count - 1);
        return obj;
    }

    public void PutObjToPool(GameObject go)
    {
        go.SetActive(false);
        _pool.Add(go);
    }

}
