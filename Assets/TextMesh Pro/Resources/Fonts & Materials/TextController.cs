using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextController : MonoBehaviour

{
    public GameObject courseClearUi;

    public TextMeshProUGUI textComponent;
    public float delayTime = 2f; // ��������� ���� �ð�

    private float timer = 0f;
    private bool isTextShown = false;

    // Start is called before the first frame update
    void Start()
    {
        
        // �ʱ⿡�� Text ��Ȱ��ȭ ���·� �����մϴ�.
        textComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Ÿ�̸Ӹ� ������Ʈ�մϴ�.
        timer += Time.deltaTime;

        // ������ �ð��� Text�� �����ŵ�ϴ�.
        if (!isTextShown && timer >= delayTime)
        {
            textComponent.enabled = true;
            isTextShown = true;
        }
    }
}

