using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace BigRedRecruitment
{
    /// <summary>
    /// Interaction logic for AddNewJob.xaml
    /// </summary>
    public partial class AddNewJob : Window


    {
        Job Job;
        public AddNewJob(Job newJob)
        {
            InitializeComponent();
            Job = newJob;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            AddCost.Text = null;
            AddJobTitle.Text = null;
        }
        
        private void AddJob_Button_Click(object sender, RoutedEventArgs e)

        {
            RecruitmentSystem recruitmentSystem = new RecruitmentSystem();
            int newJobId = recruitmentSystem.GetNewJobID();

            if (!int.TryParse(AddJobTitle.Text, out _))
            {
                Job.JobTitle = AddJobTitle.Text;
            }
            else
            {
                MessageBox.Show("Please enter a alphabetic character", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                AddJobTitle.Text = "";
                return;
            }
            Job.JobId = newJobId;
            Job.DateOpen = null;
            Job.CompletedDate = null;
            Job.DateAllocated = null;
            if (int.TryParse(AddCost.Text, out _))
            {
                Job.Cost = int.Parse(AddCost.Text);
            }
            else
            {
                MessageBox.Show("Please enter a numerical character", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                AddCost.Text = "";
                return;
            }          
            Job.ContactorAssigned = null;
            Job.SetDateOpen();
            DialogResult = true;
            Close();
        }
    }
}
