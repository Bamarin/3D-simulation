using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
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
    }
}
