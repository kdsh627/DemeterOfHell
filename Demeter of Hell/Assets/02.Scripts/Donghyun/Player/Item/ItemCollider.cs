using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Seed"))
        {
            gameObject.transform.parent.GetComponent<Player>().ItemData.UpdateSeed(1);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Rice"))
        {
            gameObject.transform.parent.GetComponent<Player>().ItemData.UpdateRice(1);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Experience"))
        {
            gameObject.transform.parent.GetComponent<Player>().PlayerData.UpdateExperience(1);
            Destroy(collision.gameObject);
        }
    }
}
