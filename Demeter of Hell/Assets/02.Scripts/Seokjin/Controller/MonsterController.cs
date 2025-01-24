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
    public GameObject[] dropTable;
    //드랍 주사위 돌리는 수
    public float dropCount;
    //아이템의 드랍 가중치
    public float seed;
    public float ricePlant;
    public float nothing;
    //드랍 되는 아이템 범위
    public float dropRadius = 3f;




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
        Vector3 RandomPosition = Random.insideUnitCircle * dropRadius;


        if (0<= dropValue && dropValue < seed)
        {
            
            dropItem = PoolManager.Instance.Pop(dropTable[0]);
            dropItem.transform.position = transform.position+ RandomPosition;
        }
        else if(seed<= dropValue && dropValue < ricePlant)
        {
            dropItem = PoolManager.Instance.Pop(dropTable[1]);
            dropItem.transform.position = transform.position+ RandomPosition;

        }

        


    }

    protected override void OnDead()
    {
        base.OnDead();

        for(int i = 0; i< dropCount; i++)
        {
            Drop();
        }


        PoolManager.Instance.Push(gameObject);
    }
}
