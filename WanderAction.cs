using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Wander")]
public class WanderAction : Action
{
    public override void Act(StateController controller)
    {
        Wander(controller);
    }

    private void Wander(StateController controller)
    {
        if(controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            //controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            controller.navMeshAgent.SetDestination(RandomNavmeshLocation(controller, 8f));
        }

    }
    public Vector3 RandomNavmeshLocation(StateController controller, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += controller.root.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
