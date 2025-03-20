using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyStore.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();
        [Obsolete]
        public void OnGet()
        {
            try
            {

                String connetionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial " +
                    "Catalog=mystore;Integrated Security=True;Connect Timeout=30;Encrypt" +
                    "=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi " +
                    "Subnet Failover=False";
                using (SqlConnection connection = new SqlConnection(connetionString))
                {

                    connection.Open();
                    String sql = "SELECT * FROM clientes";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // constructor por defecto
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id =  reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.address = reader.GetString(4);
                                clientInfo.created_at = reader.GetDateTime(5);

                                listClients.Add(clientInfo);
                            }
                        }
                    }


                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }






    public class ClientInfo
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public DateTime created_at { get; set; }

        // Constructor por defecto
        public ClientInfo()
        {
            id = 0;  // Valor por defecto
            created_at = DateTime.Now;
        }
    }
}
