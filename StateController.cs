using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {

    public State curremtState;
    //public EnemyStats enemyStats;
    public Transform eyes;
    public Transform root;
    public State remainState;


	public NavMeshAgent navMeshAgent;
    //[HideInInspector] public Complete.TankShooting tankShooting;
    public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public Vector3 target;

	private bool aiActive;


	void Awake () 
	{
        //tankShooting = GetComponent<Complete.TankShooting>();
        navMeshAgent = GetComponent<NavMeshAgent> ();
	}

    //public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
    //{
    //	wayPointList = wayPointsFromTankManager;
    //	aiActive = aiActivationFromTankManager;
    //	if (aiActive) 
    //	{
    //		navMeshAgent.enabled = true;
    //	} else 
    //	{
    //		navMeshAgent.enabled = false;
    //	}
    //}
    void Start()
    {
        navMeshAgent.SetDestination(root.position);
        navMeshAgent.enabled = true;
    }

    private void Update()
    {
        //if (!aiActive)
        //    return;
        curremtState.UpdateState(this);
    }

    private void OnDrawGizmos()
    {
        if (curremtState != null && eyes != null)
        {
            Gizmos.color = curremtState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, 1f);
        }
    }

    public void TransitionToState(State nextState)
    {
        if(nextState != remainState)
        {
            curremtState = nextState;
        }
    }
}