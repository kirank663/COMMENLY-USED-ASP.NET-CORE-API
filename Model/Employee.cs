using System.ComponentModel.DataAnnotations;

namespace CommenReactProjectAPI.Model
{
      public class Employee
      {
            public int Id { get; set; }

            public string FName { get; set; }

            public string LName { get; set; }

            public string Email { get; set; }

            public string PhoneNo { get; set; }

            public string DateOfBirth { get; set; }

            public string JoiningDate { get; set; }

            public string Position { get; set; }

            public string Department { get; set; }

            public string Address { get; set; }

            public string City { get; set; }

            public string State { get; set; }

            public string Zipcode { get; set; }
      }
}
