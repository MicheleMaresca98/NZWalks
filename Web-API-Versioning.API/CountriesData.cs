namespace Web_API_Versioning.API
{
    public static class CountriesData
    {
        public static List<Country> Get()
        {
            return new List<Country>
            {
                new Country { Id = 1, Name = "New Zealand" },
                new Country { Id = 2, Name = "Australia" },
                new Country { Id = 3, Name = "United States of America" }
            };
        }
    }
}
