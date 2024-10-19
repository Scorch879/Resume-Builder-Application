using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ResumeBuilderApp;
using Microsoft.Win32; // Add this using directive
using System.Windows.Media.Imaging; // For BitmapImage

namespace Resume_Builder_Application
{
    public partial class MainWindow : Window
    {
        private List<string> skills = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Update the preview when text changes
        private void UpdatePreview(object sender, TextChangedEventArgs e)
        {
            PreviewName.Text = NameBox.Text;
            PreviewContact.Text = $"\nEmail: {EmailBox.Text}\nPhone Number: {PhoneBox.Text}";
            PreviewWorkExperience.Text = $"Company: {CompanyBox.Text}\n{JobTitleBox.Text} ({DurationBox.Text}) ";
            PreviewEducation.Text = $"Degree: {DegreeBox.Text}\nSchool: {SchoolBox.Text}\nGraduated: {GraduationBox.Text}";
            PreviewSkills.Text = string.Join(", ", skills);
        }

        // Add skill to the skills list and update the preview
        private void AddSkillButton_Click(object sender, RoutedEventArgs e)
        {
            string skill = SkillBox.Text.Trim();
            if (!string.IsNullOrEmpty(skill) && !skills.Contains(skill))
            {
                skills.Add(skill);
                SkillsList.Items.Add(skill); // Update UI with the new skill
                SkillBox.Clear(); // Clear input box after adding
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
            NameBox.Clear();
            EmailBox.Clear();
            PhoneBox.Clear();
            CompanyBox.Clear();
            JobTitleBox.Clear();
            DurationBox.Clear();
            DegreeBox.Clear();
            SchoolBox.Clear();
            GraduationBox.Clear();
            SkillBox.Clear();
            skills.Clear();
            SkillsList.Items.Clear(); // Clear the skills list
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
                ProfileImage.Source = bitmap;

                // Optionally, also set the PreviewImage in the resume preview section
                PreviewImage.Source = bitmap;
            }
        }
    }
}
