using Redoubt.Models;
using System.Threading.Tasks;

namespace Redoubt.Services.Interfaces
{
    public interface IPlayerService
    {
        Player NewPlayer(string name);
        Task<Player> NewPlayerAsync(string name);
        Task SavePlayerAsync();
        Task LoadPlayerAsync();
    }
}
