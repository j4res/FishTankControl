using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FishTankControl.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(FishTankControl.Services.AcuarioDataStore))]
namespace FishTankControl.Services
{
    public class AcuarioDataStore : IDataStore<Acuario>
    {
        bool isInitialized;
        List<Acuario> acuarios;

        public async Task<bool> AddItemAsync(Acuario acuario)
        {
            await InitializeAsync();

            acuarios.Add(acuario);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Acuario acuario)
        {
            await InitializeAsync();

            var _acuario = acuarios.Where((Acuario arg) => arg.Id == acuario.Id).FirstOrDefault();
            acuarios.Remove(_acuario);
            acuarios.Add(acuario);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Acuario acuario)
        {
            await InitializeAsync();

            var _acuario = acuarios.Where((Acuario arg) => arg.Id == acuario.Id).FirstOrDefault();
            acuarios.Remove(_acuario);

            return await Task.FromResult(true);
        }

        public async Task<Acuario> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(acuarios.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Acuario>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(acuarios);
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

            acuarios = new List<Acuario>();
            var _acuarios = new List<Acuario>
            {
                new Acuario { Id = Guid.NewGuid().ToString(), Text = "Acuario 1", Description="Este es el acuario 1"},
                new Acuario { Id = Guid.NewGuid().ToString(), Text = "Acuario 2", Description="Este es el acuario 2"},
                new Acuario { Id = Guid.NewGuid().ToString(), Text = "Acuario 3", Description="Este es el acuario 3"},
                new Acuario { Id = Guid.NewGuid().ToString(), Text = "Acuario 4", Description="Este es el acuario 4"},
                new Acuario { Id = Guid.NewGuid().ToString(), Text = "Acuario 5", Description="Este es el acuario 5"},
                new Acuario { Id = Guid.NewGuid().ToString(), Text = "Acuario 6", Description="Este es el acuario 6"},
            };

            foreach (Acuario acuario in _acuarios)
            {
                acuarios.Add(acuario);
            }

            isInitialized = true;
        }
    }
}
