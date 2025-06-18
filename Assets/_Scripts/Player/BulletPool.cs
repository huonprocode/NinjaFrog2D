using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    public GameObject bulletPref;
    public int poolSize = 20;
    public Queue<GameObject> bulletPool;

    void Awake()
    {
        Instance = this;

        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPref, transform);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }
    public GameObject SpawnBullet(Vector3 position, Quaternion rotation)
    {
        GameObject bullet;
        if (bulletPool.Count > 0)
        {
            bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
        }
        else
        {
            bullet = Instantiate(bulletPref, transform);
        }
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;

        return bullet;
    }

    public void DespawnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
