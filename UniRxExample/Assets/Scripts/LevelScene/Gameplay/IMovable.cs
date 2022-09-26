using UniRx;
using UnityEngine;

namespace UniRxExample.LevelScene.Gameplay
{
    public interface IMovable
    {
        void Move(Vector3 position);
    }
}