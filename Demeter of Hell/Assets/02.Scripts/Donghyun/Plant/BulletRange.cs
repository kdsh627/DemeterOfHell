using UnityEngine;
using DG.Tweening;

public class BulletRange : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private Transform bulletTransform;
    bool isShoot;

    private void Awake()
    {
        bulletTransform = gameObject.transform;
        isShoot = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.tag);

        if (!isShoot && collision.CompareTag("Monster"))
        {
            isShoot = true;
            bullet.SetActive(true);
            transform.DOMove(collision.transform.position, 0.5f).OnComplete(() =>
            {
                isShoot = false;
                bullet.transform.position = bulletTransform.position;
                bullet.SetActive(false);
            });
        }
    }
}
