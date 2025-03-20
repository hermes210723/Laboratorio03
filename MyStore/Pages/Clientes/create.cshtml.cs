using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyStore.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        public string successMessage = "Model.errorMessage.Length > 0";
        public ClientInfo clientInfo = new ClientInfo();

        public void OnGet()
        {

        }
        public void OnPost() 
        {
            clientInfo.name = Request.Form["name"].FirstOrDefault() ?? string.Empty;
            clientInfo.email = Request.Form["email"].FirstOrDefault() ?? string.Empty;
            clientInfo.phone = Request.Form["phone"].FirstOrDefault() ?? string.Empty;
            clientInfo.address = Request.Form["address"].FirstOrDefault() ?? string.Empty;

            if (clientInfo.name.Length == 0 || clientInfo.email.Length == 0 ||
                clientInfo.phone.Length == 0 || clientInfo.address.Length == 0)
            {
                ViewData["message"] = "All fields are required";
                return;
            }
            //save the new client into the database
            clientInfo.name = "";clientInfo.email = ""; clientInfo.phone = ""; clientInfo.address = "";
            successMessage= "Client added successfully";

        }
    }
}
