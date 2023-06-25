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

    float currentTime = 0;
    float TargetTime = 4f;
    void Update()
    {
        if (istrig)
        {
            transform.position += direction * 10f * Time.deltaTime;
        }

        currentTime += Time.deltaTime;
        if(currentTime>TargetTime)
        {
            Destroy(gameObject);
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

}
