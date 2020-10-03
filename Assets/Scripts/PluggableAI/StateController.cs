using System;
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
    public GameObject myBrain;
    
    [HideInInspector] public Animator animator;
	[HideInInspector] public NavMeshAgent navMeshAgent;
    //[HideInInspector] public Complete.TankShooting tankShooting;
    public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public GameObject chaseTarget;
    [HideInInspector] public Transform chaseTargetLocation;
    [HideInInspector] public Vector3 target;
    [HideInInspector] public float stateTimeElapsed;

	private bool aiActive;
    private int i, j;


    void Awake () 
	{
        //tankShooting = GetComponent<Complete.TankShooting>();
        navMeshAgent = GetComponent<NavMeshAgent> ();
        animator = GetComponent<Animator> ();
        i = (int)Math.Round((transform.position.z / 40 + 0.5) * 64);
        j = (int)Math.Round((transform.position.x / 40 + 0.5) * 64);
        VertexColoring.spawnMap[i, j] = 1;
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
            OnExitState();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        //stateTimeElapsed = 0;
    }

    public Vector3 RandomNavmeshLocation(StateController controller, float radius)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
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
