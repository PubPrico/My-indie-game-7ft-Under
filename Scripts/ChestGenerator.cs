using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGenerator : MonoBehaviour
{
    public MazeGenerator mazeGen;
    public GameObject chestPrefab, leftRaycast, rightRaycast, frontRaycast, backRaycast;
    public LayerMask whatIsWall;
    public float distance;
    int wallCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(Physics.Raycast(transform.position, Vector3.left, distance, whatIsWall))
        {
            wallCount++;
        }
        if(Physics.Raycast(transform.position, Vector3.right, distance, whatIsWall))
        {
            wallCount++;
        }
        if(Physics.Raycast(transform.position, Vector3.forward, distance, whatIsWall))
        {
            wallCount++;
        }
        if(Physics.Raycast(transform.position, Vector3.back, distance, whatIsWall))
        {
            wallCount++;
        }


        if(wallCount >= 3)
        {
            int i = Random.Range(0, 100);
            if(i <= 20)
            {
                Instantiate(chestPrefab, transform.position, Quaternion.identity);
            }
            
        }
    }


}
