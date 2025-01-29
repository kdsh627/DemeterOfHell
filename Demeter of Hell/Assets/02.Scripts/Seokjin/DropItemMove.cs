using System.Collections;
using UnityEngine;

public class DropItemMove : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(rb == null)
        {
            Debug.Log("onEnavle");
            
        }
    }

    private void OnEnable()
    {
        rb.gravityScale = 1f;

        // 무작위 방향으로 힘 추가
        AddRandomForce();

        StartCoroutine(Aa());
    }

    private void AddRandomForce()
    {
        float randomX = Random.Range(-1f, 1f); // 좌우 무작위 값
        float randomY = Random.Range(2f, 4f); // 위쪽으로 튀어오르는 값

        Vector2 randomForce = new Vector2(randomX, randomY);
        rb.linearVelocity = randomForce; // 속도 설정
    }

    private IEnumerator Aa()
    {
        yield return new WaitForSeconds(0.5f);
        rb.gravityScale = 0f; // 중력 멈춤
        rb.linearVelocity = Vector2.zero; // 속도 정지 (원하는 경우)
    }
}
