using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float damage=1;
        if (1 <= GameManager.Instance.CurrentWave && GameManager.Instance.CurrentWave < 5)
        {

            damage = 1;
        }
        else if (5 <= GameManager.Instance.CurrentWave && GameManager.Instance.CurrentWave < 10)
        {
            
            damage = 2;
        }
        else if (10 == GameManager.Instance.CurrentWave)
        {
            
            damage = 3;
        }

        if (collision.gameObject.CompareTag("Flower")|| collision.gameObject.CompareTag("Player"))
        {
            CreatureController mc = collision.gameObject.GetComponent<CreatureController>();

            mc.OnDamaged(damage);
        }
    }


}
