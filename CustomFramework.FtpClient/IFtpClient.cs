using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomFramework.FtpClient
{
    public interface IFtpClient
    {
        Task DownloadAsync(string remoteFileName, string localFileName);

        Task UploadAsync(string remoteFileName, string localFileName);

        Task DeleteAsync(string fileName);

        Task RenameAsync(string currentFileName, string newFileName);

        Task CreateDirectoryAsync(string directoryName);

        Task<string> GetFileCreatedDateTimeAsync(string fileName);

        Task<string> GetFileSizeAsync(string fileName);

        Task<string> GetFileTextAsync(string fileName);

        Task<bool> DirectoryIsExistAsync(string directoryName);

        Task<List<string>> GetSimpleDirectoryListAsync(string directory);

        Task<List<string>> GetSimpleDirectoryListByExtensionListAsync(string directory, List<string> extensionList);

        Task<List<string>> GetDetailedDirectoryListAsync(string directory);
    }
}