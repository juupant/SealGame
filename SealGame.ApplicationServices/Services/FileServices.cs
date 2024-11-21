
using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SealGame.Core.Domain;
using SealGame.Core.Dto;
using SealGame.Core.ServiceInterface;
using SealGame.Data;

namespace SealGame.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly DatabaseTaskDbContext _context;

        public FileServices(
            IHostEnvironment webHost,
            DatabaseTaskDbContext context
        )
        {
            _webHost = webHost;
            _context = context;
        }

        public async Task UploadFilesToDatabase(SealDto dto, Seal seal)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var file in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase uploadedFile = new FileToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = file.FileName,
                            SealId = seal.Id
                        };

                        await file.CopyToAsync(target);
                        uploadedFile.ImageData = target.ToArray();

                        _context.FileToDatabaseDto.Add(uploadedFile);
                    }
                }

                await _context.SaveChangesAsync();
            }
        }

        public async Task<FileToDatabase?> RemoveImageFromDatabase(Guid fileId)
        {
            var fileEntry = await _context.FileToDatabaseDto
                .FirstOrDefaultAsync(x => x.Id == fileId);

            if (fileEntry == null) return null;

            var filePath = Path.Combine(_webHost.ContentRootPath, "uploadedFiles", fileEntry.ImageTitle);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FileToDatabaseDto.Remove(fileEntry);
            await _context.SaveChangesAsync();

            return null;
        }
    }
}