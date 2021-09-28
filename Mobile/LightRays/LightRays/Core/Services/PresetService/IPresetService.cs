using LightRays.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightRays.Core.Services.PresetService
{
    public interface IPresetService
    {
        Task<List<Preset>> Read();

        Task<int> Create(Preset preset);

        Task<int> Update(Preset preset);

        Task<bool> Delete(Preset preset);
    }
}
