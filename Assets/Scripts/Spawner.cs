using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject spawnable;
    private int randNum;
    private static List<GameObject> spawnedEntities;
    private Vector3 blenderRotation;
    private Vector3 brainOff;

    private void Start()
    {
        spawnedEntities = new List<GameObject>();
        blenderRotation = new Vector3(-90, 0, 0);
        brainOff = new Vector3(0f, 0.365f, 0f);

    }
    void Update()
    {
        randNum = Random.Range(0, 999);
        switch (randNum)
        {
            case 1:
                spawnedEntities.Add(Instantiate(spawnable, GetRandomLocation()+brainOff,Quaternion.Euler(blenderRotation)));
                break;
            default:
                break;

        }
    }

    Vector3 GetRandomLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        // Pick the first indice of a random triangle in the nav mesh
        int t = Random.Range(0, navMeshData.indices.Length - 3);

        // Select a random point on it
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);

        return point;
    }

    public static void Despawn(GameObject entity)
    {
        Destroy(entity);
        spawnedEntities.Remove(entity);
    }
}
