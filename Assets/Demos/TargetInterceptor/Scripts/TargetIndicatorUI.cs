using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicatorUI : MonoBehaviour
{
    public GameObject targetIndicatorGameObject;

	public void SetTargetIndicatorPosition(Vector3 position)
    {
        targetIndicatorGameObject.transform.position = Camera.main.WorldToScreenPoint(position);
    }
}
