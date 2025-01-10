using UnityEngine;
using UnityEngine.AI;

public class NavAgent2D : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
