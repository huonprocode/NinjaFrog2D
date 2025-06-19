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

    private Dictionary<GameObject, Queue<GameObject>> poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();

    public void CreatePool(GameObject prefab, int poolSize)
    {
        if (poolDictionary.ContainsKey(prefab))
        {
            Debug.LogWarning($"Pool for {prefab.name} already exists.");
            return;
        }

        Queue<GameObject> objectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }

        poolDictionary.Add(prefab, objectPool);
    }

    public GameObject GetObjectFromPool(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(prefab))
        {
            Debug.LogError($"Pool for {prefab.name} doesn't exist.");
            return null;
        }

        Queue<GameObject> objectPool = poolDictionary[prefab];
        if (objectPool.Count == 0)
        {
            GameObject newObj = Instantiate(prefab);
            newObj.SetActive(false);
            objectPool.Enqueue(newObj);
        }

        GameObject obj = objectPool.Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }

    public void ReturnObjectToPool(GameObject prefab, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(prefab))
        {
            Debug.LogError($"Pool for {prefab.name} doesn't exist.");
            return;
        }

        obj.SetActive(false);
        poolDictionary[prefab].Enqueue(obj);
    }
}