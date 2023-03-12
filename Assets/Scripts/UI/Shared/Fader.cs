using UnityEngine;
using System.Collections;
using NarrativeDialogs.Scripts.Shared;
using NarrativeDialogs.Scripts.Shared.Structs;


namespace NarrativeDialogs.Scripts.UI.Shared
{
    public class Fader : MonoBehaviour
    {
        public IEnumerator FadeOut(CanvasGroup canvasGroup, DialogElement dialogElement)
        {
            IEnumerator changeAlphaCorrutine = ChangeAlpha(canvasGroup, dialogElement, startAlpha: 1, endAlpha: 0);
            yield return StartCoroutine(changeAlphaCorrutine);
        }

        public IEnumerator FadeIn(CanvasGroup canvasGroup, DialogElement dialogElement)
        {
            IEnumerator changeAlphaCorrutine = ChangeAlpha(canvasGroup, dialogElement, startAlpha: 0, endAlpha: 1);
            yield return StartCoroutine(changeAlphaCorrutine);
        }

        private IEnumerator ChangeAlpha(CanvasGroup canvasGroup, DialogElement dialogElement, float startAlpha, float endAlpha)
        {
            float elapsed = 0f;
            while (elapsed < dialogElement.FadeDuration)
            {
                elapsed += Time.deltaTime;
                float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / dialogElement.FadeDuration);
                canvasGroup.alpha = currentAlpha;
                yield return null;
            }
        }
    }
}
