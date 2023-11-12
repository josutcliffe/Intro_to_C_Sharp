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
//Date Submitted: 12/11/2023
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
        
        ///TODO: add handling for when a contractor assigned to a job is removed, the job should then become unassigned.
        private void Button_RemoveContractor_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox_Contractors.SelectedItem != null)
            {
                Contractor selectedContractor = (Contractor)ListBox_Contractors.SelectedItem;
                recruitment.RemoveContractor(selectedContractor);
            }

            //Refresh ListBoxes
            RefreshUnassignedContractorList();
            RefreshContractorList();
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
            ListBox_ContractorsUnassigned.ItemsSource = recruitment.GetAvailableContractors();
        }

        private void Button_GetUnassignedJobs_Click(object sender, RoutedEventArgs e)
        {
            ListBox_JobsUnassigned.ItemsSource = recruitment.GetUnassignedJobs();
        }

        private void Button_AssignContractor_Click(object sender, RoutedEventArgs e)
        {
            Contractor availableContractor = (Contractor)ListBox_ContractorsUnassigned.SelectedItem;
            Job unassignedJob = (Job)ListBox_JobsUnassigned.SelectedItem;

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

            //Refresh ListBoxes
            RefreshContractorList();
            RefreshUnassignedContractorList();
            RefreshUnassignedJobList();
            RefreshJobList();
        }

        private void Button_JobByCost_Click(object sender, RoutedEventArgs e)
        {
            int minCost = int.Parse(TextBox_JobMinCost.Text);
            int maxCost = int.Parse(TextBox_JobMaxCost.Text);
            List<Job> jobs = recruitment.GetJobByCost(minCost, maxCost);

            ListBox_Jobs.ItemsSource = jobs;
        }
    }
}
