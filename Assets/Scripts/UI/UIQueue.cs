using TMPro;
using UnityEngine;


namespace NarrativeDialogs.Scripts.UI
{
    public class UIQueue : MonoBehaviour
    {
        [SerializeField] private GameObject _queueItemPrefab;
        private GameObject _newQueueItem;

        public void CreateNewQueueItem(string text)
        {
            _newQueueItem = Instantiate(_queueItemPrefab, gameObject.transform);
            _newQueueItem.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
    }
}
