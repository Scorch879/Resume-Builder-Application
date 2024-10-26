using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
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
        }

        private void PopulateFields() //Populate fields from the Textboxes to the ResumeBuilder
        {
            resumeBuilder.Name = NameBox.Text;
            resumeBuilder.Email = EmailBox.Text;
            resumeBuilder.PhoneNumber = PhoneBox.Text;
            resumeBuilder.Company = CompanyBox.Text;
            resumeBuilder.JobTitle = JobTitleBox.Text;
            resumeBuilder.Duration = DurationBox.Text;
            resumeBuilder.Degree = DegreeBox.Text;
            resumeBuilder.School = SchoolBox.Text;
            resumeBuilder.YearOfGraduation = GraduationBox.Text;

            //Clear and re add skills
            resumeBuilder.ClearSkills();
            foreach (string skill in skills)
            {
                resumeBuilder.Skills.Add(skill);
            }
        }

        // Event handler for when a template is selected
        private void TemplateSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TemplateSelector.SelectedItem is ComboBoxItem selectedTemplate)
            {
                ResourceDictionary resourceDict = new ResourceDictionary();

                if (selectedTemplate.Content.ToString() == "Professional Template")
                {
                    resourceDict.Source = new Uri("ProfessionalTemplate.xaml", UriKind.Relative);
                }
                else if (selectedTemplate.Content.ToString() == "Minimalist Template")
                {
                    resourceDict.Source = new Uri("MinimalistTemplate.xaml", UriKind.Relative);
                }

                // Clear existing resources and add the selected template
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
        }

        private void LoadTemplate(string template)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary();

            try
            {
                if (template == "Professional Template")
                {
                    resourceDictionary.Source = new Uri("ProfessionalTemplate.xaml", UriKind.Relative);
                }
                else if (template == "Minimalist Template")
                {
                    resourceDictionary.Source = new Uri("MinimalistTemplate.xaml", UriKind.Relative);
                }

                // Apply the selected template to the current window resources
                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(resourceDictionary);

                MessageBox.Show($"{template} applied successfully!"); // Debugging message
                UpdatePreview(null, null); // Optionally update preview
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load template: {ex.Message}");
            }
        }
        //

        // Button Event Handler Methods

        // Update the preview when text changes
        private void UpdatePreview(object? sender, TextChangedEventArgs? e)
        {
            // Update the resume preview section with the latest data from input fields
            PreviewName.Text = NameBox.Text;
            PreviewContact.Text = $"\nEmail: {EmailBox.Text}\nPhone Number: {PhoneBox.Text}";
            PreviewWorkExperience.Text = $"Company: {CompanyBox.Text}\n{JobTitleBox.Text} ({DurationBox.Text})";
            PreviewEducation.Text = $"Degree: {DegreeBox.Text}\nSchool: {SchoolBox.Text}\nGraduated: {GraduationBox.Text}";
            PreviewSkills.Text = string.Join(", ", skills);
        }

        // Add skill to the skills list and update the preview
        private void AddSkillButtonClick(object sender, RoutedEventArgs e)
        {
            
            string skill = SkillBox.Text.Trim();
            if (!string.IsNullOrEmpty(skill) && !skills.Contains(skill))
            {
                skills.Add(skill);
                SkillsList.Items.Add($"{ctrSkill}. " + skill); // Add the new skill to the UI
                SkillBox.Clear(); // Clear the input box after adding
                ctrSkill++;
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
            ctrSkill = 1;
            // Clear all input fields in the text boxes
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
            SkillsList.Items.Clear(); // Clear the list of skills
            ProfileImage.Source = null; // Clear the profile image
            PreviewImage.Source = null; // Clear the preview image
            UpdatePreview(null, null); // Reset the preview
            resumeBuilder.ClearFields();
            resumeBuilder.ClearSkills();
        }

        // Placeholder for Save button functionality
        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            //Pass the input to the fields in the ResumeBuilder class
            PopulateFields();
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
