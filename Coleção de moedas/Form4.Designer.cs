namespace Coleção_de_moedas
{
    partial class Form4
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
            this.cbbMoedas = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            this.txbValue = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtExibir = new System.Windows.Forms.DateTimePicker();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.pbView = new System.Windows.Forms.PictureBox();
            this.lblDelete = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbMoedas
            // 
            this.cbbMoedas.FormattingEnabled = true;
            this.cbbMoedas.Items.AddRange(new object[] {
            "Pais",
            "Data de emissão",
            "Valor",
            "Tipo de metal",
            "Peso",
            "Diametro da moeda",
            "Variedades"});
            this.cbbMoedas.Location = new System.Drawing.Point(722, 193);
            this.cbbMoedas.Name = "cbbMoedas";
            this.cbbMoedas.Size = new System.Drawing.Size(121, 21);
            this.cbbMoedas.TabIndex = 0;
            this.cbbMoedas.Text = "Selecione:";
            this.cbbMoedas.SelectedIndexChanged += new System.EventHandler(this.cbbMoedas_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 107);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(309, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visualizar informações";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(711, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Selecione qual informação\r\n você deseja procurar ";
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Location = new System.Drawing.Point(738, 233);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(35, 13);
            this.lblAviso.TabIndex = 3;
            this.lblAviso.Text = "label3";
            // 
            // txbValue
            // 
            this.txbValue.Location = new System.Drawing.Point(731, 259);
            this.txbValue.Name = "txbValue";
            this.txbValue.Size = new System.Drawing.Size(100, 20);
            this.txbValue.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(741, 299);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Procurar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtExibir
            // 
            this.dtExibir.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExibir.Location = new System.Drawing.Point(680, 259);
            this.dtExibir.Name = "dtExibir";
            this.dtExibir.Size = new System.Drawing.Size(200, 20);
            this.dtExibir.TabIndex = 6;
            this.dtExibir.Value = new System.DateTime(2024, 9, 16, 0, 0, 0, 0);
            // 
            // gbResult
            // 
            this.gbResult.BackColor = System.Drawing.Color.Silver;
            this.gbResult.Controls.Add(this.btnDelete);
            this.gbResult.Controls.Add(this.lblDelete);
            this.gbResult.Controls.Add(this.lbInfo);
            this.gbResult.Controls.Add(this.pbView);
            this.gbResult.Location = new System.Drawing.Point(0, 104);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(674, 343);
            this.gbResult.TabIndex = 7;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Resultado:";
            // 
            // lbInfo
            // 
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.Location = new System.Drawing.Point(0, 30);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(674, 173);
            this.lbInfo.TabIndex = 1;
            this.lbInfo.SelectedIndexChanged += new System.EventHandler(this.lbInfo_SelectedIndexChanged);
            // 
            // pbView
            // 
            this.pbView.Location = new System.Drawing.Point(239, 209);
            this.pbView.Name = "pbView";
            this.pbView.Size = new System.Drawing.Size(176, 116);
            this.pbView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbView.TabIndex = 0;
            this.pbView.TabStop = false;
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Location = new System.Drawing.Point(475, 221);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(146, 13);
            this.lblDelete.TabIndex = 2;
            this.lblDelete.Text = "Clique aqui se deseja apagar.";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(513, 248);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 450);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.dtExibir);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txbValue);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbbMoedas);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbResult.ResumeLayout(false);
            this.gbResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbMoedas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.TextBox txbValue;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtExibir;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.PictureBox pbView;
        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Button btnDelete;
    }
}