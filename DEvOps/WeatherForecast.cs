namespace DEvOps
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
  public class TeamInfo
  {
    public string team_name { get; set; }
    public int overall_league_position { get; set; }
    public int overall_league_payed { get; set; }
    public int overall_league_W { get; set; }
    public int overall_league_D { get; set; }
    public int overall_league_L { get; set; }
    public int overall_league_GF { get; set; }
    public int overall_league_GA { get; set; }
    public int overall_league_PTS { get; set; }
  }

}
