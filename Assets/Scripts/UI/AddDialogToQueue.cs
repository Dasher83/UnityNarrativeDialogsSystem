using NarrativeDialogs.Scripts.Shared.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace NarrativeDialogs.Scripts.UI
{
    public class AddDialogToQueue : MonoBehaviour
    {
        [SerializeField] private UIQueue _uiQueue;
        [SerializeField] private DialogSequenceID _dialogSequenceID;
        private Button _button;
        private TextMeshProUGUI _textField;
        private string _shortText;


        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Add);
            _textField = GetComponentInChildren<TextMeshProUGUI>();
            _shortText = $"{_textField.text.ToUpper()[0]}{_textField.text.ToUpper()[_textField.text.Length - 1]}";
        }

        public void Add()
        {
            _uiQueue.CreateNewQueueItem(_shortText, _dialogSequenceID);
        }
    }
}
