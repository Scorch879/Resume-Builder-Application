using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace ResumeBuilderApp
{
    public class ResumeBuilder
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;
        public string School { get; set; } = string.Empty;
        public string YearOfGraduation { get; set; } = string.Empty;

        public List<string> Skills { get; private set; } = new List<string>();

        public void AddSkill(string skill)
        {
            if (!string.IsNullOrWhiteSpace(skill))
                Skills.Add(skill);
        }

        public void ClearSkills() => Skills.Clear();

        public void SaveToFile()
        {
            if (!IsValid(out string validationMessage))
            {
                MessageBox.Show("Validation Errors:\n" + validationMessage);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text File (*.txt)|*.txt|PDF File (*.pdf)|*.pdf",
                FileName = "Resume"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    if (Path.GetExtension(filePath).ToLower() == ".txt")
                        SaveAsTextFile(filePath);
                    else if (Path.GetExtension(filePath).ToLower() == ".pdf")
                        ExportToPDF(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving the resume: {ex.Message}");
                }
            }
        }

        private void SaveAsTextFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Name: {Name}");
                writer.WriteLine($"Email: {Email}");
                writer.WriteLine($"Phone Number: {PhoneNumber}");
                writer.WriteLine("Work Experience:");
                writer.WriteLine($"Company: {Company}");
                writer.WriteLine($"Job Title: {JobTitle}");
                writer.WriteLine($"Duration: {Duration}");
                writer.WriteLine("Education:");
                writer.WriteLine($"Degree: {Degree}");
                writer.WriteLine($"School: {School}");
                writer.WriteLine($"Year of Graduation: {YearOfGraduation}");

                writer.WriteLine("Skills:");
                foreach (var skill in Skills)
                {
                    writer.WriteLine($"- {skill}");
                }
            }
        }

        private void ExportToPDF(string pdfFilePath)
        {
            using (PdfWriter writer = new PdfWriter(pdfFilePath))
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                Document document = new Document(pdf);
                document.Add(new Paragraph($"Name: {Name}"));
                document.Add(new Paragraph($"Email: {Email}"));
                document.Add(new Paragraph($"Phone Number: {PhoneNumber}"));
                document.Add(new Paragraph("Work Experience:"));
                document.Add(new Paragraph($"Company: {Company}"));
                document.Add(new Paragraph($"Job Title: {JobTitle}"));
                document.Add(new Paragraph($"Duration: {Duration}"));
                document.Add(new Paragraph("Education:"));
                document.Add(new Paragraph($"Degree: {Degree}"));
                document.Add(new Paragraph($"School: {School}"));
                document.Add(new Paragraph($"Year of Graduation: {YearOfGraduation}"));
                document.Add(new Paragraph("Skills:"));
                foreach (var skill in Skills)
                    document.Add(new Paragraph($"- {skill}"));
            }
        }

        public void ClearFields()
        {
            Name = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Company = string.Empty;
            JobTitle = string.Empty;
            Duration = string.Empty;
            Degree = string.Empty;
            School = string.Empty;
            YearOfGraduation = string.Empty;
            ClearSkills();
        }

        private bool IsValid(out string errorMessage)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Name)) 
                errors.AppendLine("Name is required.");
            if (string.IsNullOrWhiteSpace(Email)) 
                errors.AppendLine("Email is required.");
            if (string.IsNullOrWhiteSpace(PhoneNumber)) 
                errors.AppendLine("Phone number is required.");
            if (string.IsNullOrWhiteSpace(Company)) 
                errors.AppendLine("Company name is required.");
            if (string.IsNullOrWhiteSpace(JobTitle)) 
                errors.AppendLine("Job title is required.");
            if (string.IsNullOrWhiteSpace(Duration)) 
                errors.AppendLine("Duration is required.");
            if (string.IsNullOrWhiteSpace(Degree)) 
                errors.AppendLine("Degree is required.");
            if (string.IsNullOrWhiteSpace(School)) 
                errors.AppendLine("School name is required.");
            if (string.IsNullOrWhiteSpace(YearOfGraduation)) 
                errors.AppendLine("Year of graduation is required.");
            if (Skills.Count == 0) 
                errors.AppendLine("At least one skill is required.");

            errorMessage = errors.ToString();

            return errors.Length == 0;
        }
    }
}
