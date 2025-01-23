using UnityEngine;
using UnityEngine.AI;
using UnityEngine.U2D;

public class NavAgent2D : MonsterController
{
    public NavMeshAgent agent;
    Transform worldTreePosition;
    public Transform target;
    public Animator anim;

    public SpriteRenderer sprite;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        //시작 시 첫 목표는 세계수
        //worldTreePosition = 
        
        
        //target = worldTreePosition;
    }

    public void Update()
    {
        //agent.SetDestination(target.position);


        //sprite.flipX = transform.position.x > target.position.x;
    }

    
}
