using Irimia_mobila.Models;

namespace Irimia_mobila;

public partial class AdaugareClinica : ContentPage
{
    public AdaugareClinica()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCliniciAsync();
    }
    async void OnClinicaAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClinicaPage
        {
            BindingContext = new Clinica()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ClinicaPage
            {
                BindingContext = e.SelectedItem as Clinica
            });
        }
    }
}