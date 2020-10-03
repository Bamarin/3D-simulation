using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    private int i, j;
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        try
        {
            controller.navMeshAgent.destination = controller.chaseTargetLocation.position;
        }
        catch (MissingReferenceException)
        {
            controller.curremtState = controller.curremtState.transitions[0].falseState;
        }
        controller.navMeshAgent.isStopped = false;
        i = (int)Math.Round((controller.transform.position.z / 40 + 0.5) * 64);
        j = (int)Math.Round((controller.transform.position.x / 40 + 0.5) * 64);
        VertexColoring.maxHeat = ++VertexColoring.heatMap[i, j] > VertexColoring.maxHeat ? VertexColoring.heatMap[i, j] : VertexColoring.maxHeat;

    }
}
