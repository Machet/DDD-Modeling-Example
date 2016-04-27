namespace DDDCinema.Movies.Lotery
{
    public class RegularUserWinChanceCalculator : IWinChanceCalculator
    {
        public WinChance CalculateWinChance(User user)
        {
            return new WinChance(10);
        }
    }
}
