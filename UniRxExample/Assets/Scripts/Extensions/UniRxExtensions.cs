using System;
using UniRx;
using UnityEngine.UI;

namespace UniRxExample
{
    public static class UniRxExtensions
    {
        public static IDisposable SubscribeToImageFillAmount(this IObservable<float> source, Image progressMask) 
        {
            return source.SubscribeWithState(progressMask, (progress, progressMask) =>
            { 
                progressMask.fillAmount = progress;
            });
        }
    }
}