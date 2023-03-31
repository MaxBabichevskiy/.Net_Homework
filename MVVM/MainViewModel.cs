using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public class MainViewModel : INotifyPropertyChanged
{
    static int id = 0; // для генерации идентификаторов

    // данные для нового объекта
    string name = "";
    int age;

    // команда для добавления
    public ICommand AddCommand { get; set; }
    // команда для удаления
    public ICommand DelCommand { get; set; }
    // данные для отображения в списке
    public BindingList<Person> People { get; }
    public string Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged();
            }
        }
    }
    public int Age
    {
        get => age;
        set
        {
            if (age != value)
            {
                age = value;
                OnPropertyChanged();
            }
        }
    }
    public MainViewModel()
    {
        People = new()
        {

            new Person {Id=++id, Name="Tom", Age=38 },
            new Person {Id=++id, Name ="Bob", Age = 42},
            new Person {Id=++id, Name = "Sam", Age = 25}
        };
        // определяем команду
        AddCommand = new MainCommand(_ =>
        {
            People.Add(new Person { Id = ++id, Name = this.Name, Age = this.Age });
            Name = ""; Age = 0;
        });

        DelCommand = new MainCommand(idToRemove =>
        {
            var personToRemove = People.FirstOrDefault(p => p.Id == (int)idToRemove);
            if (personToRemove != null)
            {
                People.Remove(personToRemove);
            }
        });

    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}