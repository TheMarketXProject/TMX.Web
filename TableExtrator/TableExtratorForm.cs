using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableExtrator
{
  public partial class TableExtratorForm : Form
  {
    public TableExtratorForm()
    {
      InitializeComponent();
    }

    private void ExtractUser_Click(object sender, EventArgs e)
    {
      Button extractUserButton = new Button();
      extractUserButton.Location = new Point(303, 155);
      extractUserButton.Height = 44;
      extractUserButton.Width = 137;
      extractUserButton.Text = "Extract Old User Table";

      int tables = ExtractUserTable();
      MessageBox.Show($"{tables} Table(s) Extracted!");
    }

    private int ExtractUserTable()
    {
      return ExtractorService.ExtractUsers();
    }
  }
}
