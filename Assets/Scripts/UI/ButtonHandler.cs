using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject obj;
    
    public void SetVizType(string type)
    {
        VertexColoring.HeatMapType t;
        switch (type)
        {
            case "spawn":
                t = VertexColoring.HeatMapType.spawn;
                break;
            case "death":
                t = VertexColoring.HeatMapType.death;
                break;
            default:
                t = VertexColoring.HeatMapType.mostVisited;
                break;
        }

        obj.GetComponent<VertexColoring>().heatMapType = t;
    }

    public void ToggleSlider()
    {
        VertexColoring.toggleAutoValue();
        obj.GetComponent<Slider>().interactable = !obj.GetComponent<Slider>().interactable;
    }

    public void UpdateValue()
    {
        VertexColoring.updateValue(gameObject.GetComponent<Slider>().value);
        
    }
}
