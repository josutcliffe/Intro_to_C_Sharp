using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//=========================================
//Name: Joshua Sutcliffe
//Student ID: 20107131
//Email: 20107131@tafe.wa.edu.au
//Cluster - Introductory Programming - C#
//Version: Assignment 2 - Part C
//Date Submitted: 02/12/2023
//=========================================

namespace Assessment_2_Contractors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //initialise RecruitmentSystem to be accessible within MainWindow.xaml.cs
        RecruitmentSystem recruitment = new RecruitmentSystem(20);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_GetContractors_Click(object sender, RoutedEventArgs e)
        {
            ListBox_Contractors.ItemsSource = recruitment.GetContractors();
        }

        private void Button_GetJobs_Click(object sender, RoutedEventArgs e)
        {
            ListBox_Jobs.ItemsSource = recruitment.GetJobs();
        }

        private void RefreshContractorList()
        {
            ListBox_Contractors.ItemsSource = recruitment.GetContractors();
        }

        private void RefreshUnassignedContractorList()
        {
            ListBox_ContractorsUnassigned.ItemsSource = recruitment.GetAvailableContractors();
        }

        private void Button_AddContractor_Click(object sender, RoutedEventArgs e)
        {
            //added validation of firstName to ensure only characters can be input. loops through each individual character and checks if character is a letter.
            string firstName = TextBox_FirstName.Text;
            foreach (char c in firstName)
            {
                if (!char.IsLetter(c))
                {
                    MessageBox.Show("First name should not contain any symbols. Please re-enter first name.");
                    return;
                }
            }
            int id = recruitment.GetContractorCount();  //use the count to make the contractor ID the next number in the count
            Contractor newContractor = new Contractor(id, TextBox_FirstName.Text, TextBox_LastName.Text, (DateTime)DatePicker_Contractor.SelectedDate, (int)Slider_HourlyWage.Value, (ContractorAssignmentTypes)ContractorAssignmentTypes.Available, null, null);
            recruitment.AddContractor(newContractor);


            //Refresh ListBoxes
            RefreshUnassignedContractorList();
            RefreshContractorList();
        }

        private void Slider_HourlyWage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Label_HourlyWageValue == null || Slider_HourlyWage == null) return;

            Label_HourlyWageValue.Content = $"({Slider_HourlyWage.Value})";
        }
        

        private void Button_RemoveContractor_Click(object sender, RoutedEventArgs e)
        {
            
            if (ListBox_Contractors.SelectedItem != null)
            {
                Contractor selectedContractor = (Contractor)ListBox_Contractors.SelectedItem;

                //check through all jobs if the selected contractor is assigned. if assigned, reset the job to unassigned before
                //removing contractor from contractor list
                foreach (Job job in recruitment.GetJobs())
                {
                    if (job.AssignedContractor == selectedContractor)
                    {
                        job.JobAssignmentType = JobAssignmentTypes.Unassigned;
                        job.AssignedContractor = null;
                        job.AssignedContractorName = null;
                    }
                }

                recruitment.RemoveContractor(selectedContractor);
                
            }
            else
            {
                //User warning that no contractor is selected
                MessageBox.Show("No contractor is selected. Please select a contractor then press Remove Contractor.");
            }

            //Refresh ListBoxes
            RefreshUnassignedContractorList();
            RefreshContractorList();
            RefreshUnassignedJobList();
            RefreshJobList();
        }

        private void RefreshJobList()
        {
            ListBox_Jobs.ItemsSource = recruitment.GetJobs();
        }

        private void RefreshUnassignedJobList()
        {
            ListBox_JobsUnassigned.ItemsSource = recruitment.GetUnassignedJobs();
        }

        private void Button_AddJob_Click(object sender, RoutedEventArgs e)
        {

            double jobCost;
            if (double.TryParse(TextBox_JobCost.Text, out jobCost))  //ensure jobCost is entered correctly or it cannot be passed into the newJob
            {
                //validate user input to make sure jobCost is 0 or greater
                if (jobCost < 0)
                {
                    MessageBox.Show("Job cost must be 0 or greater.");
                    return;
                }

                int jobID = recruitment.GetJobCount();  //use the count to make the job ID the next number in the count
                Job newJob = new Job(jobID, TextBox_JobTitle.Text, (DateTime)DatePicker_Job.SelectedDate, jobCost, (JobStatusTypes)JobStatusTypes.Incomplete, (JobAssignmentTypes)JobAssignmentTypes.Unassigned, null, null);
                recruitment.AddJob(newJob);
            }
            else
            {
                //User warning/input validation if job cost is not a number
                MessageBox.Show("Job cost must be a number.");
            }

            //Refresh ListBoxes
            RefreshUnassignedJobList();
            RefreshJobList();
        }

        private void Button_GetUnassignedContractors_Click(object sender, RoutedEventArgs e)
        {
            //if there are no available contractors in list when user clicks button, pop-up message will warn them
            var availableContractors = recruitment.GetAvailableContractors();
            if (availableContractors.Count == 0)
            {
                MessageBox.Show("There are no available contractors.");
                return;
            }

            ListBox_ContractorsUnassigned.ItemsSource = recruitment.GetAvailableContractors();
        }

        private void Button_GetUnassignedJobs_Click(object sender, RoutedEventArgs e)
        {
            //if there are no available contractors in list when user clicks button, pop-up message will warn them
            var unassignedJobs = recruitment.GetUnassignedJobs();
            if (unassignedJobs.Count == 0)
            {
                MessageBox.Show("There are no unassigned jobs.");
                return;
            }

            ListBox_JobsUnassigned.ItemsSource = recruitment.GetUnassignedJobs();
        }

        private void Button_AssignContractor_Click(object sender, RoutedEventArgs e)
        {
            Contractor availableContractor = (Contractor)ListBox_ContractorsUnassigned.SelectedItem;
            Job unassignedJob = (Job)ListBox_JobsUnassigned.SelectedItem;


            //User warning that no contractor is selected
            if (availableContractor == null)
            {
                MessageBox.Show("Please select a contractor.");
                return;
            }

            //User warning that no job is selected
            if (unassignedJob == null)
            {
                MessageBox.Show("Please select a job.");
                return;
            }

            recruitment.AssignJob(availableContractor, unassignedJob);
            
            //Refresh ListBoxes
            RefreshUnassignedContractorList();
            RefreshContractorList();
            RefreshUnassignedJobList();
            RefreshJobList();
        }

        private void Button_CompleteJob_Click(object sender, RoutedEventArgs e)
        {
            Job completedJob = (Job)ListBox_Jobs.SelectedItem;

            if (completedJob != null)
            {
                recruitment.CompleteJob(completedJob);
            }

            //User warning that no job is selected to complete
            if (completedJob == null)
            {
                MessageBox.Show("Please select a job to complete.");
                return;
            }

            //Refresh ListBoxes
            RefreshContractorList();
            RefreshUnassignedContractorList();
            RefreshUnassignedJobList();
            RefreshJobList();
        }

        private void Button_JobByCost_Click(object sender, RoutedEventArgs e)
        {
            //added parsing and warning to check that input for minCost and maxCost is an integer
            int minCost;
            if (!int.TryParse(TextBox_JobMinCost.Text, out minCost))
            {
                MessageBox.Show("Please enter a valid cost for minimum cost.");
                return;
            }
            int maxCost;
            if (!int.TryParse(TextBox_JobMaxCost.Text, out maxCost))
            {
                MessageBox.Show("Please enter a valid cost for maximum cost.");
                return;
            }

            //warn user is minCost is equal to or greater than maxCost
            if (minCost >= maxCost)
            {
                MessageBox.Show("Minimum cost must be less than maximum cost.");
                return;
            }

            List<Job> jobs = recruitment.GetJobByCost(minCost, maxCost);

            //warn user if there are no jobs with cost in the user cost range
            if (jobs.Count == 0)
            {
                MessageBox.Show("There are no jobs in the specified cost range.");
                return;
            }

            ListBox_Jobs.ItemsSource = jobs;
        }
    }
}
