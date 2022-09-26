using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace UniRxExample.LevelScene.Gameplay
{
    public class PositionViewModel
    {
        public ReactiveCommand<Vector3> Move { get; private set; }

        [Inject]
        public PositionViewModel(IMovable model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Move = new ReactiveCommand<Vector3>();
            Move.Subscribe(position => 
            {
                model.Move(position);
            });
        }
    }
}
