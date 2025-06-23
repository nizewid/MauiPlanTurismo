namespace MauiPlanTurismo.Views.Utils;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
    }

    private async void btnSearchContact_Clicked(object sender, EventArgs e)
    {
#if ANDROID
        var permission = await CheckAndRequestContactsPermission();
        if (permission != PermissionStatus.Granted)
            return;

        var contact = await Contacts.PickContactAsync();
        if (contact == null)
            return;

        string cad = $"Id:\t{contact.Id}{Environment.NewLine}" +
                     $"Name Prefix:\t{contact.NamePrefix}{Environment.NewLine}" +
                     $"Given Name:\t{contact.GivenName}{Environment.NewLine}" +
                     $"Middle Name:\t{contact.MiddleName}{Environment.NewLine}" +
                     $"Family Name:\t{contact.FamilyName}{Environment.NewLine}" +
                     $"Name Suffix:\t{contact.NameSuffix}{Environment.NewLine}" +
                     $"Display Name:\t{contact.DisplayName}{Environment.NewLine}";

        foreach (var tel in contact.Phones)
            cad += $"Teléfono:\t{tel.PhoneNumber}{Environment.NewLine}";

        foreach (var mail in contact.Emails)
            cad += $"Email:\t{mail.EmailAddress}{Environment.NewLine}";

        lblContactData.Text = cad;
#else
        await DisplayAlert("No disponible", "Esta función solo está disponible en Android.", "OK");
#endif
    }

    private async void btnListContacts_Clicked(object sender, EventArgs e)
    {
#if ANDROID
        var permission = await CheckAndRequestContactsPermission();
        if (permission != PermissionStatus.Granted)
            return;

        var contacts = await Contacts.GetAllAsync();
        string cad = "";

        foreach (var contact in contacts)
        {
            var phone = contact.Phones.FirstOrDefault()?.PhoneNumber ?? "Sin teléfono";
            cad += $"{phone}:\t{contact.DisplayName}{Environment.NewLine}";
        }

        lblContactsList.Text = cad;
#else
        await DisplayAlert("No disponible", "Esta función solo está disponible en Android.", "OK");
#endif
    }

    private async Task<PermissionStatus> CheckAndRequestContactsPermission()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.ContactsRead>();
        if (status == PermissionStatus.Granted)
            return status;

        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        {
            await DisplayAlert("Permiso de Contactos Denegado", "Debe habilitar el permiso en la configuración del dispositivo", "OK");
            return status;
        }

        if (Permissions.ShouldShowRationale<Permissions.ContactsRead>())
        {
            await DisplayAlert("Permiso necesario", "La app necesita acceso a tus contactos para funcionar correctamente", "OK");
        }

        return await Permissions.RequestAsync<Permissions.ContactsRead>();
    }
}
