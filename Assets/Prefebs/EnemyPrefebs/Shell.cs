using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    bool istrig;
    Vector3 direction; // 이동 방향을 저장하기 위한 변수

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (istrig)
        {

            transform.position += direction * 10f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("BodyColliderEnemyCheck"))
        {
            direction = transform.position - other.transform.position; // 콜라이더에 진입하면 이동 방향을 설정
            istrig = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
