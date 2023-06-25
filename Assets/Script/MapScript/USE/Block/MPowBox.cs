using UnityEngine;

public class MPowBox : MonoBehaviour
{
    #region 변수 선언
    private SphereCollider Scollider;
    private bool trig;
    public int limitRadius = 3;
    public int speed = 10;
    #endregion

    #region 시작과 업데이트
    private void Start()
    {
        Scollider = gameObject.GetComponent<SphereCollider>();
        Scollider.radius = 1;
        Scollider.enabled = false;
    }

    private void Update()
    {
        if (trig)
        {
            Scollider.enabled = true;
            Scollider.radius += speed * Time.deltaTime;
        }

        if (Scollider.radius > limitRadius)
        {
            trig = false;
            Scollider.enabled = false;
        }
    }
    #endregion

    #region 충돌 감지
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Head") || other.gameObject.name.Contains("Pow"))
        {
            trig = true;
        }
        else if (other.gameObject.name.Contains("Foot") && MPlayer.instance.isDropDown == true)
        {
            trig = true;
        }


    }
    #endregion
}
