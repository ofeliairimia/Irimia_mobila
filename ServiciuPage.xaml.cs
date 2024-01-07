using Irimia_mobila.Models;

namespace Irimia_mobila;

public partial class ServiciuPage : ContentPage
{
    Programare p;
    public ServiciuPage(Programare progr)
    {
        InitializeComponent();
        p = progr;

    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Serviciu)BindingContext;
        await App.Database.SaveServiciuAsync(serviciu);
        listView.ItemsSource = await App.Database.GetServiciiAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Serviciu)BindingContext;
        await App.Database.DeleteServiciuAsync(serviciu);
        listView.ItemsSource = await App.Database.GetServiciiAsync();
    }
    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Serviciu serviciu;
        var serv = (Serviciu)BindingContext;
        if (listView.SelectedItem != null)
        {
            serviciu = listView.SelectedItem as Serviciu;
            var listaToateServiciile = await App.Database.GetServiciiAsync();
            var listaServiciu = listaToateServiciile.FindAll(x => x.ID == serviciu.ID);
            await App.Database.DeleteServiciuAsync(listaServiciu.FirstOrDefault());
            await Navigation.PopAsync();
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetServiciiAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Serviciu s;
        if (listView.SelectedItem != null)
        {
            s = listView.SelectedItem as Serviciu;
            var ls = new ListaServiciu()
            {
                ProgramareID = p.ID,
                ServiciuID = s.ID
            };
            await App.Database.SaveListaServiciuAsync(ls);
            s.ListaServicii = new List<ListaServiciu> { ls };
            await Navigation.PopAsync();
        }

    }
}