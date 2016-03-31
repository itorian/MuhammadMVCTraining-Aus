using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPIModel;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using DTO;
using PagedList;

namespace WebAPIMVCClientReference.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public async Task<ActionResult> Index(string sort = "id", int? page = 1, string fields = "id,name,address")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53506/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/student?sort=" + sort + "&page=" + page + "&fields=" + fields);
                if (response.IsSuccessStatusCode)
                {
                    List<Student> students = await response.Content.ReadAsAsync<List<Student>>();

                    List<StudentViewModel> model = new List<StudentViewModel>();
                    StudentDTO dto = new StudentDTO();
                    model = dto.ConvertToStudentViewModel(students);

                    int pageSize = 3;
                    int pageNumber = (page ?? 1);
                    return View(model.ToPagedList(pageNumber, pageSize));
                }

                var re = response.Content.ReadAsStringAsync().Result;

            }            

            return View("Error");
        }

        public async Task<ActionResult> Details(int id)
        {
            if(id == 0)
            {
                return View("Error");
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53506/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/student/" + id);
                if (response.IsSuccessStatusCode)
                {
                    Student student = await response.Content.ReadAsAsync<Student>();

                    StudentViewModel model = new StudentViewModel();
                    StudentDTO dto = new StudentDTO();
                    model = dto.ConvertToStudentViewModel(student);

                    return View(model);
                }
            }

            return View("Error");
        }


        // TODO: save, update, delete
    }
}