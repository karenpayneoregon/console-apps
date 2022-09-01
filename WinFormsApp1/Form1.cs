using EzPasswordValidator.Checks;
using EzPasswordValidator.Validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private int _columnIndex = 0;
    public Form1()
    {
        InitializeComponent();

       
        WineTypeComboBox.DataSource = EnumHelper.GetItems<WineVariantId>();
        WineTypeComboBox.SelectedIndex = -1;

        var validator = new PasswordValidator(CheckTypes.Symbols | CheckTypes.CaseUpperLower | CheckTypes.Numbers | CheckTypes.Length)
        {
            MinLength = 8
        };

        bool isValid = validator.Validate("@12ewWww");

    }

    private void NewColumnButton_Click(object sender, EventArgs e)
    {

        var column = new DataGridViewTextBoxColumn
        {
            Name = $"ColumnName{_columnIndex +1}",
            HeaderText = $"New Column {_columnIndex}".NextValue(),
            AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        };

        dataGridView1.Columns.Add(column);
        _columnIndex++;

    }

    /// <summary>
    /// List column names, don't do this with a large amount of columns as on
    /// a small screen may cause the okay button to go off screen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ListColumnsButton_Click(object sender, EventArgs e)
    {
        var columns = dataGridView1
            .Columns.Cast<DataGridViewColumn>().Select(c => c.Name).ToArray();

        StringBuilder builder = new();
        foreach (var name in columns)
        {
            builder.AppendLine(name);
        }

        MessageBox.Show(builder.ToString());
    }

    private void Mockup()
    {
        List<Client> clients = new List<Client>();

        clients.Add(new Client() {Name = "First", ApiScopes = new List<string>() {"A","B","C"}});
        clients.Add(new Client() {Name = "Second", ApiScopes = new List<string>() {"D","B","F"}});

        var scopes = clients
            .SelectMany(c => ((IEnumerable<string>)c.ApiScopes) ?? Enumerable.Empty<string>())
            .Distinct()
            .ToList();

    }

    public class Client
    {
        public string Name { get; set; }

        public List<string> ApiScopes { get; set; }
    }

    public enum WineVariantId
    {

        [Description("Imported red wine")]
        [Display(Name = "Imported red wine")]
        Red = 1,
        [Description("Imported white wine")]
        [Display(Name = "Imported white wine")]
        White = 2,
        [Description("Imported rose wine")]
        [Display(Name = "Imported rose wine")]
        Rose = 3
    }
    public class ItemContainer
    {
        /// <summary>
        /// Display text
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Underlying enum
        /// </summary>
        public Enum Value { get; set; }

        public override string ToString() => Description;


    }
    public class EnumHelper
    {
        public static List<ItemContainer> GetItems<T>()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Must be an enum");
            }

            return Enum.GetValues(typeof(T)).Cast<T>()
                .Cast<Enum>()
                .Select(value => new ItemContainer
                {
                    Description =
                        ((Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString())!,
                            typeof(DescriptionAttribute)) as DescriptionAttribute)!)
                        .Description,
                    Value = value
                }).ToList();
        }
    }

    private void WineTypeButton_Click(object sender, EventArgs e)
    {
        if (WineTypeComboBox.SelectedIndex > -1)
        {
            MessageBox.Show(((ItemContainer)WineTypeComboBox.SelectedItem).Value.ToString());
        }
    }
}