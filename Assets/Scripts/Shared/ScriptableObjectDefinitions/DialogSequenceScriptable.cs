using SetSailBoi.Scripts.Shared.Structs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace SetSailBoi.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "DialogSequenceData", menuName = "ScriptableObjects/DialogSequenceScriptable", order = 0)]
    public class DialogSequenceScriptable : ScriptableObject
    {
        [SerializeField] private DialogSequenceID _id;
        [SerializeField] private DialogElement[] _dialogElements;

        public DialogSequenceID Id => _id;

        public List<DialogElement> DialogElements => _dialogElements.ToList();

        public bool CharactersChanged(int indexOfDialogElement)
        {
            return indexOfDialogElement == 0 || _dialogElements[indexOfDialogElement - 1].Character != _dialogElements[indexOfDialogElement].Character;
        }

        public bool CharactersWillChange(int indexOfDialogElement)
        {
            return indexOfDialogElement == _dialogElements.Length - 1 ||
                _dialogElements[indexOfDialogElement].Character != _dialogElements[indexOfDialogElement + 1].Character;
        }
    }
}
