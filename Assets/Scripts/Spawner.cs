using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject newPlayer;
    private int randNum;
    private List<GameObject> players;

    private void Start()
    {
        players = new List<GameObject>();
        for(int i =0; i < 10; i++)
        {
            players.Add(Instantiate(newPlayer, new Vector3(0, 2, 0), Quaternion.identity));
        }
    }
    void Update()
    {
        randNum = Random.Range(0, 99);
        switch(randNum)
        {
            case 1:
                players.Add(Instantiate(newPlayer, GetRandomLocation(), Quaternion.identity));
                break;
            case 0:
                if (players.Count > 0)
                {
                    Destroy(players[0]);
                    players.RemoveAt(0);
                }
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

}
