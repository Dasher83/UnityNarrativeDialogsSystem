using System.Threading;
using SetSailBoi.Scripts.Shared;
using System.Threading.Tasks;
using UnityEngine;


namespace SetSailBoi.Scripts.UI.Shared
{
    public class Fader : MonoBehaviour
    {
        public static Fader instance;
        
        CancellationTokenSource cancellationSource = new();

        private void Awake()
        {
            if (instance != null)
            {
                return;
            }
            else
            {
                instance = this;
            }
        }

        void OnDestroy()
        {
            cancellationSource.Cancel();
        }

        public async Task FadeOut(CanvasGroup canvasGroup)
        {
            await ChangeAlpha(canvasGroup, startAlpha: 1, endAlpha: 0);
        }

        public async Task FadeIn(CanvasGroup canvasGroup)
        {
            await ChangeAlpha(canvasGroup, startAlpha: 0, endAlpha: 1);
        }

        private async Task ChangeAlpha(CanvasGroup canvasGroup, float startAlpha, float endAlpha)
        {
            var cancellation = cancellationSource.Token;
            await Task.Delay((int)Constants.Fader.DialogueDuration * 1000, cancellation);
            float elapsed = 0f;
            while (elapsed < Constants.Fader.FadeDuration)
            {
                elapsed += Time.deltaTime;
                float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / Constants.Fader.FadeDuration);
                canvasGroup.alpha = currentAlpha;
                await Task.Yield();
            }
        }
    }
}
