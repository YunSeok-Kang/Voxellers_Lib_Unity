using UnityEngine;

namespace Voxellers
{
    public class VoxPhysics
    {
        /// <summary>
        /// 특정 시간이 흐른 후, 현재 위치로부터 어떻게 위치가 변화하였는지를 추정하는 함수.
        /// </summary>
        /// <param name="positionLastFrame"> 현재 프레임 이전 프레임에서의 위치 값 </param>
        /// <param name="positionCurrent"> 현재 프래임에서의 위치 값 </param>
        /// <param name="secondsFromNow"> 해당 시간이 지난 후의 위치 값을 추정 </param>
        /// <returns> 예상 추정 위치 </returns>
        public static Vector3 PredictPosition(Vector3 positionLastFrame, Vector3 positionCurrent, float secondsFromNow)
        {
            Vector3 velocity = positionCurrent - positionLastFrame;
            velocity /= Time.deltaTime;
            Debug.Log("Velocity: " + velocity);

            return PredictPositionWithVelocity(positionCurrent, velocity, secondsFromNow);
        }

        /// <summary>
        /// 특정 시간이 흐른 후, 현재 위치로부터 어떻게 위치가 변화하였는지를 추정하는 함수. 위치 값이 아니라 속도 값을 이용하여 계산함.
        /// </summary>
        /// <param name="positionCurrent"> 현재 위치. </param>
        /// <param name="velocity"> 현재 위치에서 작용하는 속도 </param>
        /// <param name="secondsFromNow"> 해당 시간이 지난 후의 위치 값을 추정. </param>
        /// <returns> 예상 추정 위치 </returns>
        public static Vector3 PredictPositionWithVelocity(Vector3 positionCurrent, Vector3 velocity, float secondsFromNow)
        {
            Vector3 newPosition = positionCurrent + velocity * secondsFromNow;

            return newPosition;
        }
    }
}

