namespace Kolpi.ApplicationCore.Entities
{
    public class Reputation : EditBase<int>
    {
        public int TotalScore { get; set; }
        public int OutstandingBadges  { get; set; }
        public byte[] OutstandingBadgesIcon { get; set; } = default!;
        public int ExcellentBadges  { get; set; }
        public byte[] ExcellentBadgesIcon  { get; set; } = default!;
        public int VeryGoodBadges  { get; set; }
        public byte[] VeryGoodBadgesIcon  { get; set; } = default!;
        public int GoodBadges { get; set; }
        public byte[] GoodBadgesIcon { get; set; } = default!;

    }
}
