using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Eat")]
public class EatAction : Action
{
    public override void Act(StateController controller)
    {
        Eat(controller);
    }

    private void Eat(StateController controller)
    {
        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance*10 && !controller.navMeshAgent.pathPending && controller.chaseTargetLocation != null)
        {
            Spawner.Despawn(controller.chaseTarget);
        }
    }
}
