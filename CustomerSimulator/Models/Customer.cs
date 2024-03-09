namespace CustomerSimulator.Models
{

    public class Customer
    {

        public int Id { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public int Age { get; init; }

        public Customer(int id, string firstName, string lastName, int age)
        {
            //Do validations
            ValidateCustomer(id, firstName, lastName, age);

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        private void ValidateCustomer(int id, string firstName, string lastName, int age)
        {
            //Validations as defined
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("firstname not passed");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("lastName not passed");
            }
            if (age == 0)
            {
                throw new ArgumentException("age not passed");
            }
            if (age <= 18)
            {
                throw new ArgumentException("age 18 or less");
            }
            if (id == 0)
            {
                throw new ArgumentException("no id passed");
            }
        }
    }
}
