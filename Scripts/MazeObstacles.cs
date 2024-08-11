using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeObstacles : MonoBehaviour
{
    public GameObject[] obstacles;
    int percent;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        if(MazeGenerator.lvl >= 10)
        {
            percent = Random.Range(0, 100);
            i = Random.Range(5, 8);

            if(percent <= 20)
            {
                obstacles[i].SetActive(true);
            }
        }
        else
        {
            percent = Random.Range(0, 100);
            i = Random.Range(0, 5);

            if(percent <= 20)
            {
                obstacles[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
