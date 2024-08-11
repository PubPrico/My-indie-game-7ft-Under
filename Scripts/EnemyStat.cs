using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    EnemyAi enemyAi;
    Collider collider;
    public static float health = 50;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        enemyAi = GetComponent<EnemyAi>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("Enemy Dead");
            Dead();
        }
    }

    void Dead()
    {
        rb.constraints = RigidbodyConstraints.None;
        anim.enabled = false;
        enemyAi.enabled = false;
        //collider.enabled = false;
    }

}
