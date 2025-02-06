using UnityEngine;

public class Tree : CreatureController
{
    [SerializeField] private TreeDataSO treeData;

    private float time = 5.0f;
    private float invincibleTime = 0.3f;

    private bool isInvincible;
    private void Start()
    {
        Hp = treeData.Hp;
        MaxHp = treeData.Hp;
        UIManager.Instance.TreeHpUIUpdate((int)Hp, (int)MaxHp);
    }

    private void Update()
    {
        Regenerate();

        if(isInvincible)
        {
            if(invincibleTime > Mathf.Epsilon)
            {
                invincibleTime -= Time.deltaTime;
            }
            else
            {
                invincibleTime = 0.0f;
                isInvincible = false;
            }
        }
    }

    private void Regenerate()
    {
        if(time > Mathf.Epsilon) 
        {
            time -= Time.deltaTime;
        }
        else
        {
            if (MaxHp > Hp)
            {
                Hp += 1;
                UIManager.Instance.TreeHpUIUpdate((int)Hp, (int)MaxHp);
            }
            time = 1.0f;
        }
    }

    public override void OnDamaged(float damage)
    {
        if(!isInvincible)
        {
            base.OnDamaged(damage);
            UIManager.Instance.TreeHpUIUpdate((int)Hp, (int)MaxHp); //형변환 다시한번 체크해야함
            invincibleTime = 0.3f; 
            isInvincible = true;
        }
    }

    protected override void OnDead()
    {
        GameManager.Instance.GameOver();
    }
}
