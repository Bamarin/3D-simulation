using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decision/Look")]
public class LookDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * 40, Color.green);

        if(Physics.SphereCast(controller.eyes.position, 1, controller.eyes.forward, out hit, 40)
            && hit.collider.CompareTag("consumable"))
        {
            controller.chaseTarget = hit.collider.gameObject;
            controller.chaseTargetLocation = hit.transform;
            return true;
        }
        else { return false; }
    }
}
