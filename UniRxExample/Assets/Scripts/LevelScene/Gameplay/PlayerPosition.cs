using UniRx;
using UnityEngine;

namespace UniRxExample.LevelScene.Gameplay
{
    public interface IMover
    {
        ReactiveProperty<Vector3> Position { get; }
    }

    public class PlayerPosition : IMover, IMovable
    {
        public ReactiveProperty<Vector3> Position { get; private set; } = new(Vector3.zero);
        public void Move(Vector3 position) => Position.Value = position;
    }
}