using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletEnemyPrefab;

    void Awake()
    {
        ObjectPoolingManager.Instance.CreatePool(bulletPrefab, 10);
        ObjectPoolingManager.Instance.CreatePool(bulletEnemyPrefab, 10);
    }

}
