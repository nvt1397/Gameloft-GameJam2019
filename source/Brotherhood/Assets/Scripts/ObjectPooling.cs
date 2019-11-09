using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private ObjectPooling _instance;
    public GameObject ObjToPool;
    private List<GameObject> _pool;
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
    public void InitPool(int poolSize)
    {
        _pool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            _pool.Add(Instantiate(ObjToPool));
            _pool[i].SetActive(false);
        }

    }

    public GameObject GetObjFromPool(Vector2 pos,Quaternion rot)
    {
        GameObject obj;
        if (_pool.Count == 0)
            _pool.Add(Instantiate(ObjToPool));
            obj = _pool[_pool.Count - 1];
        obj.SetActive(true);
        obj.transform.position = pos;
        obj.transform.rotation = rot;
        _pool.RemoveAt(_pool.Count - 1);
        return obj;
    }

    public void PutObjToPool(GameObject go)
    {
        go.SetActive(false);
        _pool.Add(go);
    }

}
