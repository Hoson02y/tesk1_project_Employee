using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Employee.Pages
{
    public class EmployeesModel : PageModel
    {
        public List<Employee> ListEmployee = new List<Employee>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=project;Integrated Security=True";
                using SqlConnection sqlConnection = new SqlConnection(connectionString);
                {
                    sqlConnection.Open();
                    string sql = "select * from Employees";
                    using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Employee employee1 = new Employee();
                                employee1.EmployeeID = reader.GetInt32(0);
                                employee1.EmployeeName = reader.GetString(1);
                                employee1.Address = reader.GetString(2);
                                employee1.Function = reader.GetString(3);
                                employee1.DateOfBirth = reader.GetDateTime(4);
                                employee1.DateOfEmployment = reader.GetDateTime(5);

                                ListEmployee.Add(employee1);



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        public class Employee
        {
            public int EmployeeID;
            public string EmployeeName;
            public string Address;
            public string Function;
            public DateTime DateOfBirth;
            public DateTime DateOfEmployment;
        }
    }
}
