using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Threading.Tasks;
using SealGame.Core.Domain;
using SealGame.Core.Dto;

namespace SealGame.Core.ServiceInterface
{
    public interface IFileServices
    {
        Task UploadFilesToDatabase(SealDto dto, Seal seal);
        Task<FileToDatabaseDto> RemoveImageFromDatabase(Guid fileId);
    }
}