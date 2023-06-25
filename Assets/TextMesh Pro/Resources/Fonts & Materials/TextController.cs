using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextController : MonoBehaviour

{
    public GameObject courseClearUi;

    public TextMeshProUGUI textComponent;
    public float delayTime = 2f; // 실행까지의 지연 시간

    private float timer = 0f;
    private bool isTextShown = false;

    // Start is called before the first frame update
    void Start()
    {
        
        // 초기에는 Text 비활성화 상태로 시작합니다.
        textComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 타이머를 업데이트합니다.
        timer += Time.deltaTime;

        // 정해진 시간에 Text를 실행시킵니다.
        if (!isTextShown && timer >= delayTime)
        {
            textComponent.enabled = true;
            isTextShown = true;
        }
    }
}

