﻿namespace RFRAP.Domain.ConfigurationOptions.Files;

public class UploadFilesOptions
{
    public const string Position = "UploadFilesConfiguration";

    public string AbsolutePath { get; init; } = string.Empty;
}