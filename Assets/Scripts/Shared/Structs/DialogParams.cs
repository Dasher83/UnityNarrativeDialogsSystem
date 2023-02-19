using SetSailBoi.Scripts.UI;
using UnityEngine;

namespace SetSailBoi.Scripts.Shared.Structs
{
    public struct DialogParams
    {
        public float delay;
        public float duration;
        public SetDialogText setDialogText;
        public CanvasGroup canvasGroup;
        public string text;

        public DialogParams(float delay, float duration, GameObject character, string text)
        {
            this.delay = delay;
            this.duration = duration;
            this.setDialogText = character.GetComponent<SetDialogText>();
            this.canvasGroup = character.GetComponent<CanvasGroup>();
            this.text = text;
        }
    }
}
