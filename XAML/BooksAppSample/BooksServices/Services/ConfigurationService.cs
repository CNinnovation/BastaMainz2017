namespace BooksServices.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private string _baseUri = "https://testbooks.azurewebsites.net";

        public string BookServiceUrl => $"{_baseUri}/api/Books";
    }
}
