using DataAccess.DTO;

namespace TestOk.Models
{
    public class TestModel
    {
        public TestDto Test { get; set; }

        public TestModel()
        {
            Test = new TestDto();
        }
    }
}
