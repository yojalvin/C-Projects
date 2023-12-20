using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace StudentRegistrationDB
{
    
    public partial class MainWindow : Window
    {

        private ObservableCollection<Student> Students { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>();
            studentDataGrid.ItemsSource = Students;
            
        }

        public class Student
        {
            public int StudentID { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public string Program { get; set; }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information System",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            for (int i = 0; i < 6; i++)
            {
                cbProgram.Items.Add(ListOfProgram[i].ToString());
            }

            string[] ListOfGender = new string[]
            {
                "Male",
                "Female",
                "Rather not say"
            };
            for (int g = 0; g < 3; g++)
            {
                cbGender.Items.Add(ListOfGender[g].ToString());
            }
        }

        private void regiterBtn_Click(object sender, RoutedEventArgs e)
        {
            Student newStudent = new Student
            {
                StudentID = int.Parse(txtStudentNo.Text),
                LastName = txtLastName.Text,
                Age = int.Parse(txtAge.Text),
                FirstName = txtFirstName.Text,
                Gender = cbGender.Text,
                Program = cbProgram.Text,
                MiddleName = txtMiddleName.Text
            };

            Students.Add(newStudent);

            // Clear input fields after adding a student
            ClearInputFields();
        }

        private void ClearInputFields()
        {
            txtStudentNo.Clear();
            txtLastName.Clear();
            txtAge.Clear();
            txtFirstName.Clear();
            cbGender.SelectedItem = null;
            cbProgram.SelectedItem = null;
            txtMiddleName.Clear();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void studentDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (studentDataGrid.SelectedItem != null && studentDataGrid.SelectedItems.Count > 0)
            {
                // Enable the "Update" button
                updateBtn.IsEnabled = true;
            }
            else
            {
                // If no row is selected, disable the "Update" button
                updateBtn.IsEnabled = false;
            }
        }
    }
}
