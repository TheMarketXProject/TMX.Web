namespace TableExtrator
{
  partial class TableExtratorForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.ExtractUser = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // ExtractUser
      // 
      this.ExtractUser.Location = new System.Drawing.Point(303, 155);
      this.ExtractUser.Name = "ExtractUser";
      this.ExtractUser.Size = new System.Drawing.Size(137, 44);
      this.ExtractUser.TabIndex = 0;
      this.ExtractUser.Text = "Extract User";
      this.ExtractUser.UseVisualStyleBackColor = true;
      this.ExtractUser.Click += new System.EventHandler(this.ExtractUser_Click);
      // 
      // TableExtratorForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.ExtractUser);
      this.Name = "TableExtratorForm";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button ExtractUser;
  }
}

