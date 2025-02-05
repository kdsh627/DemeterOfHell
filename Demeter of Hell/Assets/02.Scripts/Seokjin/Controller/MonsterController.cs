using UnityEngine;

public class MonsterController : CreatureController
{
    Animator animator;
    public Transform player;
    public float attackCooltime = 4;
    public float attackDelay;
    public float currentCooltime;
    public GameObject[] dropTable;
    public GameObject experience;
    //드랍 주사위 돌리는 수
    public float dropCount;
    //아이템의 드랍 가중치
    public float seed;
    public float ricePlant;
    public float nothing;
    //드랍 되는 아이템 범위
    public float dropRadius = 3f;
    public float attackDamage;



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
        float dropSum = seed + ricePlant + nothing;

        float dropValue = Random.Range(0, dropSum);

        GameObject dropItem;
        


        if (0<= dropValue && dropValue < seed)
        {
            
            dropItem = PoolManager.Instance.Pop(dropTable[0]);
            dropItem.transform.position = transform.position;
        }
        else if(seed<= dropValue && dropValue < seed+ricePlant)
        {
            dropItem = PoolManager.Instance.Pop(dropTable[1]);
            dropItem.transform.position = transform.position;

        }

        dropItem = PoolManager.Instance.Pop(experience);
        dropItem.transform.position = transform.position;


    }

    protected override void OnDead()
    {
        base.OnDead();

        for(int i = 0; i< dropCount; i++)
        {
            Drop();
        }

        
        
    }
}
