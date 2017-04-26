using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FishTankControl.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(FishTankControl.Services.DatoPezDataStore))]
namespace FishTankControl.Services
{
    public class DatoPezDataStore : IDataStore<DatoPezPersonal>
    {
        bool isInitialized;
        List<DatoPezPersonal> datosPezPersonal;

        public async Task<bool> AddItemAsync(DatoPezPersonal datoPezPersonal)
        {
            await InitializeAsync();

            datosPezPersonal.Add(datoPezPersonal);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(DatoPezPersonal datoPezPersonal)
        {
            await InitializeAsync();

            var _datoPezPersonal = datosPezPersonal.Where((DatoPezPersonal arg) => arg.Id == datoPezPersonal.Id).FirstOrDefault();
            datosPezPersonal.Remove(_datoPezPersonal);
            datosPezPersonal.Add(datoPezPersonal);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(DatoPezPersonal datoPezPersonal)
        {
            await InitializeAsync();

            var _datoPezPersonal = datosPezPersonal.Where((DatoPezPersonal arg) => arg.Id == datoPezPersonal.Id).FirstOrDefault();
            datosPezPersonal.Remove(_datoPezPersonal);

            return await Task.FromResult(true);
        }

        public async Task<DatoPezPersonal> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(datosPezPersonal.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<DatoPezPersonal>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(datosPezPersonal);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {//AQUI SE AGREGARÁ LA CARGA DE DATOS DESDE LA BD
            if (isInitialized)
                return;

            datosPezPersonal = new List<DatoPezPersonal>();
            var _datosPezPersonal = new List<DatoPezPersonal>
            {
                new DatoPezPersonal { Id = Guid.NewGuid().ToString(), Nombre = "Dato 1", Descripcion="Este es el Dato 1"},
                new DatoPezPersonal { Id = Guid.NewGuid().ToString(), Nombre = "Dato 2", Descripcion="Este es el Dato 2"},
                new DatoPezPersonal { Id = Guid.NewGuid().ToString(), Nombre = "Dato 3", Descripcion="Este es el Dato 3"},
                new DatoPezPersonal { Id = Guid.NewGuid().ToString(), Nombre = "Dato 4", Descripcion="Este es el Dato 4"},
                new DatoPezPersonal { Id = Guid.NewGuid().ToString(), Nombre = "Dato 5", Descripcion="Este es el Dato 5"},
                new DatoPezPersonal { Id = Guid.NewGuid().ToString(), Nombre = "Dato 6", Descripcion="Este es el Dato 6"},
            };

            foreach (DatoPezPersonal datoPezPersonal in _datosPezPersonal)
            {
                datosPezPersonal.Add(datoPezPersonal);
            }

            isInitialized = true;
        }
    }
}
