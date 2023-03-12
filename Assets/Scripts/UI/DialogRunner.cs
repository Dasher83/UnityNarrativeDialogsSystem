using NarrativeDialogs.Scripts.Shared;
using NarrativeDialogs.Scripts.Shared.Enums;
using NarrativeDialogs.Scripts.Shared.ScriptableObjectDefinitions;
using NarrativeDialogs.Scripts.Shared.Structs;
using NarrativeDialogs.Scripts.Shared.Utils;
using NarrativeDialogs.Scripts.UI.Shared;
using System.Collections;
using TMPro;
using UnityEngine;


namespace NarrativeDialogs.Scripts.UI
{
    public class DialogRunner : MonoBehaviour
    {
        public static DialogRunner instance;

        [SerializeField] private CanvasGroup _oldManCanvasGroup;
        [SerializeField] private CanvasGroup _youngBoyCanvasGroup;
        [SerializeField] private TextMeshProUGUI _oldManText;
        [SerializeField] private TextMeshProUGUI _youngBoyText;
        [SerializeField] private DialogLibraryScriptable _dialogLibraryData;
        [SerializeField] private DialogSequenceID[] dialogsToPlay;
        [SerializeField] private Fader _fader;
        private CoroutineQueue _queue;

        private void Awake()
        {
            this._queue = GetComponent<CoroutineQueue>();
            instance = this;
        }

        public void EnqueueDialog(DialogSequenceID dialogSequenceID)
        {
            _queue.Enqueue(RunDialog(dialogSequenceID));
        }

        private IEnumerator RunDialog(DialogSequenceID dialogSequenceID)
        {
            DialogSequenceScriptable dialogSequence = _dialogLibraryData.Find(dialogSequenceID);

            for (int i = 0; i < dialogSequence.DialogElements.Count; i++)
            {
                UpdateText(dialogSequence.DialogElements[i]);

                if (dialogSequence.CharactersChanged(i))
                {
                    IEnumerator showDialogCoroutine = ShowDialog(dialogSequence.DialogElements[i]);
                    yield return StartCoroutine(showDialogCoroutine);
                }

                yield return new WaitForSeconds(dialogSequence.DialogElements[i].TimeToRead);

                if (dialogSequence.CharactersWillChange(i))
                {
                    IEnumerator hideDialogCorutine = HideDialog(dialogSequence.DialogElements[i]);
                    yield return StartCoroutine(hideDialogCorutine);
                }
            }
        }

        private void UpdateText(DialogElement dialogElement)
        {
            if (dialogElement.Character == Character.OldMan)
            {
                _oldManText.text = dialogElement.Text;
            }
            else
            {
                _youngBoyText.text = dialogElement.Text;
            }
        }

        private IEnumerator ShowDialog(DialogElement dialogElement)
        {
            IEnumerator fadeInCorrutine = _fader.FadeIn(dialogElement.Character == Character.OldMan ? _oldManCanvasGroup : _youngBoyCanvasGroup, dialogElement);
            yield return StartCoroutine(fadeInCorrutine);
        }

        private IEnumerator HideDialog(DialogElement dialogElement)
        {
            IEnumerator fadeOutCorrutine = _fader.FadeOut(dialogElement.Character == Character.OldMan ? _oldManCanvasGroup : _youngBoyCanvasGroup, dialogElement);
            yield return StartCoroutine(fadeOutCorrutine);
        }
    }
}
