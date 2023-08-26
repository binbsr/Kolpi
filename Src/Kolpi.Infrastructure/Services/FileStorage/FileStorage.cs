using Azure.Storage.Files.Shares;
using Azure;
using Azure.Storage.Files.Shares.Models;

namespace Kolpi.Infrastructure.Services.FileStorage;
public class FileStorage
{
    public async Task<string> Upload(FileStream stream)
    {
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=kolpistorage;AccountKey=P838aXWpO3uf/YShfmKq+j7k80OnOBHFcpBsDU1GvfwwTnY3Pjd8r+MO1WRta9Wjhcx7lBpwKpOz+ASt7/zujw==;EndpointSuffix=core.windows.net";

        // Name of the share, directory, and file we'll create
        string shareName = "kolpi-dev";
        string dirName = "images";
        string fileName = Guid.NewGuid() + stream.Name;
        
        // Get a reference to a share and then create it
        ShareClient share = new(connectionString, shareName);
        share.CreateIfNotExists();

        // Get a reference to a directory and create it
        ShareDirectoryClient directory = share.GetDirectoryClient(dirName);
        directory.CreateIfNotExists();

        // Get a reference to a file and upload it
        ShareFileClient file = directory.GetFileClient(fileName);
        file.Create(stream.Length);
        _ = await file.UploadRangeAsync(
            new HttpRange(0, stream.Length),
            stream);

        return fileName;
    }

    public async Task<byte[]> Download(string fileKey)
    {
        string connectionString = "<connection_string>";

        // Name of the share, directory, and file we'll download from
        string shareName = "sample-share";
        string dirName = "sample-dir";

        // Get a reference to the file
        ShareClient share = new(connectionString, shareName);
        ShareDirectoryClient directory = share.GetDirectoryClient(dirName);
        ShareFileClient file = directory.GetFileClient(fileKey);

        // Download the file
        ShareFileDownloadInfo download = await file.DownloadAsync();

        using var memoryStream = new MemoryStream();
        await download.Content.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}
