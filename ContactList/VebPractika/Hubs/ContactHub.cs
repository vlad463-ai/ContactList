using Microsoft.AspNetCore.SignalR;
using ContactList.Model;

namespace ContactList.Hubs
{
    public class ContactHub : Hub
    {
        // Отправка обновления контакта всем клиентам
        public async Task SendContactUpdate(ContactList.Model.Contact contact)
        {
            await Clients.All.SendAsync("ContactUpdated", contact);
        }
    }
}
