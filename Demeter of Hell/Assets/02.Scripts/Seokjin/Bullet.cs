using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Awake()
    {
        StartCoroutine(LifeTime());
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(5);
        PoolManager.Instance.Push(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        float damage=1;
        if (1 <= GameManager.Instance.CurrentWave && GameManager.Instance.CurrentWave < 5)
        {

            damage = 1;
        }
        else if (5 <= GameManager.Instance.CurrentWave && GameManager.Instance.CurrentWave < 9)
        {
            
            damage = 2;
        }
        else if (9 <= GameManager.Instance.CurrentWave && GameManager.Instance.CurrentWave <= 10)
        {
            
            damage = 3;
        }

        if (other.gameObject.CompareTag("Flower")|| other.gameObject.CompareTag("Player"))
        {
            Debug.Log(damage);
            CreatureController mc = other.gameObject.GetComponent<CreatureController>();
            if (mc == null)
            {
                Debug.Log("mc null");
            }
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.MonsterBulletDestroy);
            mc.OnDamaged(damage);
            PoolManager.Instance.Push(gameObject);
        }
        StopCoroutine(LifeTime());
    }


}
