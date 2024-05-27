using Service.API;

namespace ServiceTest.FakeItems
{
    internal class MockUserDTO : IuserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        public MockUserDTO(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;

        }
    }
}
