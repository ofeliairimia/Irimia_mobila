using Irimia_mobila.Models;
namespace Irimia_mobila;

public partial class ListaAdaugareProgramari : ContentPage
{
    public ListaAdaugareProgramari()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProgramariAsync();
    }
    async void OnProgramareAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProgramarileMele
        {
            BindingContext = new Programare()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ProgramarileMele
            {
                BindingContext = e.SelectedItem as Programare
            });
        }
    }
}