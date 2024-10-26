using System;
using System.Windows;
using System.Windows.Controls;
using ResumeBuilderApp;

namespace Resume_Builder_Application
{
    public partial class ResumeMainWindow : Window
    {
        private int ctrSkill= 1;
        private ResumeBuilder resumeBuilder = new ResumeBuilder();
        private List<string> skills = new List<string>();
        private string? selectedTemplate; // Initialize this globally

        public ResumeMainWindow()
        {
            InitializeComponent();
            resumeBuilder = new ResumeBuilder();
            DataContext = resumeBuilder;
        }

        // Button Event Handler Methods
        // Update the preview when text changes
        private void UpdatePreview(object? sender, TextChangedEventArgs? e)
        {
            // Update the resume preview section with the latest data from resumeBuilder properties
            PreviewName.Text = resumeBuilder.Name;  // Use properties instead of TextBoxes
            PreviewContact.Text = $"\nEmail: {resumeBuilder.Email}\nPhone Number: {resumeBuilder.PhoneNumber}";
            PreviewWorkExperience.Text = $"Company: {resumeBuilder.Company}\n{resumeBuilder.JobTitle} ({resumeBuilder.Duration})";
            PreviewEducation.Text = $"Degree: {resumeBuilder.Degree}\nSchool: {resumeBuilder.School}\nGraduated: {resumeBuilder.YearOfGraduation}";
            PreviewSkills.Text = string.Join(", ", resumeBuilder.Skills);
        }

        // Add skill to the skills list and update the preview
        private void AddSkillButtonClick(object sender, RoutedEventArgs e)
        {
            
            string skill = SkillBox.Text.Trim();
            if (!string.IsNullOrEmpty(skill) && !resumeBuilder.Skills.Contains(skill))
            {
                resumeBuilder.AddSkill(skill); // Add the skill to the collection
                SkillBox.Clear(); // Clear the input box
                UpdatePreview(null, null); // Update preview 
            }
            else
            {
                MessageBox.Show("Please enter a valid skill or the skill already exists!");
            }
        }

        // Clear all fields and reset the preview
        private void ClearFields(object sender, RoutedEventArgs e)
        {
            ctrSkill = 1;

            // Clear all input fields in the text boxes (frontend)
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

            // Clear the skills list and the UI element displaying skills
            skills.Clear();

            // Clear the profile images
            ProfileImage.Source = null;
            PreviewImage.Source = null;

            // Clear fields in the ResumeBuilder instance
            resumeBuilder.ClearFields();

            // Reset the preview to reflect the cleared fields
            UpdatePreview(null, null);
        }

        // Placeholder for Save button functionality
        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            //Pass the input to the fields in the ResumeBuilder class
            UpdatePreview(null, null);
           // PopulateFields();
            //Call the function for SaveToFile Method
            resumeBuilder.SaveToFile();
        }
        
        // Placeholder for Preview button functionality
        private void PreviewButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Preview functionality is not implemented yet.");
        }

        // Upload and display the profile picture
        private void UploadImageButtonClick(object sender, RoutedEventArgs e)
        {
            resumeBuilder.UploadImage();

            // Set the ProfileImage control and the PreviewImage to display the uploaded image
            if (resumeBuilder.ProfileImage != null)
            {
                ProfileImage.Source = resumeBuilder.ProfileImage;
                PreviewImage.Source = resumeBuilder.ProfileImage;
            }
        }
    }
}
