using TMPro;
using UnityEngine;


namespace NarrativeDialogs.Scripts.UI
{
    public class UIQueue : MonoBehaviour
    {
        [SerializeField] private GameObject _queueItemPrefab;
        private GameObject _newQueueItem;

        private const int MaxItemCount = 7;

        public void CreateNewQueueItem(string text)
        {
            if (gameObject.transform.childCount >= MaxItemCount) return;

            _newQueueItem = Instantiate(_queueItemPrefab, gameObject.transform);
            _newQueueItem.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
    }
}
