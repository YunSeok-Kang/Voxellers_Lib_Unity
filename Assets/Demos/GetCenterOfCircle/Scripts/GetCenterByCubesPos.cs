using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCenterByCubesPos : MonoBehaviour
{
    public Transform[] posCubes;
    public Transform centerCube;

    public float pos1R;
    public float pos2R;
    public float pos3R;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 centerOfCircle;
        float radiusOfCircle;

        if (Voxellers.VoxMath.GetCenterOfCircleByThreePos(out centerOfCircle, out radiusOfCircle, posCubes[0].position, posCubes[1].position, posCubes[2].position) == true)
        {
            centerCube.transform.position = centerOfCircle;

            pos1R = Vector2.Distance(posCubes[0].position, centerOfCircle);
            pos2R = Vector2.Distance(posCubes[1].position, centerOfCircle);
            pos3R = Vector2.Distance(posCubes[2].position, centerOfCircle);
        }
    }
}
