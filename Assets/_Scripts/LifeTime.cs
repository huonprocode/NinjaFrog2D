using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float lifeTime = 3f;
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }
}
