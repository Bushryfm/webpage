using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace myweb.pages.client
{
    public class IndexModel : PageModel
    {
        public List<clientInfo> listclients = new List<clientInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = ("Data Source=DESKTOP-ULQ0ESS\\SQLEXPRESS;Initial Catalog=contact;Integrated Security=True");


                using (SqlConnection connection = new SqlConnection(connectionString));
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientInfo clientInfo = new clientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.first_name = reader.GetString(1);
                                clientInfo.last_name = reader.GetString(2);
                                clientInfo.email = reader.GetString(3); ToString();

                                listclients.Add(clientInfo);

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
    public class clientInfo
    {
        public String id;
        public String first_name;
        public String last_name;
        public String email;

    }
}
