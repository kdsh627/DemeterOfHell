using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Flower") || other.CompareTag("Player"))
        { 
            PoolManager.Instance.Push(gameObject);
        }
    }

    

}
