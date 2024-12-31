﻿using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

public class FileLogger : LoggerServiceBase
{
    private readonly IConfiguration _configuration;

    public FileLogger(IConfiguration configuration)
    {
        _configuration = configuration;

        FileLogConfiguration logConfig = configuration
            .GetSection("SerilogLogConfigurations:FileLogConfiguration")
            .Get<FileLogConfiguration>() ?? throw new Exception("You have sent a blank value! Something went wrong. Please try again.");
        string logFilePath = string.Format(format: "{0}{1}", arg0: Directory.GetCurrentDirectory() + logConfig.FolderPath, arg1: ".txt");

        Logger = new LoggerConfiguration().WriteTo.File(
            logFilePath,
            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: null,
            fileSizeLimitBytes: 5000000,
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
        ).CreateLogger();
    }



}
