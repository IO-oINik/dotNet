namespace Service.Settings;

public static class FilmportalSettingsReader
{
    public static FilmportalSettings Read(IConfiguration configuration)
    {
        return new FilmportalSettings()
        {
            FilmportalDbContextConnectionString = configuration.GetValue<string>("FilmportalDbContext")
        };
    }
}