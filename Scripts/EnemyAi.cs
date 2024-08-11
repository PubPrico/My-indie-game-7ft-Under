using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float speed;
    public float raycastDistance, lookDistance;
    private Vector3 direction;
    private bool isPatrolling = true;

    bool turnRight;

    RaycastHit hitInfront;
    Ray frontRay;

    public float stoppingDistance = 1.5f;
    Transform player;

    Ray rayF, rayB;
        RaycastHit hitF, hitB;
        
    void Start()
    {

        if (Physics.Raycast(rayF, out hitF, raycastDistance) && Physics.Raycast(rayB, out hitB, raycastDistance))
        {
            // If the ray hits an obstacle, change direction
            if (hitF.collider.CompareTag("WallCollider") && hitF.collider.CompareTag("WallCollider"))
            {
                Debug.Log("Sucessful");
                transform.Rotate(Vector3.up, 90f);

                turnRight = false;
            }
            
        }
    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // Move the enemy forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        /*if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            // Calculate the direction to the player, ignoring the Y-axis
            Vector3 directionToPlayer = new Vector3(player.position.x - transform.position.x, 0f, player.position.z - transform.position.z).normalized;

            // Move the enemy towards the player on the X and Z axes
            transform.Translate(directionToPlayer * speed * Time.deltaTime);
        }*/

        // Cast a ray forward to check for obstacles
        frontRay = new Ray(transform.position, transform.forward);

        // Check if the ray hits something
        if (Physics.Raycast(frontRay, out hitInfront, raycastDistance))
        {
            // If the ray hits an obstacle, change direction
            if (hitInfront.collider.CompareTag("WallCollider"))
            {
                ChangeDirection();
            }
            
        }

    
    }


    void ChangeDirection()
    {
        Ray rightRay = new Ray(transform.position, transform.right);
        RaycastHit hitRight;
        Ray leftRay = new Ray(transform.position, -transform.right);
        RaycastHit hitLeft;
        
        //TURN LEFT
        if (Physics.Raycast(rightRay, out hitRight, raycastDistance))
        {
            // If the ray hits an obstacle, change direction
            if (hitInfront.collider.CompareTag("WallCollider"))
            {
                Debug.Log("Turn Left");
                transform.Rotate(Vector3.up, -90f);

                turnRight = true;
            }
            
        }
        //TURN RIGHT
        else if (Physics.Raycast(leftRay, out hitLeft, raycastDistance))
        {
            
            if (hitInfront.collider.CompareTag("WallCollider"))
            {
                Debug.Log("Turn Right");
                transform.Rotate(Vector3.up, 90f);

                turnRight = false;
            }
        }
        else
        {
            transform.Rotate(Vector3.up, 180f);
        }
        

        
    }

    void OnCollisionTrigger(Collider collider)
    {
        if(collider.CompareTag("WallCollider"))
        {
            Debug.Log("Choosing Road");
                if(Random.Range(0,2) == 0 && hitInfront.collider.CompareTag("WallCollider"))
                {
                    Debug.Log("Turn Right");
                    transform.Rotate(Vector3.up, 90f);
                }
                else if(Random.Range(0,2) == 1 && hitInfront.collider.CompareTag("WallCollider"))
                {
                    Debug.Log("Turn Left");
                    transform.Rotate(Vector3.up, -90f);
                }
        }
    }
}
