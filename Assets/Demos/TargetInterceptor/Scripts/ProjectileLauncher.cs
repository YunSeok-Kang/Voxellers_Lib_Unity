/* 이러면 안되는 거 알지만, 편의상 이 클래스에 웬만한 변수 다 때려넣었습니다.
 * 양해 부탁드립니다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject target;
    public GameObject projectile;

    public ObjecsNameTarggerUI nameTagger;
    public TargetIndicatorUI targetIndicator;

    public float projectileSpeed = 3f;

    private Vector3 _targetPositionLastFrame;
    private Vector3 _projectilePositionLastFrame;

    private bool _isLaunched = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 projectilePosition = projectile.transform.position;

        nameTagger.SetTargetTagPosition(targetPosition);
        nameTagger.SetProjectileTagPosition(projectilePosition);

        Vector3 targetVelocity = targetPosition - _targetPositionLastFrame;
        targetVelocity /= Time.deltaTime;

        Vector3 projectileVelocity = projectile.transform.forward * projectileSpeed;

        /// 여기가 핵심
        Vector3 hitPosition;
        bool canHit = Voxellers.VoxPhysics.PredictHitPoint(out hitPosition, projectilePosition, projectileVelocity, targetPosition, targetVelocity);
        if (canHit & !_isLaunched)
        {
            targetIndicator.SetTargetIndicatorPosition(hitPosition); // TargetIndicator UI도 설정함.
            RotateProjectileTowardTarget(hitPosition);
        }

        _targetPositionLastFrame = targetPosition;
        _projectilePositionLastFrame = projectilePosition;
    }

    private void RotateProjectileTowardTarget(Vector3 targetPosition)
    {

        projectile.transform.rotation = Quaternion.LookRotation(targetPosition - projectile.transform.position);
    }

    public void LaunchProjectile()
    {
        _isLaunched = true;

        projectile.GetComponent<Projectile>().Launch(projectileSpeed);
    }
}
