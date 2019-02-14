using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecsNameTarggerUI : MonoBehaviour
{
    public GameObject targetTag;
    public GameObject projectileTag;

    public void SetTargetTagPosition(Vector3 position)
    {
        targetTag.transform.position = Camera.main.WorldToScreenPoint(position);
    }

    public void SetProjectileTagPosition(Vector3 position)
    {
        projectileTag.transform.position = Camera.main.WorldToScreenPoint(position);
    }
}
