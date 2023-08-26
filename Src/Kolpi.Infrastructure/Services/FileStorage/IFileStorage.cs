namespace Kolpi.Infrastructure.Services.FileStorage;
public interface IFileStorage
{
    public void Upload(FileStream stra);
    Task<byte[]> Download(string key);
}
