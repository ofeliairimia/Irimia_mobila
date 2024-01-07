using Irimia_mobila.Models;
using Plugin.LocalNotification;

namespace Irimia_mobila;

public partial class ClinicaPage : ContentPage
{
    public ClinicaPage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var clinica = (Clinica)BindingContext;
        await App.Database.SaveClinicaAsync(clinica);
        await Navigation.PopAsync();
    }
    async void OnArataHartaButtonClicked(object sender, EventArgs e)
    {
        var clinica = (Clinica)BindingContext;
        var addresa = clinica.Adresa;
        var locatii = await Geocoding.GetLocationsAsync(addresa);

        var options = new MapLaunchOptions
        {
            Name = "Clinica la care voi face investigatia"
        };
        var locatie = locatii?.FirstOrDefault();
        var locatiaMea = new Location(46.7731796289, 23.6213886738);
        var distanta = locatiaMea.CalculateDistance(locatie, DistanceUnits.Kilometers);
        if (distanta < 4)
        {
            var request = new NotificationRequest
            {
                Title = "Ai salvata o programare în apropiere!",
                Description = addresa,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
        await Map.OpenAsync(locatie, options);
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var clinica = (Clinica)BindingContext;
        await App.Database.DeleteClinicaAsync(clinica);
        await Navigation.PopAsync();
    }
}