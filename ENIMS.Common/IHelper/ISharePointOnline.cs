using ENIMS.Common.Model;
using System.Threading.Tasks;

namespace ENIMS.Common.IHelper
{
    public interface ISharePointOnline
    {
        public Task<bool> UploadFileToSharePointOnlineAsync(FileConfig fileConfig);
    }
}
