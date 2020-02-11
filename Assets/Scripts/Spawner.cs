using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                players.Add(Instantiate(newPlayer, new Vector3(0, 2, 0), Quaternion.identity));
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

}
