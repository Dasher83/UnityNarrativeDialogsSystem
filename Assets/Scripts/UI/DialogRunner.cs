using SetSailBoi.Scripts.Shared;
using SetSailBoi.Scripts.Shared.Enums;
using SetSailBoi.Scripts.Shared.ScriptableObjectsDefinitions;
using SetSailBoi.Scripts.Shared.Structs;
using SetSailBoi.Scripts.UI.Shared;
using System.Collections;
using TMPro;
using UnityEngine;


namespace SetSailBoi.Scripts.UI
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
        private CoroutineQueue _queue;

        private bool _ran = false;

        private void Awake()
        {
            this._queue = GetComponent<CoroutineQueue>();
            instance = this;
        }

        private void Update()
        {
            if(Time.timeSinceLevelLoad < 3)
            {
                return;
            }
            if (!_ran)
            {
                foreach (DialogSequenceID dialogSequenceID in dialogsToPlay)
                {
                    _queue.Enqueue(RunDialog(dialogSequenceID));
                }
                _ran = true;
            }
        }

        public IEnumerator RunDialog(DialogSequenceID dialogSequenceID)
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

                yield return new WaitForSeconds(Constants.Fader.DialogueDuration);

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
            IEnumerator fadeInCorrutine = Fader.instance.FadeIn(dialogElement.Character == Character.OldMan ? _oldManCanvasGroup : _youngBoyCanvasGroup);
            yield return StartCoroutine(fadeInCorrutine);
        }

        private IEnumerator HideDialog(DialogElement dialogElement)
        {
            IEnumerator fadeOutCorrutine = Fader.instance.FadeOut(dialogElement.Character == Character.OldMan ? _oldManCanvasGroup : _youngBoyCanvasGroup);
            yield return StartCoroutine(fadeOutCorrutine);
        }
    }
}
