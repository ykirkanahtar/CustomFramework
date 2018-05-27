using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CustomFramework.FtpClient
{
    public class FtpClient : FtpClientBase, IFtpClient
    {
        private FtpWebRequest _ftpWebRequest = null;
        private const int BufferSize = 2048;

        public FtpClient(ILogger<FtpClient> logger, string hostIp, string defaultFolder, string userName, string password) : base(logger, hostIp, defaultFolder, userName, password)
        {

        }

        public async Task DownloadAsync(string remoteFileName, string localFileName)
        {
            try
            {
                GeneralSettings(remoteFileName, WebRequestMethods.Ftp.DownloadFile);

                var ftpWebResponse = (FtpWebResponse)await _ftpWebRequest.GetResponseAsync();
                var ftpStream = ftpWebResponse.GetResponseStream();

                var localFileStrem = new FileStream(localFileName, FileMode.Create);
                var byteBuffer = new byte[BufferSize];
                if (ftpStream == null) throw new ArgumentNullException(localFileName);

                var bytesRead = await ftpStream.ReadAsync(byteBuffer, 0, BufferSize);

                try
                {
                    while (bytesRead > 0)
                    {
                        await localFileStrem.WriteAsync(byteBuffer, 0, bytesRead);
                        bytesRead = await ftpStream.ReadAsync(byteBuffer, 0, BufferSize);
                    }
                }
                catch (Exception e)
                {
                    Logger.LogCritical(0, e, e.Message);
                    throw;
                }

                localFileStrem.Close();
                ftpStream.Close();
                ftpWebResponse.Close();
                _ftpWebRequest = null;
            }
            catch (Exception e)
            {
                Logger.LogCritical(0, e, e.Message);
                throw;
            }
        }

        public async Task UploadAsync(string remoteFileName, string localFileName)
        {
            try
            {
                GeneralSettings(remoteFileName, WebRequestMethods.Ftp.UploadFile);

                _ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;

                using (var fileStream = File.OpenRead(localFileName))
                {
                    using (var ftpStream = await _ftpWebRequest.GetRequestStreamAsync())
                    {
                        await fileStream.CopyToAsync(ftpStream);
                    }
                }

                _ftpWebRequest = null;
            }
            catch (Exception e)
            {
                Logger.LogCritical(0, e, e.Message);
                throw;
            }
        }

        public async Task DeleteAsync(string fileName)
        {
            try
            {
                GeneralSettings(fileName, WebRequestMethods.Ftp.DeleteFile);

                var ftpWebResponse = (FtpWebResponse)await _ftpWebRequest.GetResponseAsync();

                ftpWebResponse.Close();
                _ftpWebRequest = null;
            }
            catch (Exception e)
            {
                Logger.LogCritical(0, e, e.Message);
                throw;
            }
        }

        public async Task RenameAsync(string currentFileName, string newFileName)
        {
            try
            {
                GeneralSettings(currentFileName, WebRequestMethods.Ftp.Rename);

                _ftpWebRequest.RenameTo = newFileName;
                var ftpWebResponse = (FtpWebResponse)await _ftpWebRequest.GetResponseAsync();

                ftpWebResponse.Close();
                _ftpWebRequest = null;
            }
            catch (Exception e)
            {
                Logger.LogCritical(0, e, e.Message);
                throw;
            }
        }

        public async Task CreateDirectoryAsync(string directoryName)
        {
            try
            {
                GeneralSettings(directoryName, WebRequestMethods.Ftp.MakeDirectory);

                var ftpWebResponse = (FtpWebResponse)await _ftpWebRequest.GetResponseAsync();

                ftpWebResponse.Close();
                _ftpWebRequest = null;
            }
            catch (Exception e)
            {
                Logger.LogCritical(0, e, e.Message);
                throw;
            }
        }

        public async Task<string> GetFileCreatedDateTimeAsync(string fileName)
        {
            try
            {
                GeneralSettings(fileName, WebRequestMethods.Ftp.GetDateTimestamp);

                var ftpWebResponse = (FtpWebResponse)await _ftpWebRequest.GetResponseAsync();

                var ftpStream = ftpWebResponse.GetResponseStream();

                if (ftpStream == null) throw new ArgumentNullException(fileName);

                var ftpReader = new StreamReader(ftpStream);

                string fileInfo;

                try
                {
                    fileInfo = await ftpReader.ReadToEndAsync();
                }
                catch (Exception e)
                {
                    Logger.LogCritical(0, e, e.Message);
                    throw;
                }

                ftpReader.Close();
                ftpStream.Close();
                ftpWebResponse.Close();
                _ftpWebRequest = null;

                return fileInfo;
            }
            catch (Exception e)
            {
                Logger.LogCritical(0, e, e.Message);
                throw;
            }
        }

        public async Task<string> GetFileSizeAsync(string fileName)
        {
            try
            {
                GeneralSettings(fileName, WebRequestMethods.Ftp.GetFileSize);


                var ftpWebResponse = (FtpWebResponse)await _ftpWebRequest.GetResponseAsync();

                var ftpStream = ftpWebResponse.GetResponseStream();

                if (ftpStream != null)
                {
                    var ftpReader = new StreamReader(ftpStream);

                    string fileInfo = null;

                    try
                    {
                        while (ftpReader.Peek() != -1)
                        {
                            fileInfo = await ftpReader.ReadToEndAsync();
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.LogCritical(0, e, e.Message);
                        throw;
                    }

                    ftpReader.Close();
                    ftpStream.Close();
                    ftpWebResponse.Close();
                    _ftpWebRequest = null;

                    return fileInfo;
                }
                throw new ArgumentNullException(fileName); //else
            }
            catch (Exception e)
            {
                Logger.LogCritical(0, e, e.Message);
                throw;
            }
        }

        public async Task<string> GetFileTextAsync(string fileName)
        {
            try
            {
                var url = $"{HostIp}//{DefaultFolder}/{fileName}";

                try
                {
                    using (var request = new WebClient())
                    {
                        request.Credentials = new NetworkCredential(UserName, Password);
                        var newFileData = await request.DownloadDataTaskAsync(new Uri(url));
                        return System.Text.Encoding.UTF8.GetString(newFileData);
                    }
                }
                catch (WebException e)
                {
                    Logger.LogCritical(0, e, e.Message);
                    throw;
                }
            }
            catch (Exception e)
            {
                Logger.LogCritical(0, e, e.Message);
                throw;
            }
        }

        public async Task<bool> DirectoryIsExistAsync(string directoryName)
        {
            try
            {
                GeneralSettings(directoryName, WebRequestMethods.Ftp.ListDirectory);

                await _ftpWebRequest.GetResponseAsync();
                return true;
            }
            catch (WebException)
            {
                return false;
            }
            catch (Exception e)
            {
                Logger.LogCritical(0, e, e.Message);
                throw;
            }
        }

        public async Task<List<string>> GetSimpleDirectoryListAsync(string directory)
        {
            return await GetSimpleDirectoryListByExtensionListAsync(directory, new List<string>());
        }

        public async Task<List<string>> GetSimpleDirectoryListByExtensionListAsync(string directory, List<string> extensionList)
        {
            try
            {
                GeneralSettings(directory, WebRequestMethods.Ftp.ListDirectory);

                var ftpWebResponse = (FtpWebResponse)await _ftpWebRequest.GetResponseAsync();

                var ftpStream = ftpWebResponse.GetResponseStream();

                if (ftpStream == null) throw new ArgumentNullException(directory);
                var ftpReader = new StreamReader(ftpStream);

                var results = new List<string>();

                try
                {
                    while (ftpReader.Peek() != -1)
                    {
                        if (extensionList.Count > 0)
                        {
                            var checkedExtensionList = extensionList.Select(extension => !extension.StartsWith(".") ? $".{extension}" : extension).ToList();


                            var line = await ftpReader.ReadLineAsync();
                            while (!string.IsNullOrEmpty(line))
                            {
                                foreach (var extension in checkedExtensionList)
                                {
                                    if (line.Contains(extension))
                                    {
                                        results.Add(line);
                                    }
                                }
                                line = await ftpReader.ReadLineAsync();
                            }
                        }
                        else
                        {
                            var line = await ftpReader.ReadLineAsync();
                            while (!string.IsNullOrEmpty(line))
                            {
                                results.Add(line);
                                line = await ftpReader.ReadLineAsync();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Logger.LogCritical(0, e, e.Message);
                }

                ftpReader.Close();
                ftpStream.Close();
                ftpWebResponse.Close();
                _ftpWebRequest = null;
                return results;
            }
            catch (Exception e)
            {
                Logger.LogCritical(0, e, e.Message);
                throw;
            }
        }

        public async Task<List<string>> GetDetailedDirectoryListAsync(string directory)
        {
            try
            {
                GeneralSettings(directory, WebRequestMethods.Ftp.ListDirectoryDetails);

                var ftpWebResponse = (FtpWebResponse)await _ftpWebRequest.GetResponseAsync();

                var ftpStream = ftpWebResponse.GetResponseStream();

                if (ftpStream == null) throw new ArgumentNullException(directory);
                var ftpReader = new StreamReader(ftpStream);

                var directoryRaw = new StringBuilder();
                try
                {
                    while (ftpReader.Peek() != -1)
                    {
                        var readText = await ftpReader.ReadLineAsync();
                        directoryRaw.Append($"{readText}|");
                    }
                }
                catch (Exception e)
                {
                    Logger.LogCritical(0, e, e.Message);
                    throw;
                }

                ftpReader.Close();
                ftpStream.Close();
                ftpWebResponse.Close();
                _ftpWebRequest = null;

                try
                {
                    if (directoryRaw.Length == 0) throw new ArgumentNullException(directory);

                    var directoryList = directoryRaw.ToString().Split("|".ToCharArray());
                    return new List<string>(directoryList);
                }
                catch (Exception e)
                {
                    Logger.LogCritical(0, e, e.Message);
                    throw;
                }
            }
            catch (Exception e)
            {
                Logger.LogCritical(0, e, e.Message);
                throw;
            }
        }

        private void GeneralSettings(string fileName, string method)
        {
            var uri = $"{HostIp}//{DefaultFolder}/{fileName}";
            _ftpWebRequest = (FtpWebRequest)WebRequest.Create(uri);
            _ftpWebRequest.Credentials = new NetworkCredential(UserName, Password);
            _ftpWebRequest.UseBinary = true;
            _ftpWebRequest.UsePassive = true;
            _ftpWebRequest.KeepAlive = true;
            _ftpWebRequest.Method = method;
        }

    }
}