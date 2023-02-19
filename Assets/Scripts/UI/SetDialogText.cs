using TMPro;
using UnityEngine;


namespace SetSailBoi.Scripts.UI
{
    public class SetDialogText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public string Text {
            set
            {
                text.text = value;
            }
        }
    }
}
