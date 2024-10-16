﻿using CsvHelper.Configuration.Attributes;

namespace UploadStreamToQuestDB.Domain {
    public class CsvFile<T> {
        public List<T> records = new List<T>();
    }

    public class WeatherGermany {
        [Name("STATIONS_ID")]
        public int StationId { get; set; }
        [Name("MESS_DATUM")]
        public string MessDatum { get; set; }
        [Name("QN")]
        public double QN { get; set; }
        [Name("PP_10")]
        public double PP10 { get; set; }
        [Name("TT_10")]
        public double TT10 { get; set; }
        [Name("TM5_10")]
        public double TMS10 { get; set; }
        [Name("RF_10")]
        public double RF10 { get; set; }
        [Name("TD_10")]
        public double TD10 { get; set; }

    }
}
