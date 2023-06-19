using UnityEngine;
using System.Collections;

public class StartUI : MonoBehaviour
{

	float currTime = 0;
	bool trig;


	void Start()
	{

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1) && !(trig))
        {
			print("sd");
			
			MoveUI();
			trig = true;
		}
	}

	void MoveUI()
	{

		iTween.MoveBy(gameObject, iTween.Hash(
				"x", Screen.width,
				"easeType", iTween.EaseType.easeInOutSine,
				"delay", 0.1f,
				"oncompletetarget", gameObject));
	}
}

