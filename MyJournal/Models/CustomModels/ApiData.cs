using System.Collections.Generic;

namespace MyJournal.Models.CustomModels
{
    public class ApiData
    {
        public int ApiDataID { get; set; }
        public int DailyInformationId { get; set; }
        public DailyInformation? DailyInformation { get; set; }
        public DocumentTone DocumentTones { get; set; } = new DocumentTone();
        public ICollection<SentenceTone> SentenceTones { get; set; } = [];

        public class Tone
        {
            public int ToneID { get; set; }
            public string ToneName { get; set; } = string.Empty;
            public double Score { get; set; }
            public int? DocumentToneID { get; set; }
            public DocumentTone DocumentTone { get; set; } = new DocumentTone();
            public int? SentenceToneID { get; set; }

        }

        public class DocumentTone
        {
            public int DocumentToneID { get; set; }
            public List<Tone> Tones { get; set; } = [];
        }

        public class SentenceTone
        {
            public int SentenceToneID { get; set; }
            public string Text { get; set; } = string.Empty;
            public virtual ICollection<Tone> Tones { get; set; } = [];
        }

    }
}
