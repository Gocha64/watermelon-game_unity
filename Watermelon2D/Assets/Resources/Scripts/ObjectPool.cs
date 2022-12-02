using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    Queue<FruitsObject> poolingObjectQueue = new Queue<FruitsObject>();

    private void Awake()
    {
        Instance = this;

        Initialize(15);
    }

    private void Initialize(int initCount)
    {
        for(int i = 0; i < initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private FruitsObject CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<FruitsObject>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static FruitsObject GetObejct()
    {
        if(Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;

        }
    }

    public static void ReturnObject(FruitsObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
}
