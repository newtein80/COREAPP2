using COREAPP2.Domain.Entities.EfModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COREAPP2.Application.IRepositories
{
    public interface IMenuMasterRepository
    {
        Task<IEnumerable<T_MENU_MASTER>> GetMenuMasterAsync();
        Task<IEnumerable<T_MENU_MASTER>> GetMenuMasterByUserRoleAsync(string USER_ROLE);

        IEnumerable<T_MENU_MASTER> GetMenuMaster();
        IEnumerable<T_MENU_MASTER> GetMenuMasterByUserRole(string USER_ROLE);
    }
}
