using SetSailBoi.Scripts.Installers;
using SetSailBoi.Scripts.Shared.ScriptableObjectsDefinitions;
using SetSailBoi.Scripts.Shared.Structs;
using SetSailBoi.Scripts.UI.Shared;
using System.Collections;
using UnityEngine;


namespace SetSailBoi.Scripts.UI
{
    public class DialogRunner : MonoBehaviour
    {
        public static DialogRunner instance;

        [SerializeField]
        private GameObject _oldMan;

        [SerializeField]
        private GameObject _youngBoy;

        [SerializeField]
        private DialogScriptable _dialogData;

        private void Awake()
        {
            if (instance != null)
                return;

            Debug.Log("instancing");
            instance = this;
            new DialogInstaller().LoadDialogs(
                oldMan: _oldMan,
                youngBoy: _youngBoy,
                dialogData: _dialogData);
        }

        private void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                RunDialog(0);
            }
        }

        public void RunDialog(int chapterIndex)
        {
            StartCoroutine(RunDialogCorutine(chapterIndex));
        }

        public IEnumerator RunDialogCorutine(int chapterIndex)
        {
            StartCoroutine(ShowDialog(_dialogData.ChaptersCollection[chapterIndex][0]));
            UpdateDialogText(_dialogData.ChaptersCollection[chapterIndex][0]);
            yield return new WaitForSeconds(_dialogData.ChaptersCollection[chapterIndex][0].duration);

            for(var i = 0; i < _dialogData.ChaptersCollection[chapterIndex].Count; i++)
            {
                if (CharactersChanged(chapterIndex, i))
                {
                    StartCoroutine(ShowDialog(_dialogData.ChaptersCollection[chapterIndex][i]));
                    yield return new WaitForSeconds(_dialogData.ChaptersCollection[chapterIndex][i].duration);
                }

                UpdateDialogText(_dialogData.ChaptersCollection[chapterIndex][i]);
                yield return new WaitForSeconds(_dialogData.ChaptersCollection[chapterIndex][i].delay);

                if (i < _dialogData.ChaptersCollection[chapterIndex].Count - 1 &&
                    _dialogData.ChaptersCollection[chapterIndex][i].canvasGroup.gameObject !=
                    _dialogData.ChaptersCollection[chapterIndex][i + 1].canvasGroup.gameObject)
                {
                    StartCoroutine(HideDialog(_dialogData.ChaptersCollection[chapterIndex][i], chapterIndex));
                    yield return new WaitForSeconds(_dialogData.ChaptersCollection[chapterIndex][i].duration);
                }
                else if(i != _dialogData.ChaptersCollection[chapterIndex].Count - 1)
                {
                    yield return new WaitForSeconds(_dialogData.ChaptersCollection[chapterIndex][i].delay);
                }
                else
                {
                    StartCoroutine(HideDialog(_dialogData.ChaptersCollection[chapterIndex][i], chapterIndex));
                    yield return new WaitForSeconds(_dialogData.ChaptersCollection[chapterIndex][i].duration);
                }
            }
        }

        bool CharactersChanged(int chapterIndex, int i)
        {
            var dialog = _dialogData.ChaptersCollection[chapterIndex];
            return i > 0 && dialog[i].canvasGroup.gameObject != dialog[i - 1].canvasGroup.gameObject;
        }

        private void UpdateDialogText(DialogParams currentDialog)
        {
            currentDialog.setDialogText.Text = currentDialog.text;
        }

        private IEnumerator ShowDialog(DialogParams currentDialog)
        {
            Fader.instance.FadeIn(currentDialog.canvasGroup);
            yield return null;
        }

        private IEnumerator HideDialog(DialogParams currentDialog, int chapterIndex)
        {
            Fader.instance.FadeOut(currentDialog.canvasGroup);
            yield return null;
        }
    }
}
