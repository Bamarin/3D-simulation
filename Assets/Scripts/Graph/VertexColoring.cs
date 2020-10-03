using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VertexColoring : MonoBehaviour
{
    public HeatMapType heatMapType;
    public static uint[,] heatMap = new uint[65, 65];
    public static uint[,] deathMap = new uint[65, 65];
    public static uint[,] spawnMap = new uint[65, 65];
    public static uint maxHeat = 10;

    private Mesh mesh;
    private Vector3[] vertices;
    private Color32[] colors;

    private int x, y;
    private float ptile;

    public enum HeatMapType { mostVisited, spawn, death };

    // Start is called before the first frame update
    void Start()
    {
        

        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        // create new colors array where the colors will be created.
        colors = new Color32[vertices.Length];

        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            x = Mathf.RoundToInt(vertices[i].x * 64);
            y = Mathf.RoundToInt(vertices[i].y * 64);

            switch (heatMapType){

                case HeatMapType.mostVisited:
                    ptile = (float)heatMap[x, y] / maxHeat;
                    colors[i] = Color32.Lerp(Color.blue, Color.yellow, ptile);
                    break;

                case HeatMapType.spawn:
                    colors[i] = Color32.Lerp(Color.black, Color.green, spawnMap[x,y]);
                    break;

                case HeatMapType.death:
                    colors[i] = Color32.Lerp(Color.black, Color.red, deathMap[x, y]);
                    break;
            }

        }

        // assign the array of colors to the Mesh.
        mesh.colors32 = colors;
    }
}
