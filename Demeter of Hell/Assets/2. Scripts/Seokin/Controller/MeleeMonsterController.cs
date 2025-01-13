using UnityEngine;

public class MeleeMonsterController : NavAgent2D
{
    bool isEnter = false;
    private void Update()
    {
        base.Update();

        if (isEnter)
        {
            if (currentCooltime <= 0)
            {
                anim.SetTrigger("Attack");
                currentCooltime = attackCooltime;
            }

            anim.SetTrigger("Run");
        }

        if (currentCooltime > 0)
        {
            currentCooltime -= Time.deltaTime;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //세계수 이외의 타겟과 부딪히면 그 타겟을 계속 따라감
        target = collision.transform;
        
            
        isEnter = true;

    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    target = collision.transform;
    //    anim.SetTrigger("Attack");
    //    //if (attackDelay <= 0)
    //    //    anim.SetTrigger("Attack");
    //    //else
    //    //    anim.SetTrigger("Idle");

    //}

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        target = worldTreePosition;
        anim.SetTrigger("Run");
        isEnter = false;
    }
}
