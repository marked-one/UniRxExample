using System;
using UniRx;
using UniRxExample.LevelScene.Gameplay;
using UnityEngine;
using Zenject;

namespace UniRxExample.MainScene.Gameplay
{
    public class MovableViewModel
    {
        public IReadOnlyReactiveProperty<Vector3> Position { get; set; }

        [Inject]
        public MovableViewModel(IMover model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Position = model.Position;
        }
    }
}
