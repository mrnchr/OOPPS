using System;
using UnityEngine;

namespace OOPPS
{
    public class CloudTransitionsController : MonoBehaviour
    {

        public event Action OnCloudShowEnded;
        public event Action OnCloudHideEnded;

        [SerializeField] private Animator _animator;

        public void ShowClouds()
        {
            _animator.ResetTrigger("needHideClouds");
            _animator.SetTrigger("needShowClouds");
        }

        public void HideClouds()
        {
            _animator.ResetTrigger("needShowClouds");
            _animator.SetTrigger("needHideClouds");
        }

        public void EndCloudShow()
        {
            OnCloudShowEnded?.Invoke();
        }

        public void EndCloudHide()
        {
            OnCloudHideEnded?.Invoke();
        }

        public float GetAnimationDuration()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).length;
        }

    }
}