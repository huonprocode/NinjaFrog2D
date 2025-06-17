using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "ScriptableObject/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Base Enemy Settings")]
    public string enemyName = "New Enemy";
    public int maxHealth = 100;
    public int damage = 10;
    public float moveSpeed = 5f;
    //public int expDrop;
    public GameObject expPrefab;
}
