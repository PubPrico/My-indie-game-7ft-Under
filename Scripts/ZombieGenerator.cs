using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public MazeGenerator mazeGen;
    int x, z;
    int posX, posZ;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        x = mazeGen._mazeWidth;
        z = mazeGen._mazeDepth;

        posX = Random.Range(0, x);
        posZ = Random.Range(0, z);

        Instantiate(prefab, new Vector3(posX, 0f, posZ), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
