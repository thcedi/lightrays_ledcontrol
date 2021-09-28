using LightRays.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightRays.Core.Services.PresetService
{
    public class PresetService : IPresetService
    {
        private IDatabaseService _db;

        public PresetService(IDatabaseService databaseService)
        {
            _db = databaseService;
        }

        public async Task<int> Create(Preset preset)
        {
            if (await _db.ConnectionAsync.InsertAsync(preset) > 0) return await _db.ConnectionAsync.ExecuteScalarAsync<int>("SELECT last_insert_rowid();");

            return 0;
        }

        public async Task<bool> Delete(Preset preset)
        {
            if (await _db.ConnectionAsync.DeleteAsync(preset) == 1) return true;

            return false;
        }

        public async Task<List<Preset>> Read()
        {
            return await _db.ConnectionAsync.Table<Preset>().ToListAsync();
        }

        public async Task<int> Update(Preset preset)
        {
            return await _db.ConnectionAsync.UpdateAsync(preset);
        }
    }
}
