using BigRedRecruitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
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
using System.Xml.Serialization;




namespace BigRedRecruitment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RecruitmentSystem recruitmentSystem = new RecruitmentSystem();


        public MainWindow()
        {
            InitializeComponent();
            ComboBoxContractor.ItemsSource = recruitmentSystem.ContractorsList;
            ComboBoxJob.ItemsSource = recruitmentSystem.JobList;
            AssignJobButton.Content = "Assign Job\nTo Contractor";
        }

        private void ComboBoxContractor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contractor selectedContractor = (Contractor)ComboBoxContractor.SelectedItem;

            if (selectedContractor == null) { return; }
            TextBoxContractor.Text = $"Company ID : {selectedContractor.CompanyID}\r\n" +
                $"First Name : {selectedContractor.FirstName}\r\n" +
                $"Last Name : {selectedContractor.LastName}\r\n" +
                $"Hourly Wage : {selectedContractor.HourlyWage}\r\n" +
                $"Start Date : {selectedContractor.StartDate}\r\n" +
                $"End Date : {selectedContractor.EndDate}\r\n" +
                $"Job Number : {selectedContractor.AssginedJob?.JobId}";
        }

        private void RemoveContractor_Button_Click(object sender, RoutedEventArgs e)
        {
            Contractor selectedContractor = (Contractor)ComboBoxContractor.SelectedItem;
            TextBoxContractor.Text = "Contractor Removed";
            recruitmentSystem.RemoveContractor(selectedContractor);
            RefreshComboBoxContractor();
            RefreshComboBoxJob();   
        }

        private void AvaliableContractors_Click(object sender, RoutedEventArgs e)
        {
            var FreeContractors = new StringBuilder();
            List<Contractor> contractorList = new List<Contractor>();

            foreach (var contractor in recruitmentSystem.GetAvaliableContractors(contractorList))
            {
                FreeContractors.Append(contractor.FirstName + " " + contractor.LastName + "\n");
            }
            TextBoxContractor.Text = FreeContractors.ToString();
        }

        private void AddContractor_Click(object sender, RoutedEventArgs e)
        {
            Contractor newContractor = new Contractor();
            AddContractor op1 = new AddContractor(newContractor);
            op1.ShowDialog();
            recruitmentSystem.AddContractor(newContractor);
            RefreshComboBoxContractor();           
        }
        public void RefreshComboBoxContractor()
        {

            ComboBoxContractor.Items.Refresh();
            TextBoxContractor.Text = "";
        }

        public void RefreshComboBoxJob()
        {
            ComboBoxJob.Items.Refresh();
            TextBoxJob.Text = "";
        }

        private void ComboBoxJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Job selectedJob = (Job)ComboBoxJob.SelectedItem;

            if (selectedJob == null) { return; }
            TextBoxJob.Text = $"Job ID : {selectedJob.JobId}\r\n" +
                $"Job Title : {selectedJob.JobTitle}\r\n" +
                $"Date Open : {selectedJob.DateOpen}\r\n" +
                $"Completed Date : {selectedJob.CompletedDate}\r\n" +
                $"Date Allocated : {selectedJob.DateAllocated}\r\n" +
                $"Job Cost : {selectedJob.Cost}\r\n" +
                $"Contractor Assigned : {selectedJob.ContactorAssigned?.CompanyID}\r\n";
        }

        private void AddJobButton_Click(object sender, RoutedEventArgs e)
        {
            Job newJob = new Job();
            AddNewJob op1 = new AddNewJob(newJob);
            op1.ShowDialog();
            recruitmentSystem.AddJob(newJob);
            RefreshComboBoxJob();
        }

        private void AvaliableJobButton_Click(object sender, RoutedEventArgs e)
        {
            List<Job> jobList = new List<Job>(); 
            var FreeJobs = new StringBuilder();
            foreach (var job in recruitmentSystem.GetAvaliableJobs(jobList))
            {
                FreeJobs.Append(job.JobId + " " + job.JobTitle + "\n");
            }
            TextBoxJob.Text = FreeJobs.ToString();
        }

        public void AssignJobButton_Click(object sender, RoutedEventArgs e)
        {       
            string selectedJobString = ComboBoxJob.SelectedItem?.ToString();
            string selectedContractorString = ComboBoxContractor.SelectedItem?.ToString();

            Contractor selectedContractor = ComboBoxContractor.SelectedItem as Contractor;
            Job selectedJob = ComboBoxJob.SelectedItem as Job;

            int companyId = 0;

            if (selectedContractor != null)
            {
                companyId = selectedContractor.CompanyID;
            }
            if (selectedContractor == null) 
            { 
                MessageBox.Show("Please select a Contractor", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int jobId = 0;

            if (selectedJob != null)
            {
                jobId = selectedJob.JobId;
                
            }
            if (selectedJob == null)
            {
                MessageBox.Show("Please select a Job", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show($"Are you sure you want to add {selectedContractor.FirstName} to {selectedJob.JobTitle} ?", "Assign Job", MessageBoxButton.OKCancel);
            if(result == MessageBoxResult.OK) 
            {
                recruitmentSystem.AssignJob(selectedJob, selectedContractor);
            }
            
            
            RefreshComboBoxContractor();
            RefreshComboBoxJob();

        }

        private void JobCompleteButton_Click(object sender, RoutedEventArgs e)
        {
            Job selectedJob = (Job)ComboBoxJob.SelectedItem;
            recruitmentSystem.CompleteJob(selectedJob);
            RefreshComboBoxJob();
        }

        private void SearchCostButton_Click(object sender, RoutedEventArgs e)
        {
            int maxCost;
            int minCost;

            if (int.TryParse(CostMaxinum.Text, out maxCost))
            {
                CostMaxinum.Text = "";
            }
            else
                {
                    MessageBox.Show("Please enter a Number value.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CostMaxinum.Text = "";
                    return;
                }
            
            if (int.TryParse(CostMinimum.Text, out minCost))
            {
                CostMinimum.Text = "";
            }
            else
                {
                    MessageBox.Show("Please enter a Number value.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CostMinimum.Text = "";
                    return;
                }
            List<Job> jobList = new List<Job>();
            var CostString = new StringBuilder();
            foreach (var job in recruitmentSystem.CostRangeSearch(minCost, maxCost, jobList))
            {
                CostString.Append(job.JobId + " : " + job.JobTitle + " $" + job.Cost + "\n");
            }
            TextBoxJob.Text = CostString.ToString();
            CostMaxinum.Text = "";
            CostMaxinum.Text = "";
        }
       
    }
}

