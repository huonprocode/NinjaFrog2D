using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolingManager : MonoBehaviour
{
    private static ObjectPoolingManager instance;
    public static ObjectPoolingManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObjectPoolingManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("ObjectPoolingManager");
                    instance = obj.AddComponent<ObjectPoolingManager>();
                }
            }
            return instance;
        }
    }

    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    public void CreatePool(string key, GameObject prefab, int poolSize)
    {
        if (poolDictionary.ContainsKey(key))
        {
            Debug.LogWarning($"Pool for " + key + " already exists.");
            return;
        }

        Queue<GameObject> objectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }

        poolDictionary.Add(key, objectPool);
    }

    public GameObject GetObjectFromPool(string key, GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(key))
        {
            Debug.LogError($"Pool for " + key + " doesn't exist.");
            return null;
        }

        Queue<GameObject> objectPool = poolDictionary[key];
        if (objectPool.Count == 0)
        {
            Debug.LogWarning($"Pool for " + key + " is empty. Instantiating new object.");
            GameObject newObj = Instantiate(prefab);
            newObj.SetActive(true);
            newObj.transform.position = position;
            newObj.transform.rotation = rotation;
            return newObj;
        }

        GameObject obj = objectPool.Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }

    public void ReturnObjectToPool(string key, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(key))
        {
            Debug.LogError($"Pool for " + key + " doesn't exist.");
            return;
        }

        obj.SetActive(false);
        poolDictionary[key].Enqueue(obj);
    }
}