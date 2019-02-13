using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracker : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    [Tooltip("해당 값이 흐른 후의 위치를 예상합니다. 값을 조절하여 예측 시간대를 수정할 수 있습니다.")]
    [SerializeField]
    private float _predictionTime = 2f; // default = 2: 2초 후 위치 예상

    [SerializeField]
    private TargetUI _targetUI;

    private Vector3 _lastFrameTargetPosition;
    private Vector3 _predictedPosition;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 currentTargetPosition = _target.transform.position;
        Debug.Log("LastTargetPosition: " + _lastFrameTargetPosition);
        Debug.Log("CurrentTargetPosition: " + currentTargetPosition);

        Vector3 predictedPosition = Voxellers.VoxPhysics.PredictPosition(_lastFrameTargetPosition, currentTargetPosition, _predictionTime);

        _predictedPosition = predictedPosition;

        _targetUI.SetPositionCrosshair(predictedPosition);
        _targetUI.SetPositionNameTag(_target.transform.position);

        _lastFrameTargetPosition = currentTargetPosition;
    }

    private void OnDrawGizmos()
    {
        Voxellers.VoxDebug.DrawCube(_predictedPosition, Quaternion.identity, Vector3.one);
    }
}
