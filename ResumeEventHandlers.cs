/*using System;
using System.Windows;
using Resume_Builder_Application;
using ResumeBuilder_Front;
using ResumeBuilderApp;
using Microsoft.Win32;
using System.Windows.Controls;
namespace ResumeBuilderEventHandler
{
    class ResumeEventHandlers
    {
        private ResumeBuilderFront _front;
        private MainWindow _mainWindow;

        //Constructor
        public ResumeEventHandlers(ResumeBuilderFront front, MainWindow mainWindow)
        {
            _front = front;
            _mainWindow = mainWindow;
        }

        //Connect event handlers 
        public void RegisterHandlers()
        {
            _mainWindow.AddSkillButton.Click += AddSkillButton_Click;
            _mainWindow.PreviewButton.Click += PreviewButton_Click;
            _mainWindow.SaveButton.Click += SaveButton_Click;
            _mainWindow.ExportButton.Click += ExportButton_Click;
            _mainWindow.ClearButton.Click += ClearFields;

            // Register TextChanged handlers for text boxes
            _mainWindow.NameBox.TextChanged += UpdatePreview;
            _mainWindow.EmailBox.TextChanged += UpdatePreview;
            _mainWindow.PhoneBox.TextChanged += UpdatePreview;
            _mainWindow.CompanyBox.TextChanged += UpdatePreview;
            _mainWindow.JobTitleBox.TextChanged += UpdatePreview;
            _mainWindow.DurationBox.TextChanged += UpdatePreview;
            _mainWindow.DegreeBox.TextChanged += UpdatePreview;
            _mainWindow.SchoolBox.TextChanged += UpdatePreview;
            _mainWindow.GraduationBox.TextChanged += UpdatePreview;
            _mainWindow.SkillBox.TextChanged += UpdatePreview;

        }

        private void UpdatePreview(object sender, TextChangedEventArgs e)
        {
            // Update the preview only if the corresponding input fields are not null
            if (_mainWindow.NameBox != null)
            {
                _mainWindow.PreviewName.Text = _mainWindow.NameBox.Text ?? string.Empty;
            }

            if (_mainWindow.EmailBox != null && _mainWindow.PhoneBox != null)
            {
                _mainWindow.PreviewContact.Text =
                    $"{_mainWindow.EmailBox.Text ?? string.Empty}, {_mainWindow.PhoneBox.Text ?? string.Empty}";
            }

            // Update Work Experience preview
            if (_mainWindow.CompanyBox != null && _mainWindow.JobTitleBox != null && _mainWindow.DurationBox != null)
            {
                _mainWindow.PreviewWorkExperience.Text =
                    $"{_mainWindow.CompanyBox.Text ?? string.Empty}, {_mainWindow.JobTitleBox.Text ?? string.Empty}, {_mainWindow.DurationBox.Text ?? string.Empty}";
            }

            // Update Education preview
            if (_mainWindow.DegreeBox != null && _mainWindow.SchoolBox != null && _mainWindow.GraduationBox != null)
            {
                _mainWindow.PreviewEducation.Text =
                    $"{_mainWindow.DegreeBox.Text ?? string.Empty}, {_mainWindow.SchoolBox.Text ?? string.Empty}, {_mainWindow.GraduationBox.Text ?? string.Empty}";
            }

            // Update Skills preview
            if (_mainWindow.SkillsList != null)
            {
                var skills = string.Join(", ", _mainWindow.SkillsList.Items);
                _mainWindow.PreviewSkills.Text = skills;
            }
        }


        //Add Skill button click
        public void AddSkillButton_Click(object sender, RoutedEventArgs e)
        {
            // Accessing SkillBox through _mainWindow
            string skill = _mainWindow.SkillBox.Text;
            _front.AddSkill(skill);
        }

        //Preview Button cluck
        public void  PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            _front.Preview();
        }

        //SaveButton Click Event handler
        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _front.SaveToFile();
        }

        public void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            //Open Save Dialog
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "PDF file (*.pdf)|*.pdf";
            saveFileDialog.DefaultExt = "pdf";

            // Show the dialog and get result
            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                string filePath = saveFileDialog.FileName;
                _front.ExportToPDF(filePath);
                MessageBox.Show("Resume exported successfully!");
            }
        }

        //Clear Fields event handler
        public void ClearFields(Object sender, RoutedEventArgs e)
        {
            _front.Clear();
            MessageBox.Show("Fields Cleared Successfully!");
        }
    }
}
*/