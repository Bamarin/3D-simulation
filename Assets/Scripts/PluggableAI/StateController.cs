using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {

    public State curremtState;
    //public EnemyStats enemyStats;
    public Transform eyes;
    public State remainState;
    public float deathRate;
    public float duplicationRate;
    public Animator animator;


	public NavMeshAgent navMeshAgent;
    //[HideInInspector] public Complete.TankShooting tankShooting;
    public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public GameObject chaseTarget;
    [HideInInspector] public Transform chaseTargetLocation;
    [HideInInspector] public Vector3 target;

	private bool aiActive;


	void Awake () 
	{
        //tankShooting = GetComponent<Complete.TankShooting>();
        navMeshAgent = GetComponent<NavMeshAgent> ();
        animator = GetComponent<Animator> ();
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
        navMeshAgent.SetDestination(transform.position);
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
    public Vector3 RandomNavmeshLocation(StateController controller, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

}
