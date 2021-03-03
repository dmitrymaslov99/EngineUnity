using DG.Tweening;
using UnityEngine;

namespace Dimploma.Animations
{
    public interface IAnimation
    {
        int ID { get; }
        Transform Target { get; }

        Tween Animate();

        void Initialize();
        void ToStart();
        void ToFinish();
    }
}