using Irimia_mobila.Models;
namespace Irimia_mobila;

public partial class ProgramarileMele : ContentPage
{
    public ProgramarileMele()
    {
        InitializeComponent();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var plist = (Programare)BindingContext;
        plist.DataProgramare = DateTime.UtcNow;
        Clinica clinicaSelectata = (ClinicaPicker.SelectedItem as Clinica);
        plist.ClinicaID = clinicaSelectata.ID;
        await App.Database.SaveProgramareAsync(plist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var plist = (Programare)BindingContext;
        await App.Database.DeleteProgramareAsync(plist);
        await Navigation.PopAsync();
    }
    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Serviciu serviciu;
        var programare = (Programare)BindingContext;
        if (listView.SelectedItem != null)
        {
            serviciu = listView.SelectedItem as Serviciu;
            var listaToateServiciile = await App.Database.GetListaServicii();
            var listaServiciu = listaToateServiciile.FindAll(x => x.ServiciuID == serviciu.ID & x.ProgramareID == programare.ID);
            await App.Database.DeleteListaServiciuAsync(listaServiciu.FirstOrDefault());
            await Navigation.PopAsync();
        }
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ServiciuPage((Programare)this.BindingContext)
        {
            BindingContext = new Serviciu()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var items = await App.Database.GetCliniciAsync();
        ClinicaPicker.ItemsSource = (System.Collections.IList)items;
        ClinicaPicker.ItemDisplayBinding = new Binding("DetaliiClinica");
        var lprogramare = (Programare)BindingContext;
        listView.ItemsSource = await App.Database.GetListaServiciiAsync(lprogramare.ID);
    }

}