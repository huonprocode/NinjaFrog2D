using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItem : MonoBehaviour
{
    public int expAmount = 10;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerExperience>().GainEXP(expAmount);
            Destroy(this.gameObject);
        }
    }
}
