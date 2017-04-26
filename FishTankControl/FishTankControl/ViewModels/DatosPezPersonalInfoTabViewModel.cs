using System;
using System.Diagnostics;
using System.Threading.Tasks;

using FishTankControl.Helpers;
using FishTankControl.Models;
using FishTankControl.Views;

using Xamarin.Forms;

namespace FishTankControl.ViewModels
{
    public class DatosPezPersonalInfoTabViewModel : BaseDatosPezPersonalInfoTabViewModel
    {
        public ObservableRangeCollection<DatoPezPersonal> DatosPezPersonal { get; set; }
        public Command LoadDatosPezPersonalCommand { get; set; }

        public DatosPezPersonalInfoTabViewModel()
        {
            Title = "Mis Datos Pez Personal";
            DatosPezPersonal = new ObservableRangeCollection<DatoPezPersonal>();
            LoadDatosPezPersonalCommand = new Command(async () => await ExecuteLoadDatosPezPersonalCommand());

            MessagingCenter.Subscribe<NuevoDatoPezPersonalInfoPage, DatoPezPersonal>(this, "NuevoDatoPezPersonal", async (obj, item) =>
            {
                var _item = item as DatoPezPersonal;
                DatosPezPersonal.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadDatosPezPersonalCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                DatosPezPersonal.Clear();
                var items = await DataStore.GetItemsAsync(true);
                DatosPezPersonal.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "No se pudieron cargar los datos de los peces.",
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