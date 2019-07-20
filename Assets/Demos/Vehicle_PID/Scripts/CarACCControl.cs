using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Voxellers;
using UnityStandardAssets.Vehicles.Car;

public class CarACCControl : MonoBehaviour
{
    [SerializeField]
    private CarController _carController;

    [SerializeField]
    private PIDController _pidController;

    [SerializeField]
    private float _targetSpeed = 40f;

    public float TargetSpeed
    {
        set
        {
            _targetSpeed = value;
        }

        get
        {
            return _targetSpeed;
        }
    }
    public float CurrentSpeed
    {
        private set;
        get;
    }

    public bool turnOnPID = true;

	// Use this for initialization
	void Start ()
    {
		
	}

    private void FixedUpdate()
    {
        UpdateCurrentSpeed();

        float accelPower = 0f;

        if (turnOnPID) // PID 제어 On
        {
            _pidController.Record(TargetSpeed - CurrentSpeed, Time.fixedDeltaTime);

            accelPower = _pidController.GetOutput();
        }
        else // PID 제어 Off
        {
            if (_targetSpeed >= CurrentSpeed)
            {
                accelPower = 1f;
            }
        }

        _carController.Move(0, accelPower, 0, 0);
    }

    private void UpdateCurrentSpeed()
    {
        CurrentSpeed = _carController.CurrentSpeed;
    }
}
