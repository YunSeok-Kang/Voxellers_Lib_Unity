using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetUI : MonoBehaviour
{
    public GameObject targetCorsshair;
    public GameObject targetNameTag;

    public void SetPositionCrosshair(Vector3 position)
    {
        targetCorsshair.transform.position = Camera.main.WorldToScreenPoint(position);
    }

    public void SetPositionNameTag(Vector3 position)
    {
        targetNameTag.transform.position = Camera.main.WorldToScreenPoint(position);
    }
}
