using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxExample
{
    public static class UniRxExtensions
    {
        public static IDisposable SubscribeToImageFillAmount(this IObservable<float> source, Image progressMask) 
        {
            return source.SubscribeWithState(progressMask, (progress, progressMask) => progressMask.fillAmount = progress);
        }

        public static IDisposable SubscribeToGameObjectSetActive(this IObservable<bool> source, GameObject gameObject) 
        {
            return source.SubscribeWithState(gameObject, (active, gameObject) => gameObject.SetActive(active));
        }
    }
}