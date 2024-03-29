﻿using Microsoft.Extensions.Logging;

namespace CustomFramework.FtpClient
{
    public abstract class FtpClientBase
    {
        protected readonly ILogger<FtpClientBase> Logger;
        protected readonly string HostIp;
        protected readonly string DefaultFolder;
        protected readonly string UserName;
        protected readonly string Password;

        protected FtpClientBase(ILogger<FtpClientBase> logger, string hostIp, string defaultFolder, string userName, string password)
        {
            Logger = logger;
            HostIp = hostIp;
            DefaultFolder = defaultFolder;
            UserName = userName;
            Password = password;
        }

    }
}