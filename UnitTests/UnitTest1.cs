using API.Controllers;
using API.Data;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        private readonly DataContext _context;

        public Tests(DataContext context)
        {
            _context = context;
        }
        
        [SetUp]
        public void Setup()
        {
            var controller = new TodoController(_context);
        }

        [Test]
        public void GetAllTodosReturnsOk()
        {
            
        }
    }
}