using Units.Tools;
using UnityEngine;

namespace Units.ExpandClass
{
    public static class ExpandClass
    {
        /// <summary>
        /// 看着目标方向以Y轴为中心
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="timer">平滑时间(如果是单击某个按键触发那么值最好设置100以上。)</param>
        public static void Look(this Transform transform, Vector3 target,float timer)
        {
            var direction = (target - transform.position);
            if(Vector3.Distance(direction ,Vector3.zero) <= 0.01f) return;
            direction = direction.normalized;
            direction.y = 0f;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,DevelopmentTools.UnTetheredLerp(timer));
        }
        
        /// <summary>
        /// 检查当前动画片段是否是指定Tag
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="tagName"></param>
        /// <param name="indexLayer"></param>
        /// <returns></returns>
        
        public static bool AnimationAtTag(this Animator animator, string tagName,int indexLayer = 0)
        {
            return animator.GetCurrentAnimatorStateInfo(indexLayer).IsTag(tagName);
        }
    }
}