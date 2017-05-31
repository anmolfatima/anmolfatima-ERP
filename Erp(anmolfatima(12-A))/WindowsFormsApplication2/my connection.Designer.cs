namespace WindowsFormsApplication1
{
    partial class MyConnection
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
            this.con = new System.Data.OleDb.OleDbConnection();
            this.SuspendLayout();
            // 
            // con
            // 
            this.con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Administrator.KTR-1003226" +
    "3\\Documents\\Visual Studio 2010\\Projects\\WindowsFormsApplication2\\WindowsFormsApp" +
    "lication2\\bin\\Debug\\PC_DB.accdb\"";
            // 
            // MyConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "MyConnection";
            this.Text = "MyConnection";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Data.OleDb.OleDbConnection con;
    }
}