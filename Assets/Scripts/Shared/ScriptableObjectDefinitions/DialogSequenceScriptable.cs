using SetSailBoi.Scripts.Shared.Structs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace SetSailBoi.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "DialogSequenceData", menuName = "ScriptableObjects/Dialogs/DialogSequenceData", order = 0)]
    public class DialogSequenceScriptable : ScriptableObject
    {
        [SerializeField] private DialogSequenceID _id;
        [SerializeField] private DialogElement[] _dialogElements;

        public List<DialogElement> DialogElements => _dialogElements.ToList();
    }
}
