using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    /// Interaction logic for AddContractor.xaml
    /// </summary>
    public partial class AddContractor : Window
    {

        Contractor Contractor;

        public AddContractor(Contractor newContractor)
        {
            InitializeComponent();
            Contractor = newContractor;
            
        }

        public void AddContractor_Button_Click(object sender, RoutedEventArgs e)
        {
            RecruitmentSystem recruitmentSystem = new RecruitmentSystem();
            int CompanyID = recruitmentSystem.GetNewCompanyID();

            if (!int.TryParse(AddFirstName.Text, out _))
            {
                Contractor.FirstName = AddFirstName.Text;
            }
            else
            {
                MessageBox.Show("Please enter a alphabetic character", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                AddFirstName.Text = "";
                return;
            }
            if (!int.TryParse(AddLastName.Text, out _))
            {
                Contractor.LastName = AddLastName.Text;
            }
            else
            {
                MessageBox.Show("Please enter a alphabetic character", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                AddLastName.Text = "";
                return;
            }
            if (int.TryParse(AddHourlyRate.Text, out _))
            {
                Contractor.HourlyWage = int.Parse(AddHourlyRate.Text);
            }
            else
            {
                MessageBox.Show("Please enter a numerical character", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                AddHourlyRate.Text = "";
                return;
            }
            Contractor.CompanyID = CompanyID;
            Contractor.StartDate = null;
            Contractor.EndDate = null;
            Contractor.AssginedJob = null;
            Contractor.SetStartDate();           
            DialogResult = true;
            Close();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            AddFirstName.Text = null;
            AddLastName.Text = null;
            AddHourlyRate.Text = null;

        }
        

    }
    }
