using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Eat")]
public class EatAction : Action
{
    public GameObject food;

    public override void Act(StateController controller)
    {
        Eat(controller);
    }

    private void Eat(StateController controller)
    {
        if (controller.navMeshAgent.remainingDistance <= (food.GetComponent<SphereCollider>().radius)+1 && !controller.navMeshAgent.pathPending && controller.chaseTargetLocation != null)
        {
            controller.animator.SetBool("IsWalking", false);
            Spawner.DespawnFood(controller.chaseTarget);
            controller.stateTimeElapsed = 0;
            if(controller.gameObject.tag == "smart")
            {
                controller.myBrain.GetComponent<MeshRenderer>().enabled=false;
                controller.gameObject.tag = "stupid";
                Spawner.Duplicate(controller);
            }
            controller.myBrain.GetComponent<MeshRenderer>().enabled=true;
            controller.gameObject.tag = "smart";
        }
    }
}
