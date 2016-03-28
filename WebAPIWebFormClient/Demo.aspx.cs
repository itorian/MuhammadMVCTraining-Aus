using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAPIWebFormClient
{
    public partial class Demo : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53506/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/student/");
                if (response.IsSuccessStatusCode)
                {
                    List<Student> obj = JsonConvert.DeserializeObject<List<Student>>(response.Content.ReadAsStringAsync().Result);

                    GridView1.DataSource = obj;
                    GridView1.DataBind();

                }
            }
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}