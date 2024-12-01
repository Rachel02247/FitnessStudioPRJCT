namespace FitnessProject.Entities
{

    public class GymnastEntity
    {
        public uint Id { get; set; }
        public string TZ { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public uint IdCourse { get; set; }

        public GymnastEntity()
        {

        }

        public GymnastEntity(uint id,string tz, string firstName, string lastName, DateTime dateOfBirth,
            string phoneNumber, string email, Address address, uint idCourse)
        {
            Id = id;
            TZ = tz;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            IdCourse = idCourse;
        }
    }
}
