namespace DDDCinema.Movies.Lotery
{
    /// <summary>
    /// Calculates win chance for user
    /// </summary>
    public interface IWinChanceCalculator
    {
        WinChance CalculateWinChance(User user);
    }
}
