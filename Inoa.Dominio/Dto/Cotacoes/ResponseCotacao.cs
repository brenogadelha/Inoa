namespace Inoa.Dominio.Dto.Cotacoes
{
    public class ResponseCotacao
    {
        public string Symbol { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public double? TwoHundredDayAverage { get; set; }
        public double? TwoHundredDayAverageChange { get; set; }
        public double? TwoHundredDayAverageChangePercent { get; set; }
        public long MarketCap { get; set; }
        public string ShortName { get; set; } = string.Empty;
        public string LongName { get; set; } = string.Empty;
        public double? RegularMarketChange { get; set; }
        public double? RegularMarketChangePercent { get; set; }
        public string RegularMarketTime { get; set; } = string.Empty;
        public double RegularMarketPrice { get; set; }
        public double? RegularMarketDayHigh { get; set; }
        public string RegularMarketDayRange { get; set; } = string.Empty;
        public double? RegularMarketDayLow { get; set; }
        public int RegularMarketVolume { get; set; }
        public double? RegularMarketPreviousClose { get; set; }
        public double? RegularMarketOpen { get; set; }
        public int AverageDailyVolume3Month { get; set; }
        public int AverageDailyVolume10Day { get; set; }
        public double FiftyTwoWeekLowChange { get; set; }
        public double? FiftyTwoWeekLowChangePercent { get; set; }
        public string FiftyTwoWeekRange { get; set; } = string.Empty;
        public double? FiftyTwoWeekHighChange { get; set; }
        public double? FiftyTwoWeekHighChangePercent { get; set; }
        public double? FiftyTwoWeekLow { get; set; }
        public double? FiftyTwoWeekHigh { get; set; }
        public double? PriceEarnings { get; set; }
        public double? EarningsPerShare { get; set; }
        public string Logourl { get; set; } = string.Empty;
        public string UpdatedAt { get; set; } = string.Empty;
    }

    public class ResultCotacao
    {
        public List<ResponseCotacao> Results { get; set; } = new List<ResponseCotacao>();
        public DateTime RequestedAt { get; set; }
        public string Took { get; set; } = string.Empty;
    }

}