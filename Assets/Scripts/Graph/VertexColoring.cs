using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VertexColoring : MonoBehaviour
{
    public static uint[,] heatMap = new uint[65, 65];
    public static uint maxHeat = 10;

    private static Mesh mesh;
    private static Vector3[] vertices;
    private static Color32[] colors;

    private int x, y;
    private float ptile;

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

            ptile = (float)heatMap[x, y] / maxHeat;

            colors[i] = Color32.Lerp(Color.black, Color.green, ptile);
            //Debug.Log(ptile);
        }

        // assign the array of colors to the Mesh.
        mesh.colors32 = colors;
    }
}
