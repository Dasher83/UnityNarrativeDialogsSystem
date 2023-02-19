using SetSailBoi.Scripts.Shared.Enums;


namespace SetSailBoi.Scripts.Shared.Structs
{
    [System.Serializable]
    public struct DialogJsonItem
    {
        public int character;
        public string text;

        public DialogJsonItem(Characters character, string text)
        {
            this.character = (int)character;
            this.text = text;
        }
    }
}
