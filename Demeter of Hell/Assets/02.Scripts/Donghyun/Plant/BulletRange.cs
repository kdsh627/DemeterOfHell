using UnityEngine;
using DG.Tweening;

public class BulletRange : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;
    [SerializeField] private float maxTime;
    [SerializeField] Transform bulletTransform;

    private Transform targetTransform;
    private Vector2 direction;
    private float currentTime;
    bool isShoot;

    private void Awake()
    {
        currentTime = maxTime;
        isShoot = false;
    }

    private void Update()
    {
        if(isShoot) 
        {
            TimeUpdate();
        }
    }

    private void TimeUpdate()
    {
        if (currentTime > Mathf.Epsilon)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0.0f;
            ShootEnd();
        }
    }

    private void Shoot(Transform transform)
    {
        isShoot = true;
        bullet.SetActive(true);
        targetTransform = transform;
        direction = targetTransform.position - bulletTransform.position;
        direction.Normalize();
        bullet.GetComponent<Rigidbody2D>().AddForce(direction * speed);
    }

    public void ShootEnd()
    {
        bullet.transform.position = bulletTransform.position;
        bullet.SetActive(false);
        currentTime = maxTime;
        isShoot = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isShoot && collision.CompareTag("Monster"))
        {
            Shoot(collision.transform);
        }
    }
}
