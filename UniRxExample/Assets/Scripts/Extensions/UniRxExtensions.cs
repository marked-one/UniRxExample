using System;
using System.Collections;
using System.Threading;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxExample
{
    public static class UniRxExtensions
    {
        public static IDisposable SubscribeToTransformPosition(this IObservable<Vector3> source, Transform transform) 
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (transform == null)
                throw new ArgumentNullException(nameof(transform));


            return source.SubscribeWithState(transform, (position, transform) => transform.position = position);
        }

        public static IDisposable SubscribeToImageFillAmount(this IObservable<float> source, Image progressMask) 
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (progressMask == null)
                throw new ArgumentNullException(nameof(progressMask));


            return source.SubscribeWithState(progressMask, (progress, progressMask) => progressMask.fillAmount = progress);
        }

        public static IDisposable SubscribeToGameObjectSetActive(this IObservable<bool> source, GameObject gameObject) 
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (gameObject == null)
                throw new ArgumentNullException(nameof(gameObject));

            return source.SubscribeWithState(gameObject, (active, gameObject) => gameObject.SetActive(active));
        }

        // From UniRx Readme
        public static IObservable<float> ToObservable(this UnityEngine.AsyncOperation asyncOperation)
        {
            if (asyncOperation == null)
                throw new ArgumentNullException(nameof(asyncOperation));

            return Observable.FromCoroutine<float>((observer, cancellationToken) => RunAsyncOperation(asyncOperation, observer, cancellationToken));
        }

        // From UniRx Readme
        static IEnumerator RunAsyncOperation(UnityEngine.AsyncOperation asyncOperation, IObserver<float> observer, CancellationToken cancellationToken)
        {
            while (!asyncOperation.isDone && !cancellationToken.IsCancellationRequested)
            {
                observer.OnNext(asyncOperation.progress);
                yield return null;
            }
            if (!cancellationToken.IsCancellationRequested)
            {
                observer.OnNext(asyncOperation.progress);
                observer.OnCompleted();
            }
        }
    }
}