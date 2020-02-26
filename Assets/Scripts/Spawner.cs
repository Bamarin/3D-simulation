using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject food;
    public GameObject monster;
    private int randNum;
    private static List<GameObject> Brains;
    public static List<GameObject> Monsters;
    private static Vector3 blenderRotation;
    private static Vector3 brainOff;

    private void Start()
    {
        Brains = new List<GameObject>();
        Monsters = new List<GameObject>();
        blenderRotation = new Vector3(-90, 0, 0);
        brainOff = new Vector3(0f, 0.365f, 0f);
        for(int i=0; i<5; i++)
        {
            Monsters.Add(Instantiate(monster, GetRandomLocation(), Quaternion.identity));
        }

    }
    void Update()
    {
        randNum = Random.Range(0, 999);
        switch (randNum)
        {
            case 1:
                Brains.Add(Instantiate(food, GetRandomLocation()+brainOff,Quaternion.Euler(blenderRotation)));
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


    public static void DespawnFood(GameObject food)
    {
        Destroy(food);
        Brains.Remove(food);
    }
    public static void Kill(StateController controller)
    {
        GameObject monster = controller.gameObject;
        if (monster.tag == "smart")
        {
            controller.myBrain.GetComponent<SphereCollider>().enabled = true;
            Brains.Add(Instantiate(controller.myBrain, monster.transform.position + brainOff, monster.transform.rotation*Quaternion.Euler(blenderRotation)));
        }
        Destroy(monster);
        Monsters.Remove(monster);
    }
    public static void Duplicate(StateController controller)
    {
        Monsters.Add(Instantiate(controller.gameObject, controller.gameObject.transform.position, controller.gameObject.transform.rotation));
    }
}
