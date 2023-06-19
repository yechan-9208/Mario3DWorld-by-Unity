using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{

	float currTime = 0;
	bool trig= true;

	
	void Start()
	{
		RectTransform rt = GetComponent<RectTransform>();
		rt.anchoredPosition = new Vector3(-Screen.width, 0, 0);
		//transform.position = new Vector3(-Screen.width, 0, 0);
		//iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
		//iTween.MoveTo(gameObject, iTween.Hash("x", 600, "easeType", "easeInOutQuint", "delay", .1));

		MoveUI(0.1f);
	}

	private void Update()
	{
		return;
	}

	void OnCompleteTest()
    {
		MoveUI(1);
		trig = false;
    }


	void MoveUI(float delayTime)
    {
		if (trig == false) return;

		iTween.MoveBy(gameObject, iTween.Hash(
				"x", Screen.width,
				"easeType", iTween.EaseType.easeOutBack,
				"delay", delayTime,
				"oncompletetarget", gameObject,
				"oncomplete", nameof(OnCompleteTest)));
	}
}

