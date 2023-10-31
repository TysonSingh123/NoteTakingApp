using System.Data;

namespace NoteTakingApp
{
    public partial class noteTaker : Form
    {
        DataTable  Notes = new DataTable();
        bool editing = false;
        public noteTaker()
        {
            InitializeComponent();
        }

        private void noteTaker_Load(object sender, EventArgs e)
        {
            Notes.Columns.Add("Title");
            Notes.Columns.Add("Note");

            previousNotes.DataSource = Notes;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();

            }
            catch (Exception ex) { Console.WriteLine("Not a valid note"); }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = Notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = Notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                Notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                Notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = noteBox.Text;
            }
            else
            {
                Notes.Rows.Add(titleBox.Text, noteBox.Text);
            }
            titleBox.Text = "";
            noteBox.Text = "";
            editing = false;
        }

        private void newNoteButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            noteBox.Text = "";
        }

        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titleBox.Text = Notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = Notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
    }
}