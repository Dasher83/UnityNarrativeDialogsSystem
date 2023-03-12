using NarrativeDialogs.Scripts.Shared.Enums;
using NarrativeDialogs.Scripts.Shared.Utils;
using TMPro;
using UnityEngine;


namespace NarrativeDialogs.Scripts.UI
{
    public class UIQueue : MonoBehaviour
    {
        [SerializeField] private GameObject _queueItemPrefab;
        [SerializeField] private CoroutineQueue _coroutineQueue;
        [SerializeField] private DialogRunner _dialogRunner;
        private GameObject _newQueueItem;

        private const int MaxItemCount = 7;

        private void Start()
        {
            _coroutineQueue.CoroutineEnded += DeleteFirstItemInQueue;
        }

        public void CreateNewQueueItem(string text, DialogSequenceID dialogSequenceID)
        {
            if (gameObject.transform.childCount >= MaxItemCount) return;

            _newQueueItem = Instantiate(_queueItemPrefab, gameObject.transform);
            _newQueueItem.GetComponentInChildren<TextMeshProUGUI>().text = text;
            _dialogRunner.EnqueueDialog(dialogSequenceID);
        }

        private void DeleteFirstItemInQueue()
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }
    }
}
