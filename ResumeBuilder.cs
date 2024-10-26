using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Windows.Media.Imaging;
using iText.IO.Image;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ResumeBuilderApp
{
    public class ResumeInfo : INotifyPropertyChanged
    {
        private string? name, email, phoneNumber, company, jobTitle; 
        private string? duration, degree, school, yearOfGraduation, imagePath;
        private ObservableCollection<string> skills;
        private BitmapImage? profileImage;
        public event PropertyChangedEventHandler? PropertyChanged;

        //Each property calls OnPropertyChanged in its setter, notifying the UI of changes.
        public string? Name 
        {   
            get => this.name;
            set
            {
                if (name!= value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        } 

        public string? Email 
        { 
            get => this.email;
            set
            {
                if (email != value)
                {
                    email = value; 
                    OnPropertyChanged(nameof(Email));
                }
            }
        } 

        public string? PhoneNumber 
        { 
            get => this.phoneNumber;
            set
            {
                if (this.phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        } 

        public string? Company 
        { 
            get => this.company;
            set
            {
                if (this.company != value)
                {
                    company = value;
                    OnPropertyChanged(nameof(Company));
                }
            }
        } 

        public string? JobTitle 
        { 
            get => this.jobTitle;
            set
            {
                if (this.jobTitle != value)
                {
                    jobTitle = value;
                    OnPropertyChanged(nameof(JobTitle));
                }
            }
        } 

        public string? Duration 
        { 
            get => this.duration;
            set
            {
                if (this.duration != value)
                {
                    duration = value;
                    OnPropertyChanged(nameof(Duration));
                }
            }
        } 

        public string? Degree 
        { 
            get => this.degree;
            set
            {
                if (this.degree != value)
                {
                    degree = value;
                    OnPropertyChanged(nameof(Degree));
                }
            }
        }

        public string? School
        {
            get => this.school;
            set
            {
                if (this.school != value)
                {
                    school = value;
                    OnPropertyChanged(nameof(School));
                }
            }
        }

        public string? YearOfGraduation 
        { 
            get => this.yearOfGraduation;
            set
            {
                if (this.yearOfGraduation != value)
                {
                    yearOfGraduation = value;
                    OnPropertyChanged(nameof(YearOfGraduation));
                }
            }
        } 

        public string? ImagePath
        {
            get => this.imagePath;
            set
            {
                if (this.imagePath != value)
                {
                    imagePath = value;
                    OnPropertyChanged(nameof(ImagePath));
                }
            }
        }

        public BitmapImage? ProfileImage
        {
            get => this.profileImage;
            set
            {
                if (this.profileImage != value)
                {
                    profileImage = value;
                    OnPropertyChanged(nameof(ProfileImage));
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //To enable UI Binding
        public ObservableCollection<string> Skills
        { 
            get => skills; 
            set
            {
                skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }
       
    }

    public class ResumeBuilder : ResumeInfo, INotifyPropertyChanged
    {
        //Skills method
        public void AddSkill(string skill)
        {
            if (!string.IsNullOrWhiteSpace(skill))
                Skills.Add(skill);
        }
        public void ClearSkills() => Skills.Clear();

        //Upload Image Method
        public void UploadImage()
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

                ProfileImage = new BitmapImage(new Uri(openFileDialog.FileName));
                ImagePath = openFileDialog.FileName; // Store the path if needed for PDF export
            }
        }

        //Saving method
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
            try
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
                MessageBox.Show($"{filePath}.txt has been saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex);
            }
        }

        private void ExportToPDF(string pdfFilePath)
        {
            try
            {
                using (PdfWriter writer = new PdfWriter(pdfFilePath))
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    //Add the Profile Img
                    if(!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                    {
                        var ImgData = ImageDataFactory.Create(ImagePath);
                        var profileImage = new iText.Layout.Element.Image(ImgData);

                        //Formatting of image in the pdf
                        profileImage.ScaleToFit(100, 100); //Scales the image
                        profileImage.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT); //Aligns the image to the left
                        document.Add(new Paragraph("\n"));
                        document.Add(profileImage);
                        document.Add(new Paragraph("\n"));
                    }

                    document.Add(new Paragraph($"{Name}"));
                    document.Add(new Paragraph($"{Email}"));
                    document.Add(new Paragraph($"{PhoneNumber}"));
                    document.Add(new Paragraph("Work Experience:"));
                    document.Add(new Paragraph($"Company: {Company}"));
                    document.Add(new Paragraph($"Job Title: {JobTitle}"));
                    document.Add(new Paragraph($"Duration: {Duration}"));
                    document.Add(new Paragraph("Education:"));
                    document.Add(new Paragraph($"Degree: {Degree}"));
                    document.Add(new Paragraph($"School: {School}"));
                    document.Add(new Paragraph($"Year of Graduation: {YearOfGraduation}"));

                    document.Add(new Paragraph("Skills:"));
                    if (Skills.Count > 0)
                    {
                        foreach (var skill in Skills)
                        {
                            document.Add(new Paragraph($"- {skill}"));
                        }
                    }
                    else
                    {
                        document.Add(new Paragraph("- No skills provided"));
                    }
                }

                MessageBox.Show($"{pdfFilePath}.pdf has been saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: " + ex);
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
