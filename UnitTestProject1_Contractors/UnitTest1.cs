using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment_2_Contractors;
using System;

namespace UnitTestProject1_Contractors
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        //1a Test Case
        public void AddContractor()
        {
            var recruitmentSystem = new RecruitmentSystem(3);
            var contractor = new Contractor(3, "Laura", "Sutton", new DateTime(2023, 4, 5), 40, ContractorAssignmentTypes.Available, null, null);

            recruitmentSystem.AddContractor(contractor);

            Assert.IsTrue(recruitmentSystem.GetContractors().Contains(contractor));
        }

        //3a Test Case
        public void AddJob()
        {
            var recruitmentSystem = new RecruitmentSystem(3);
            var job = new Job(3, "Tiling", new DateTime(2023, 12, 20), 1500, JobStatusTypes.Incomplete, JobAssignmentTypes.Unassigned, null, null);

            recruitmentSystem.AddJob(job);

            Assert.IsTrue(recruitmentSystem.GetJobs().Contains(job));
        }

        //8a Test Case
        public void TestMethod1()
        {
            var recruitmentSystem = new RecruitmentSystem(3);
            int minCost = 250;
            int maxCost = 750;

            var filteredJobs = recruitmentSystem.GetJobByCost(minCost, maxCost);

            foreach (var job in filteredJobs)
            {
                Assert.IsTrue(job.JobCost >= minCost && job.JobCost <= maxCost);
            }
        }
    }
}


