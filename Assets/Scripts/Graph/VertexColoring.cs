using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VertexColoring : MonoBehaviour
{
    public static int[,] vertexValue = new int[65, 65];

    private static Mesh mesh;
    private static Vector3[] vertices;
    private static Color32[] colors;

    private int x, y;

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
            x = Mathf.RoundToInt(vertices[i].x*64);
            y = Mathf.RoundToInt(vertices[i].y*64);

            //Debug.Log("i:" + i / 65 + " j:" + i % 65 + " value:" + vertexValue[i / 65, i % 65]);
            if (vertexValue[x,y] == 1)
            {
                colors[i] = Color.red;
                //colors[i] = Color32.Lerp(Color.red, Color.green, vertices[i].y);
                //Debug.Log("x:" + x + "; y:" + y + "; z:" + vertices[i].z);
            }
        }

        // assign the array of colors to the Mesh.
        mesh.colors32 = colors;
    }
}
