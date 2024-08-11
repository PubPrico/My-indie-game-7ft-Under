using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGenerator : MonoBehaviour
{
    public MazeGenerator mazeGen;
    int x, z;
    int doorPosX, doorPosZ;
    public GameObject doorPrefab;
    // Start is called before the first frame update
    void Start()
    {
        x = mazeGen._mazeWidth;
        z = mazeGen._mazeDepth;

        doorPosX = Random.Range(0, x);
        doorPosZ = Random.Range(0, z);

        Instantiate(doorPrefab, new Vector3(doorPosX, 0f, doorPosZ), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
