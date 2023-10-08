using Newtonsoft.Json;

namespace EmployeeApplication.Business.Entities
{
    public class Employee
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("employee_name")]
        public string Name { get; set; }

        [JsonProperty("employee_salary")]
        public int Salary { get; set; }

        [JsonProperty("employee_age")]
        public string Age { get; set; }

        [JsonProperty("profile_image")]
        public string Image { get; set; }
        public int SalaryAnual { get { return this.Salary * 12; } }

    }
}
