using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Seed"))
        {
            gameObject.transform.parent.GetComponent<Item>().Data.UpdateSeed(1);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Rice"))
        {
            gameObject.transform.parent.GetComponent<Item>().Data.UpdateRice(1);
            Destroy(collision.gameObject);
        }
    }
}
