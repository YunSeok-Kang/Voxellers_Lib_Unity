using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarInfoUI : MonoBehaviour
{
    public CarACCControl carACCControl = null;

    public Text currentSpeedText;
    public Text targetSpeedText;
	
	// Update is called once per frame
	void Update ()
    {
        currentSpeedText.text = carACCControl.CurrentSpeed.ToString();
        targetSpeedText.text = carACCControl.TargetSpeed.ToString();
	}
}
