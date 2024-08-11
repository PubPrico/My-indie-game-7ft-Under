using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerStat>().TakeDamage(10);
        }
    }
}
