using Microsoft.AspNetCore.Http;
using RestWithASPNET5.Data.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithASPNET5.Services
{
    public interface IFileService
    {
        public byte[] GetFile(string fileName);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> file);
    }
}
