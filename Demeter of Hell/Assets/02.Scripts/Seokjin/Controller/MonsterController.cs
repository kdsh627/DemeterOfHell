using UnityEngine;
using UnityEngine.UI;
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

    protected virtual void Drop()
    {

    }
}
