using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment_2_Contractors;
using System;


//=========================================
//Name: Joshua Sutcliffe
//Student ID: 20107131
//Email: 20107131@tafe.wa.edu.au
//Cluster - Introductory Programming - C#
//Version: Assignment 2 - Part C
//Date Submitted: 02/12/2023
//=========================================


namespace UnitTestProject1_Contractors
{
    [TestClass]
    public class UnitTest1
    {

        public static void Main(string[] args)
        {
        }

        [TestMethod]

        //1a Test Case - Add contractor with all required data to contractor list
        public void AddContractor1A()
        {
            var recruitmentSystem = new RecruitmentSystem(3);
            var contractor = new Contractor(3, "Laura", "Sutton", new DateTime(2023, 4, 5), 40, ContractorAssignmentTypes.Available, null, null);

            recruitmentSystem.AddContractor(contractor);

            Assert.IsTrue(recruitmentSystem.GetContractors().Contains(contractor));
        }

        
        [TestMethod]

        //2a Test Case - Remove contractor from contractor list
        public void RemoveContractor2A()
        {
            var recruitmentSystem = new RecruitmentSystem(3);
            var contractor = new Contractor(3, "Laura", "Sutton", new DateTime(2023, 4, 5), 40, ContractorAssignmentTypes.Available, null, null);

            recruitmentSystem.RemoveContractor(contractor);

            Assert.IsFalse(recruitmentSystem.GetContractors().Contains(contractor));
        }

        [TestMethod]
        //3a Test Case - Add job to with all required data to job list
        public void CreateJob3A()
        {
            var recruitmentSystem = new RecruitmentSystem(3);
            var job = new Job(3, "Tiling", new DateTime(2023, 12, 20), 1500, JobStatusTypes.Incomplete, JobAssignmentTypes.Unassigned, null, null);

            recruitmentSystem.AddJob(job);

            Assert.IsTrue(recruitmentSystem.GetJobs().Contains(job));
        }

        [TestMethod]
        //4a Test Case - Assign contractor (name) from contractor list to a specific job from job list
        public void AssignContractor4A()
        {
            var recruitmentSystem = new RecruitmentSystem(3);
            var contractor = new Contractor(3, "Laura", "Sutton", new DateTime(2023, 4, 5), 40, ContractorAssignmentTypes.Available, null, null);
            var job = new Job(3, "Tiling", new DateTime(2023, 12, 20), 1500, JobStatusTypes.Incomplete, JobAssignmentTypes.Unassigned, null, null);

            recruitmentSystem.AssignJob(contractor, job);

            Assert.AreEqual(contractor, job.AssignedContractor);
            Assert.AreEqual(contractor.FirstName + " " + contractor.LastName, job.AssignedContractorName);
        }

        [TestMethod]
        //5a Test Case - Complete job, removing job from job list. Must return the assigned contractor back to available contractor pool
        public void CompleteJob5A()
        {
            var recruitmentSystem = new RecruitmentSystem(3);
            var contractor = new Contractor(3, "Laura", "Sutton", new DateTime(2023, 4, 5), 40, ContractorAssignmentTypes.Available, null, null);
            var job = new Job(3, "Tiling", new DateTime(2023, 12, 20), 1500, JobStatusTypes.Incomplete, JobAssignmentTypes.Unassigned, null, null);
            recruitmentSystem.AssignJob(contractor, job);

            recruitmentSystem.CompleteJob(job);

            Assert.IsFalse(recruitmentSystem.jobList.Contains(job));
        }

        [TestMethod]
        //6a Test Case - List all contractors that are available (Unassigned)
        public void ViewAvailableContractors6A()
        {
            var recruitmentSystem = new RecruitmentSystem(3);
            var contractor = new Contractor(3, "Laura", "Sutton", new DateTime(2023, 4, 5), 40, ContractorAssignmentTypes.Available, null, null);
            var job = new Job(3, "Tiling", new DateTime(2023, 12, 20), 1500, JobStatusTypes.Incomplete, JobAssignmentTypes.Unassigned, null, null);
            recruitmentSystem.AssignJob(contractor, job);

            var availableContractors = recruitmentSystem.GetAvailableContractors();

            Assert.IsFalse(availableContractors.Contains(contractor));
        }

        [TestMethod]
        //7a Test Case - List all jobs that do not have a contractor assigned to it
        public void ViewUnassignedJobs7A()
        {
            var recruitmentSystem = new RecruitmentSystem(3);
            var job = new Job(3, "Tiling", new DateTime(2023, 12, 20), 1500, JobStatusTypes.Incomplete, JobAssignmentTypes.Unassigned, null, null);

            var unassignedJobs = recruitmentSystem.GetUnassignedJobs();

            Assert.IsFalse(unassignedJobs.Contains(job));
        }

        [TestMethod]
        //8a Test Case - Input a minimum and maximum cost and only show jobs that have a cost within the range
        public void SearchJobsByCost8A()
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


