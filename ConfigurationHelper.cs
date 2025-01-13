using Microsoft.Extensions.Configuration;

public static class ConfigurationHelper
{
    private static readonly IConfigurationRoot _configuration;

    static ConfigurationHelper()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }

    /*Get a single value with error handling
    public static string GetSetting(string key)
    {
        string value = _configuration[key];
        if (string.IsNullOrEmpty(value))
        {
            throw new KeyNotFoundException($"Key '{key}' not found in configuration.");
        }
        return value;
    }*/

    // Get a single value with a default
    public static string GetSetting(string key, string defaultValue)
    {
        return _configuration[key] ?? defaultValue;
    }

    // Bind a section to a strongly-typed object
    public static T GetSection<T>(string sectionName) where T : new()
    {
        var section = new T();
        _configuration.GetSection(sectionName).Bind(section);
        return section;
    }
}
