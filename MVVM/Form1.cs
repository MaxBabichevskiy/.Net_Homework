namespace MVVM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ListBox peopleListBox = new ListBox();
            peopleListBox.Dock = DockStyle.Left;
            peopleListBox.SelectionMode = SelectionMode.One;
            Controls.Add(peopleListBox);

         

            Panel personForm = new Panel { Padding = new Padding(10), Width = 260 };
            personForm.Dock = DockStyle.Right;
          


            TextBox nameBox = new TextBox();
            nameBox.Location = new Point(12, 10);
            nameBox.Size = new Size(230, 27);
            personForm.Controls.Add(nameBox);


          
            NumericUpDown ageBox = new NumericUpDown { Minimum = 0, Maximum = 100 };
            ageBox.Location = new Point(12, 50);
            ageBox.Size = new Size(230, 27);
            personForm.Controls.Add(ageBox);


           
            Button addButton = new Button { Text = "Save", AutoSize = true };
            addButton.Location = new Point(12, 80);
            personForm.Controls.Add(addButton);

            Button delButton = new Button { Text = "Delete", AutoSize = true };
            delButton.Location = new Point(120, 80);
            personForm.Controls.Add(delButton);


            Controls.Add(personForm);



            DataContext = new MainViewModel();
           


            peopleListBox.DataBindings.Add(new Binding("DataSource", DataContext, "People"));
            peopleListBox.DisplayMember = "Name";
            peopleListBox.ValueMember = "Id";


          
            nameBox.DataBindings.Add(new Binding("Text", DataContext, "Name", true, DataSourceUpdateMode.OnPropertyChanged));
            ageBox.DataBindings.Add(new Binding("Value", DataContext, "Age", true, DataSourceUpdateMode.OnPropertyChanged));
          
            
            
           
            addButton.DataBindings.Add(new Binding("Command", DataContext, "AddCommand", true));
            delButton.DataBindings.Add(new Binding("Command", DataContext, "DelCommand", true));
        }
    }
}