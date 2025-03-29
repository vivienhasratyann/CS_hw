using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;

namespace WPFDataStorageApp
{
    public partial class MainWindow : Window
    {
        struct Person
        {
            public int Id;
            public string Name;
            public int Age;
            public string Address;
        }

        private List<Person> people = new List<Person>();
        private int idCounter = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.TextBox textBox)
            {
                if (textBox.Text == "Enter Name" || textBox.Text == "Enter Age" || textBox.Text == "Enter Address")
                {
                    textBox.Text = "";
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "txtName") textBox.Text = "Enter Name";
                else if (textBox.Name == "txtAge") textBox.Text = "Enter Age";
                else if (textBox.Name == "txtAddress") textBox.Text = "Enter Address";
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtAge.Text, out int age) && !string.IsNullOrWhiteSpace(txtName.Text) && txtName.Text != "Enter Name")
            {
                people.Add(new Person { Id = idCounter++, Name = txtName.Text, Age = age, Address = txtAddress.Text });
                MessageBox.Show("Person Added!");
            }
            else
            {
                MessageBox.Show("Invalid Name or Age!");
            }
        }

        private void BtnDisplay_Click(object sender, RoutedEventArgs e)
        {
            lstDisplay.Items.Clear();
            foreach (var p in people)
            {
                lstDisplay.Items.Add($"{p.Id}. {p.Name}, Age: {p.Age}, {p.Address}");
            }
        }

        private void BtnSortByAge_Click(object sender, RoutedEventArgs e)
        {
            people = people.OrderBy(p => p.Age).ToList();
            BtnDisplay_Click(sender, e);
        }

        private void BtnSortByName_Click(object sender, RoutedEventArgs e)
        {
            people = people.OrderBy(p => p.Name).ToList();
            BtnDisplay_Click(sender, e);
        }

        private void BtnSearchByAge_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtAge.Text, out int age))
            {
                var found = people.Where(p => p.Age == age).ToList();
                lstDisplay.Items.Clear();
                foreach (var p in found)
                {
                    lstDisplay.Items.Add($"{p.Id}. {p.Name}, Age: {p.Age}, {p.Address}");
                }
                if (found.Count == 0) MessageBox.Show("No match found.");
            }
            else
            {
                MessageBox.Show("Enter a valid age.");
            }
        }

        private void BtnSearchByName_Click(object sender, RoutedEventArgs e)
        {
            var found = people.Where(p => p.Name.Equals(txtName.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            lstDisplay.Items.Clear();
            foreach (var p in found)
            {
                lstDisplay.Items.Add($"{p.Id}. {p.Name}, Age: {p.Age}, {p.Address}");
            }
            if (found.Count == 0) MessageBox.Show("No match found.");
        }

        private void BtnRemoveByName_Click(object sender, RoutedEventArgs e)
        {
            int initialCount = people.Count;
            people = people.Where(p => !p.Name.Equals(txtName.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            if (people.Count < initialCount)
            {
                MessageBox.Show("Person removed.");
                BtnDisplay_Click(sender, e);
            }
            else
            {
                MessageBox.Show("No match found.");
            }
        }

        private void BtnRemoveByAge_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtAge.Text, out int age))
            {
                int initialCount = people.Count;
                people = people.Where(p => p.Age != age).ToList();
                if (people.Count < initialCount)
                {
                    MessageBox.Show("Persons removed.");
                    BtnDisplay_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("No match found.");
                }
            }
            else
            {
                MessageBox.Show("Enter a valid age.");
            }
        }
    }
}
