using System.Collections.Generic;
using UnityEngine;


namespace SetSailBoi.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "DialogLibraryData", menuName = "ScriptableObjects/DialogLibraryData", order = 1)]
    public class DialogLibraryScriptable : ScriptableObject
    {
        [SerializeField] private List<DialogSequenceScriptable> _dialogSequences;

        public DialogSequenceScriptable Find(DialogSequenceID dialogSequenceID)
        {
            foreach(DialogSequenceScriptable dialogSequence in _dialogSequences)
            {
                if(dialogSequence.Id == dialogSequenceID)
                {
                    return dialogSequence;
                }
            }

            return null;
        }
    }
}
