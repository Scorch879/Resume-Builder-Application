/*using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Resume_Builder_Application
{
    public partial class ResumeBuilderFront : Window
    {
        // A list to hold added skills
        private List<string> skills = new List<string>();

        public ResumeBuilderFront()
        {
            InitializeComponent();
        }

        // Update the resume preview based on the user's input
        private void UpdatePreview(object sender, TextChangedEventArgs e)
        {
            PreviewName.Text = NameBox.Text;
            PreviewContact.Text = $"{EmailBox.Text} | {PhoneBox.Text}";
            PreviewWorkExperience.Text = $"{JobTitleBox.Text} at {CompanyBox.Text} ({DurationBox.Text})";
            PreviewEducation.Text = $"{DegreeBox.Text} from {SchoolBox.Text}, {GraduationBox.Text}";
            PreviewSkills.Text = string.Join(", ", skills);
        }

        // Add skill to the skills list and update the preview
        private void AddSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SkillBox.Text))
            {
                skills.Add(SkillBox.Text);
                SkillBox.Clear(); // Clear input after adding
                UpdatePreview(null, null); // Update preview to reflect new skill

                // Display added skills in the SkillsList
                SkillsList.ItemsSource = null; // Reset the source
                SkillsList.ItemsSource = skills; // Update the source
            }
            else
            {
                MessageBox.Show("Please enter a skill.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Preview button click handler
        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            // This can be expanded to show a more detailed preview if necessary
            MessageBox.Show("Preview updated!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Save button click handler
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement save functionality (e.g., saving to a file)
            MessageBox.Show("Resume saved successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Export to PDF button click handler
        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement export functionality to PDF
            MessageBox.Show("Resume exported to PDF successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Clear fields button click handler
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
            skills.Clear(); // Clear skills list
            SkillsList.ItemsSource = null; // Clear the displayed skills
            UpdatePreview(null, null); // Clear preview
        }
    }
}
*/