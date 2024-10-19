using System;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
/*using System.Windows.Media.Imaging;

using Resume_Builder_Application;
using ResumeBuilderApp;

namespace ResumeBuilderEventHandler
{
    class ResumeEventHandler
    {
        MainWindow mainWindow = new MainWindow();

        private List<string> skills = new List<string>();

        public ResumeEventHandler()
        {

        }
        // Update the preview when text changes
        private void UpdatePreview(object sender, TextChangedEventArgs e)
        {
            mainWindow.PreviewName.Text = mainWindow.NameBox.Text;
            mainWindow.PreviewContact.Text = $"\nEmail: {mainWindow.EmailBox.Text}" +
                                             $"\nPhone Number: {mainWindow.PhoneBox.Text}";
            mainWindow.PreviewWorkExperience.Text = $"Company: {mainWindow.CompanyBox.Text}\n{mainWindow.JobTitleBox.Text} " +
                                                    $"({mainWindow.DurationBox.Text}) ";
            mainWindow.PreviewEducation.Text = $"Degree: {mainWindow.DegreeBox.Text}\nSchool: {mainWindow.SchoolBox.Text}" +
                                               $"\nGraduated: {mainWindow.GraduationBox.Text}";

            mainWindow.PreviewSkills.Text = string.Join(", ", skills);
        }

        // Add skill to the skills list and update the preview
        private void AddSkillButton_Click(object sender, RoutedEventArgs e)
        {
            string skill = mainWindow.SkillBox.Text.Trim();
            if (!string.IsNullOrEmpty(skill) && !skills.Contains(skill))
            {
                skills.Add(skill);
                mainWindow.SkillsList.Items.Add(skill); // Update UI with the new skill
                mainWindow.SkillBox.Clear(); // Clear input box after adding
                UpdatePreview(null, null); // Update the preview
            }
            else
            {
                MessageBox.Show("Please enter a valid skill or the skill already exists!");
            }
        }

        // Clear all fields and reset the preview
        private void ClearFields(object sender, RoutedEventArgs e)
        {
            mainWindow.NameBox.Clear();
            mainWindow.EmailBox.Clear();
            mainWindow.PhoneBox.Clear();
            mainWindow.CompanyBox.Clear();
            mainWindow.JobTitleBox.Clear();
            mainWindow.DurationBox.Clear();
            mainWindow.DegreeBox.Clear();
            mainWindow.SchoolBox.Clear();
            mainWindow.GraduationBox.Clear();
            mainWindow.SkillBox.Clear();
            mainWindow.skills.Clear();
            mainWindow.SkillsList.Items.Clear(); // Clear the skills list
            UpdatePreview(null, null); // Reset the preview
        }

        // Placeholder for Save button functionality
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save functionality is not implemented yet.");
        }

        // Placeholder for Export to PDF button functionality
        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Export functionality is not implemented yet.");
        }

        // Placeholder for Preview button functionality
        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Preview functionality is not implemented yet.");
        }

        private void UploadImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an OpenFileDialog to select an image file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select a Profile Picture"
            };

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == true)
            {
                // Load the selected image
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));

                // Set the image source to the ProfileImage control
                mainWindow.ProfileImage.Source = bitmap;

                // Optionally, also set the PreviewImage in the resume preview section
                mainWindow.PreviewImage.Source = bitmap;
            }
        }
    }
}*/