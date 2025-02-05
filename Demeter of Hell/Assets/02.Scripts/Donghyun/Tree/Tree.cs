using UnityEngine;

public class Tree : CreatureController
{
    [SerializeField] private TreeDataSO treeData;

    private void Start()
    {
        Hp = treeData.Hp;
        MaxHp = treeData.Hp;
        UIManager.Instance.TreeHpUIUpdate((int)Hp, (int)MaxHp);
    }

    public override void OnDamaged(float damage)
    {
        base.OnDamaged(damage);
        UIManager.Instance.TreeHpUIUpdate((int)Hp, (int)MaxHp); //형변환 다시한번 체크해야함
    }

    protected override void OnDead()
    {
        GameManager.Instance.GameOver();
    }
}
