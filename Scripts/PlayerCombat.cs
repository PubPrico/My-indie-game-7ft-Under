using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;
    Transform attackPoint;
    public float attackRange;
    float attackCD = 0.3f;
    bool canAttack;
    public LayerMask enemyLayers;
    public static int damage = 10;

    public Transform spawnBlood;
    public GameObject bloodPrefab;
    // Start is called before the first frame update
    void Start()
    {
        

    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canAttack)
        {
            
            Attack();

            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

            foreach(Collider enemy in hitEnemies)
            {
                Debug.Log("Hit" + enemy.name);
                EnemyStat.health -= damage;
                Instantiate(bloodPrefab, spawnBlood.position, Quaternion.identity);
            }
            
        }
        
        
    }

    void  Attack()
    {
        anim.SetTrigger("IsAttacking");
        StartCoroutine(AttackCooldownTimer());
    }

    IEnumerator AttackCooldownTimer()
    {
        // Set canAttack to false to prevent further attacks
        canAttack = false;

        // Wait for the specified cooldown time
        yield return new WaitForSeconds(attackCD);

        // Set canAttack to true, allowing the player to attack again
        canAttack = true;
    }



    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
