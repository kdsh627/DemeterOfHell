using UnityEngine;

public class MeleeMonsterController : MonsterAttackController
{
    protected override void AfterAttack()
    {
        anim.SetTrigger("Run");

    }
}
