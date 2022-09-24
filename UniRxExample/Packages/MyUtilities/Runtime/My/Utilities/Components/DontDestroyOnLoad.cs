using System;
using UnityEngine;

namespace My.Utilities.Components
{
    [DisallowMultipleComponent]
    public sealed class DontDestroyOnLoad : MonoBehaviour
    {
        void Awake()
        {
            ValidateRoot(ifIsNotRoot: Destroy, ifIsRoot: () =>
            {
                DontDestroyOnLoad(gameObject);
            });
        }

#if UNITY_EDITOR
        void Reset() => ValidateRoot(ifIsNotRoot: DestroyImmediate);
#endif

        void ValidateRoot(Action<UnityEngine.Object> ifIsNotRoot, Action ifIsRoot = null)
        {
            if (transform.parent == null)
            {
                ifIsRoot?.Invoke();
                return;
            }

            Debug.LogError("DontDestroyOnLoad only works for root GameObjects");
            ifIsNotRoot?.Invoke(this);
        }
    }
}