using Avalonia.Controls;
using Avalonia.Interactivity;
using System.IO;

namespace registorUser;

public partial class MainWindow : Window
{
    
    
    
    private const string FilePath = "C:\\Users\\User\\Documents\\UserData\\UserNameFile.txt";
    private const string FilePath1 = "C:\\Users\\User\\Documents\\UserData\\UserLastNameFile.txt";
    private const string FilePath2 = "C:\\Users\\User\\Documents\\UserData\\UserSurnameFile.txt";
    private const string FilePath3 = "C:\\Users\\User\\Documents\\UserData\\UserSexFile.txt";
    private const string FilePath4 = "C:\\Users\\User\\Documents\\UserData\\UserAgeFile.txt";
    public MainWindow()
    {
        InitializeComponent();
        
       

        var UserNameFile = File.ReadAllText(FilePath);
        var UserLastNameFile = File.ReadAllText(FilePath1);
        var UserSurnameFile = File.ReadAllText(FilePath2);
        var UserSexFile = File.ReadAllText(FilePath3);
        var UserAgeFile = File.ReadAllText(FilePath4);
        
        UserName.Text =  UserNameFile.Trim();
        UserLastName.Text = UserLastNameFile.Trim();
        UserSurname.Text = UserSurnameFile.Trim();
        Povestka.Text = UserSexFile.Trim();
        UserAge.Text = UserAgeFile.Trim();
    }
    

private void Button_OnClick_SaveData(object? sender, RoutedEventArgs e) 
    {
        
        
        var firstName = FirstName.Text;
        var lastName = LastName.Text;
        
        if (Surname.Text != string.Empty)
        {
            var surname = Surname.Text;
            UserSurname.Text = surname;
            File.WriteAllText(FilePath2, UserSurname.Text);
            Surname.Text = string.Empty;
            
        }
        else if (Surname.Text == string.Empty || string.IsNullOrEmpty(Surname.Text))
        {
            UserSurname.Text = "";
            Surname.Text = string.Empty;
            File.WriteAllText(FilePath2, UserSurname.Text);
        }
        
        // First Name IF
        if (FirstName.Text == string.Empty)
        {
            ErrorName.Text = "Вы не заполнили фамилию или имя, эти поля обязательное для заполнения";
            FirstName.Text = string.Empty;
        }
        else if (string.IsNullOrEmpty(firstName))
        {
            ErrorName.Text = "Поле не должно содержать пробелы";
            FirstName.Text = string.Empty;
        }
        else
        {
            UserName.Text = firstName.Trim();
            if (firstName != string.Empty)
            {
                File.WriteAllText(FilePath, UserName.Text);
            }

            ErrorName.Text = string.Empty;
            FirstName.Text = string.Empty;
        }
        
        // Last Name IF
        if (LastName.Text == string.Empty)
        {
            ErrorName.Text = "Вы не заполнили фамилию или имя, эти поля обязательное для заполнения";
            LastName.Text = string.Empty;
        }
        else if (string.IsNullOrEmpty(lastName))
        {
            ErrorName.Text = "Поле не должно содержать пробелы";
            LastName.Text = string.Empty;
        }
        else
        {
            UserLastName.Text = lastName.Trim();
            File.WriteAllText(FilePath1, UserLastName.Text);
            LastName.Text = string.Empty;
            ErrorName.Text = string.Empty;
        }
        
        // Блок пола?!
        if (Povestka1.IsChecked.Value)
        {
            Povestka.Text = "Мужчина";
            File.WriteAllText(FilePath3, Povestka.Text);
        }
        else if(Povestka2.IsChecked.Value)
        {
            Povestka.Text = "Женщина";
            File.WriteAllText(FilePath3, Povestka.Text);
        }
        else if(!Povestka2.IsChecked.Value || !Povestka1.IsChecked.Value)
        {
            ErrorPovestka.Text = "Выберите свой пол";
        }
        
        // Блок Возраста
        if (AgeHave.IsChecked.Value)
        {
            UserAge.Text = "Есть 18";
            File.WriteAllText(FilePath4, UserAge.Text);
        }
        else if(!AgeHave.IsChecked.Value)
        {
            UserAge.Text = "Нету 18";
            File.WriteAllText(FilePath4, UserAge.Text);
        }
        
        
    }

}