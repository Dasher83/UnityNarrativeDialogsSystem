using UnityEngine;
using System.Collections;
using NarrativeDialogs.Scripts.Shared;


namespace NarrativeDialogs.Scripts.UI.Shared
{
    public class Fader : MonoBehaviour
    {
        public IEnumerator FadeOut(CanvasGroup canvasGroup)
        {
            IEnumerator changeAlphaCorrutine = ChangeAlpha(canvasGroup, startAlpha: 1, endAlpha: 0);
            yield return StartCoroutine(changeAlphaCorrutine);
        }

        public IEnumerator FadeIn(CanvasGroup canvasGroup)
        {
            IEnumerator changeAlphaCorrutine = ChangeAlpha(canvasGroup, startAlpha: 0, endAlpha: 1);
            yield return StartCoroutine(changeAlphaCorrutine);
        }

        private IEnumerator ChangeAlpha(CanvasGroup canvasGroup, float startAlpha, float endAlpha)
        {
            float elapsed = 0f;
            while (elapsed < Constants.Fader.FadeDuration)
            {
                elapsed += Time.deltaTime;
                float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / Constants.Fader.FadeDuration);
                canvasGroup.alpha = currentAlpha;
                yield return null;
            }
        }
    }
}
