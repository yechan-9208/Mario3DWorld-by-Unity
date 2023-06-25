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
            direction = transform.position - other.transform.position; // �ݶ��̴��� �����ϸ� �̵� ������ ����
            istrig = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
