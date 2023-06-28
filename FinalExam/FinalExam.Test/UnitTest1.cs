using FinalExam.DB;
using FinalExam.DLL;

namespace FinalExam.Test
{
    public class UnitTest1
    {
        [Fact]
        public void IsAnyWorker()
        {
            var fedq = new FinalExamDataDbQuerry();
            int ls = fedq.AllOfWorkers().Count();
            Assert.NotEqual(0, ls);
        }

        [Fact]
        public void IsAnyRepairType()
        {
            var fedq = new FinalExamDataDbQuerry();
            int ls = fedq.AllOfRepairType().Count();
            Assert.True(ls > 0);
        }

        [Fact]
        public void IsWorkerWithOneId()
        {
            // Assert.NotEqual(null, new FinalExamDataDbQuerry().GetWorker(1));
            Assert.NotNull(new FinalExamDataDbQuerry().GetWorker(1));
        }

        [Fact]
        public void CheckRepairTypeDescription()
        {
            var fedq = new FinalExamDataDbQuerry();
            RepairType rt = fedq.GetRepairType(1);
            Assert.Equal("Izzócsere", rt.Description);
        }
    }
}