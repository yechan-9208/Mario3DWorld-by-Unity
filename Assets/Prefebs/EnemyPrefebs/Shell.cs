using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    bool istrig;
    Vector3 direction; // �̵� ������ �����ϱ� ���� ����

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
            direction = transform.position - other.transform.position; // �ݶ��̴��� �����ϸ� �̵� ������ ����
            istrig = true;
        }
    }

}
