using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
public class ConfigHelper
{
    private static readonly IConfiguration _configuration;

    static ConfigHelper()
    {
        string fileName = "appsettings.json";
        string directory = AppContext.BaseDirectory;
        directory = directory.Replace("\\", "/");
        string filePath = $"{directory}/{fileName}";
        if (!File.Exists(filePath))
        {
            var length = directory.IndexOf("/bin");
            filePath = $"{directory.Substring(0, length)}/{fileName}";
        }
        var builder = new ConfigurationBuilder()
            .AddJsonFile(filePath, false, true);

        _configuration = builder.Build();
    }

    /// <summary>
    /// 获取Section的值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string GetSectionValue(string key)
    {
        return _configuration.GetSection(key).Value;
    }

    /// <summary>
    /// 获取ConnectionStrings下的值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string GetConnectionString(string key)
    {
        return _configuration.GetConnectionString(key);
    }
}

