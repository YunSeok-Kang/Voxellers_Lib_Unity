using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCubeOnPosition : MonoBehaviour
{
    [SerializeField] private Vector3 cubePosition;
    [SerializeField] private Vector3 cubeingRotation;
    [SerializeField] private Vector3 cubeingScale;

    private void OnDrawGizmos()
    {
        Voxellers.VoxDebug.DrawCube(cubePosition, Quaternion.Euler(cubeingRotation), cubeingScale);
    }
}
