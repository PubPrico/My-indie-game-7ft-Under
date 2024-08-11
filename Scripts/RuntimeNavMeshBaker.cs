using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RuntimeNavMeshBaker : MonoBehaviour
{
    //public NavMeshSurface navMeshSurface;

    void Start()
    {
        // Call the BakeNavMesh method after a delay or at a specific point in your game logic
        Invoke("BakeNavMesh", 1.0f);
    }

    void BakeNavMesh()
    {
        // Build the NavMesh for the specified NavMeshSurface
        //navMeshSurface.BuildNavMesh();

        // Optional: You can check if the NavMesh was successfully baked
        if (NavMesh.CalculateTriangulation().vertices.Length == 0)
        {
            Debug.LogError("Failed to bake NavMesh");
        }
        else
        {
            Debug.Log("NavMesh baked successfully");
        }
    }
}
