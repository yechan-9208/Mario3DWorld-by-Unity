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
			MoveUI();
			trig = true;
		}
	}

	void changeUI()
    {
		GameManager.instance.gameStartUI.SetActive(false);
		GameManager.instance.gamingUI.SetActive(true);
	}

	void MoveUI()
	{

		iTween.MoveBy(gameObject, iTween.Hash(
				"x", Screen.width,
				"easeType", iTween.EaseType.easeInOutSine,
				"delay", 0.1f,
				"oncompletetarget", gameObject,
				"oncomplete", nameof(changeUI)));
	}


}

