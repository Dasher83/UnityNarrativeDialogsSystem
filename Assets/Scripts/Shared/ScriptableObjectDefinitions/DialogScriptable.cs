using SetSailBoi.Scripts.Shared.Structs;
using System.Collections.Generic;
using UnityEngine;


namespace SetSailBoi.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "DialogData", menuName = "ScriptableObjects/DialogData", order = 0)]
    public class DialogScriptable : ScriptableObject
    {
        [SerializeField]
        private List<List<DialogParams>> chaptersCollection;

        public List<List<DialogParams>> ChaptersCollection
        {
            get
            {
                return chaptersCollection;
            }
            
            set
            {
                chaptersCollection = value;
            }
        }
    }
}
