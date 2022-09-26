using UnityEngine;
using UniRx;
using Zenject;

namespace UniRxExample.LevelScene.Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Transform _playerTransform;
        [SerializeField] Rigidbody _playerRigidbody;

        [SerializeField] float _speed = 5f;

        [Inject] PositionViewModel ViewModel { get; set; }

        enum ScreenTriangle
        {
            Top,
            Bottom,
            Left,
            Right,
        }

        void Awake()
        {
            MoveCamera();
            HandleKeyboard();
            HandleMouse();
        }

        void MoveCamera() 
        {
            _playerTransform.ObserveEveryValueChanged(transform => transform.position).Subscribe(position =>
            {
                ViewModel.Move.Execute(position);
            });
        }

        void HandleKeyboard()
        {
            Observable.EveryUpdate().Where(_ => Input.GetKey(KeyCode.UpArrow)).Subscribe(_ => AccelerateForward()).AddTo(this);
            Observable.EveryUpdate().Where(_ => Input.GetKey(KeyCode.DownArrow)).Subscribe(_ => AccelerateBack()).AddTo(this);
            Observable.EveryUpdate().Where(_ => Input.GetKey(KeyCode.LeftArrow)).Subscribe(_ => AccelerateLeft()).AddTo(this);
            Observable.EveryUpdate().Where(_ => Input.GetKey(KeyCode.RightArrow)).Subscribe(_ => AccelerateRight()).AddTo(this);
        }

        void HandleMouse()
        {
            Observable.EveryUpdate().Where(_ => Input.GetMouseButton(0) && 
                                                Input.mousePosition.x >= 0 && 
                                                Input.mousePosition.y >= 0 && 
                                                Input.mousePosition.x <= Screen.width && 
                                                Input.mousePosition.y <= Screen.height)
                                    .Subscribe(_ => 
                                    {
                                        var mousePosition = Input.mousePosition;
                                        var triangle = GetScreenTriangle(mousePosition);
                                        switch (triangle)
                                        {
                                            case ScreenTriangle.Top:
                                                AccelerateForward();
                                                break;
                                            case ScreenTriangle.Bottom:
                                                AccelerateBack();
                                                break;
                                            case ScreenTriangle.Left:
                                                AccelerateLeft();
                                                break;
                                            case ScreenTriangle.Right:
                                                AccelerateRight();
                                                break;
                                        }  
                                    }).AddTo(this);
        }

        ScreenTriangle GetScreenTriangle(Vector2 mousePosition)
        {
            var screenWidth = Screen.width;
            var screenHeight = Screen.height;

            var halfScreenWidth = screenWidth / 2;
            var halfScreenHeight = screenHeight / 2;

            Vector2 topSideCenter = new(halfScreenWidth, screenHeight);
            Vector2 bottomSideCenter = new(halfScreenWidth, 0);
            Vector2 leftSideCenter = new(0, halfScreenHeight);
            Vector2 rightSideCenter = new(screenWidth, halfScreenHeight);

            var isMouseInRightPartOfTheScreen = mousePosition.x >= halfScreenWidth;
            var isMouseInTopPartOfTheScreen = mousePosition.y >= halfScreenHeight;

            if (isMouseInRightPartOfTheScreen && isMouseInTopPartOfTheScreen)
                return CompareSquareMagnitudes(mousePosition, topSideCenter, ScreenTriangle.Top, rightSideCenter, ScreenTriangle.Right);

            if (isMouseInRightPartOfTheScreen && !isMouseInTopPartOfTheScreen)
                return CompareSquareMagnitudes(mousePosition, bottomSideCenter, ScreenTriangle.Bottom, rightSideCenter, ScreenTriangle.Right);

            if (!isMouseInRightPartOfTheScreen && isMouseInTopPartOfTheScreen)
                return CompareSquareMagnitudes(mousePosition, topSideCenter, ScreenTriangle.Top, leftSideCenter, ScreenTriangle.Left);

            if (!isMouseInRightPartOfTheScreen && !isMouseInTopPartOfTheScreen)
                return CompareSquareMagnitudes(mousePosition, bottomSideCenter, ScreenTriangle.Bottom, leftSideCenter, ScreenTriangle.Left);

            return ScreenTriangle.Bottom;
        }

        ScreenTriangle CompareSquareMagnitudes(Vector2 mousePosition, Vector2 a, ScreenTriangle resultA, Vector2 b, ScreenTriangle resultB)
        {
            var sqrA = (a - mousePosition).sqrMagnitude;
            var sqrB = (b - mousePosition).sqrMagnitude;
            return sqrA <= sqrB ? resultA : resultB;
        }

        void AccelerateForward() => _playerRigidbody.AddForce(_speed * Vector3.forward);
        void AccelerateBack() => _playerRigidbody.AddForce(_speed * Vector3.back);
        void AccelerateLeft() => _playerRigidbody.AddForce(_speed * Vector3.left);
        void AccelerateRight() => _playerRigidbody.AddForce(_speed * Vector3.right);
    }
}
