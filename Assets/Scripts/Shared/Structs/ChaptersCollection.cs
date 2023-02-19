using System;


namespace SetSailBoi.Scripts.Shared.Structs
{
    [Serializable]
    public class ChaptersCollection
    {
        public Chapters chapters;

        public ChaptersCollection()
        {
            chapters = new Chapters();
        }
    }
}
