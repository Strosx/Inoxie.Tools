using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.Core.Repository.Abstractions
{
    public interface IDatabaseContextProvider
    {
        DbContext Get();
    }
}
