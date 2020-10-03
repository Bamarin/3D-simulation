using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Wander")]
public class WanderAction : Action
{
    private int i, j;

    public override void Act(StateController controller)
    {
        Wander(controller);
    }

    private void Wander(StateController controller)
    {
        if(controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            //controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            controller.navMeshAgent.SetDestination(controller.RandomNavmeshLocation(controller, 20f));
        }

        if (controller.CheckIfCountDownElapsed(controller.deathRate))
        {
            controller.animator.SetBool("IsDead", true);
            controller.navMeshAgent.isStopped = true;
            
        }
        else
        {
            i = (int)Math.Round((controller.transform.position.z / 40 + 0.5) * 64);
            j = (int)Math.Round((controller.transform.position.x / 40 + 0.5) * 64);
            VertexColoring.maxHeat = ++VertexColoring.heatMap[i, j] > VertexColoring.maxHeat ? VertexColoring.heatMap[i, j] : VertexColoring.maxHeat;
        }

    }
    
}
