using UnityEngine;
using UnityEngine.AI;

public class NavAgent2D : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform worldTreePosition;
    public Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        //시작 시 첫 목표는 세계수
        target = worldTreePosition;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        target = collision.transform;
        
        Debug.Log("d");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        target = worldTreePosition;
    }
}
