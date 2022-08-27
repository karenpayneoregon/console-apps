using System.Text;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private int _columnIndex = 0;
    public Form1()
    {
        InitializeComponent();
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
}