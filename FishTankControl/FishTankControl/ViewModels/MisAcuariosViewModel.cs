using System;
using System.Diagnostics;
using System.Threading.Tasks;

using FishTankControl.Helpers;
using FishTankControl.Models;
using FishTankControl.Views;

using Xamarin.Forms;

namespace FishTankControl.ViewModels
{
    public class MisAcuariosViewModel : BaseMisAcuariosViewModel
    {
        public ObservableRangeCollection<Acuario> Acuarios { get; set; }
        public Command LoadAcuariosCommand { get; set; }

        public MisAcuariosViewModel()
        {
            Title = "Mis Acuarios";
            Acuarios = new ObservableRangeCollection<Acuario>();
            LoadAcuariosCommand = new Command(async () => await ExecuteLoadAcuariosCommand());

            MessagingCenter.Subscribe<NuevoAcuarioPage, Acuario>(this, "NuevoAcuario", async (obj, item) =>
            {
                var _item = item as Acuario;
                Acuarios.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadAcuariosCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Acuarios.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Acuarios.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "No se pudieron cargar los acuarios.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}