using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ZohoBooksContacts
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://books.zoho.com/api/v3/contacts");
            var request = new RestRequest("POST");
            request.AddHeader("Authorization", "Zoho-authtoken 1000.589e3dd9955d413106257b06b73aa18e.8e39360c1a248031ed2df0fb01f3a537");
            request.AddHeader("Content-Type", "application/json");

            var contact = new
            {
                contact_name = "Aishwarya C",
                company_name = "ASH Inc",
                email = "Ash.cs@example.com",
                phone = "9087654321"
            };
            string json = JsonConvert.SerializeObject(contact, Formatting.Indented);

            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            JObject obj = JObject.Parse(response.Content);
            string contactId = obj["contact"]["contact_id"].ToString();

            Console.WriteLine("Contact created with ID: " + contactId);
            Console.ReadLine();
        }
    }
}
