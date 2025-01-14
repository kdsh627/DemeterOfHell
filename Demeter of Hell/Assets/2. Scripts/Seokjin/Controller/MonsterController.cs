using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MonsterController : CreatureController
{
    Animator animator;
    public Transform player;
    public float attackCooltime = 4;
    public float attackDelay;
    public float currentCooltime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        //sprite = GetComponent<SpriteRenderer>();
    }



    // Update is called once per frame
    void Update()
    {
       
        if(attackDelay > 0)
        {
            attackDelay -= Time.deltaTime;
        }
        
    }

    //public void DirectionMonster(float target, float baseobj)//몬스터가 바라보는 방향에 따라 스프라이트를 뒤집음
    //{
    //    if(target<baseobj)
    //    {
    //        animator.SetFloat("Direction", -1);
            
    //    }
    //    else
    //    {
    //        animator.SetFloat("Direction", 1);
    //    }
    //}

}
