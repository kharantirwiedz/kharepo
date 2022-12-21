using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using EFC_models.Models;
using System.Collections.ObjectModel;

namespace EFC_on_WPF
{

    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> ListEmployees = new ObservableCollection<Employee> { };
        ObservableCollection<Department> ListDepartments = new ObservableCollection<Department> { };
        ObservableCollection<Profession> ListProfessions = new ObservableCollection<Profession> { };

        public MainWindow()
        {

            using (TestingDbContext db = new TestingDbContext())
            {
                ListEmployees = new ObservableCollection<Employee>(db.Employees);
                ListDepartments = new ObservableCollection<Department>(db.Departments);
                ListProfessions = new ObservableCollection<Profession>(db.Professions);
            }

            InitializeComponent();

            Employees_View.ItemsSource = ListEmployees;
            Departments_View.ItemsSource = ListDepartments;
            Professions_View.ItemsSource = ListProfessions;
        }

        private void Employee_Add_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee new_employee = new Employee
                {
                    Name = Employee_Name_box.Text,
                    LastName = Employee_LastName_box.Text,
                    DepartmentId = Convert.ToInt32(Employee_DepartmentId_box.Text),
                    ProfessionId = Convert.ToInt32(Employee_ProfessionId_box.Text),
                    ManagerId = Convert.ToInt32(Employee_ManagerId_box.Text),
                    Salary = Convert.ToInt32(Employee_Salary_box.Text)
                };
                using (TestingDbContext tdb_context = new TestingDbContext())
                {
                    tdb_context.Add(new_employee);
                    tdb_context.SaveChanges();
                    ListEmployees = new ObservableCollection<Employee>(tdb_context.Employees);
                    Employees_View.ItemsSource = ListEmployees;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Employee_Edit_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using (TestingDbContext tdb_context = new TestingDbContext())
                {
                    Employee found_employee = tdb_context.Employees.Find(Convert.ToInt32(Employee_Id_box.Text));

                    if (found_employee != null)
                    {
                        found_employee.Name = Name = Employee_Name_box.Text;
                        found_employee.LastName = Employee_LastName_box.Text;
                        found_employee.DepartmentId = Convert.ToInt32(Employee_DepartmentId_box.Text);
                        found_employee.ProfessionId = Convert.ToInt32(Employee_ProfessionId_box.Text);
                        found_employee.ManagerId = Convert.ToInt32(Employee_ManagerId_box.Text);
                        found_employee.Salary = Convert.ToInt32(Employee_Salary_box.Text);
                        ListEmployees = new ObservableCollection<Employee>(tdb_context.Employees);
                        Employees_View.ItemsSource = ListEmployees;
                        tdb_context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Couldn't find an entity with that Id!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Employee_Delete_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using (TestingDbContext tdb_context = new TestingDbContext())
                {
                    tdb_context.Entry(new Employee() { Id = Convert.ToInt32(Employee_Id_box.Text)}).State=EntityState.Deleted;
                    tdb_context.SaveChanges();
                    ListEmployees = new ObservableCollection<Employee>(tdb_context.Employees);
                    Employees_View.ItemsSource = ListEmployees;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Department_Add_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Department new_department = new Department() {Name = Department_Name_box.Text};
                using (TestingDbContext tdb_context = new TestingDbContext())
                {
                    tdb_context.Add(new_department);
                    tdb_context.SaveChanges();
                    ListDepartments = new ObservableCollection<Department>(tdb_context.Departments);
                    Departments_View.ItemsSource = ListDepartments;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Department_Edit_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using (TestingDbContext tdb_context = new TestingDbContext())
                {
                    Department found_department = tdb_context.Departments.Find(Convert.ToInt32(Department_Id_box.Text));

                    if (found_department != null)
                    {
                        found_department.Name = Department_Name_box.Text;
                        ListDepartments = new ObservableCollection<Department>(tdb_context.Departments);
                        Departments_View.ItemsSource = ListDepartments;
                        tdb_context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Couldn't find an entity with that Id!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Department_Delete_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using (TestingDbContext tdb_context = new TestingDbContext())
                {
                    tdb_context.Entry(new Department() { Id = Convert.ToInt32(Department_Id_box.Text) }).State = EntityState.Deleted;
                    tdb_context.SaveChanges();
                    ListDepartments = new ObservableCollection<Department>(tdb_context.Departments);
                    Departments_View.ItemsSource = ListDepartments;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Profession_Add_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Profession new_profession = new Profession() { Name = Profession_Name_box.Text };
                using (TestingDbContext tdb_context = new TestingDbContext())
                {
                    tdb_context.Add(new_profession);
                    tdb_context.SaveChanges();
                    ListProfessions = new ObservableCollection<Profession>(tdb_context.Professions);
                    Professions_View.ItemsSource = ListProfessions;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Profession_Edit_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using (TestingDbContext tdb_context = new TestingDbContext())
                {
                    Profession found_profession = tdb_context.Professions.Find(Convert.ToInt32(Profession_Id_box.Text));

                    if (found_profession != null)
                    {
                        found_profession.Name = Profession_Name_box.Text;
                        ListProfessions = new ObservableCollection<Profession>(tdb_context.Professions);
                        Professions_View.ItemsSource = ListProfessions;
                        tdb_context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Couldn't find an entity with that Id!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Profession_Delete_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using (TestingDbContext tdb_context = new TestingDbContext())
                {
                    tdb_context.Entry(new Profession() { Id = Convert.ToInt32(Profession_Id_box.Text) }).State = EntityState.Deleted;
                    tdb_context.SaveChanges();
                    ListProfessions = new ObservableCollection<Profession>(tdb_context.Professions);
                    Professions_View.ItemsSource = ListProfessions;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

