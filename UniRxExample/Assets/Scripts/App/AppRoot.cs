using System.Threading.Tasks;
using UniRxExample.IntroLoading;
using UnityEngine;
using Zenject;

namespace UniRxExample
{
    public class AppRoot : MonoBehaviour
    {
        [Inject] IIntroLoader IntroLoader {get; set; }

        async Task Start()
        {
            await IntroLoader.Load();
        }
    }
}