namespace MerkeziHekimRandevuSistemi
{
	partial class FormGiris
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
			this.txtTCKN = new DevExpress.XtraEditors.TextEdit();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnUyeOl = new DevExpress.XtraEditors.SimpleButton();
			this.btnGiris = new DevExpress.XtraEditors.SimpleButton();
			this.linkSifreUnuttum = new DevExpress.XtraEditors.HyperlinkLabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.txtSifre = new DevExpress.XtraEditors.TextEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.txtTCKN.Properties)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// txtTCKN
			// 
			this.txtTCKN.EditValue = "11111111111";
			this.txtTCKN.Location = new System.Drawing.Point(297, 36);
			this.txtTCKN.Name = "txtTCKN";
			this.txtTCKN.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.txtTCKN.Properties.Appearance.ForeColor = System.Drawing.Color.Gray;
			this.txtTCKN.Properties.Appearance.Options.UseFont = true;
			this.txtTCKN.Properties.Appearance.Options.UseForeColor = true;
			this.txtTCKN.Size = new System.Drawing.Size(240, 40);
			this.txtTCKN.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel1.Controls.Add(this.btnUyeOl);
			this.panel1.Controls.Add(this.btnGiris);
			this.panel1.Controls.Add(this.linkSifreUnuttum);
			this.panel1.Controls.Add(this.labelControl2);
			this.panel1.Controls.Add(this.labelControl1);
			this.panel1.Controls.Add(this.txtSifre);
			this.panel1.Controls.Add(this.txtTCKN);
			this.panel1.Location = new System.Drawing.Point(321, 187);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(586, 319);
			this.panel1.TabIndex = 1;
			// 
			// btnUyeOl
			// 
			this.btnUyeOl.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.btnUyeOl.Appearance.BorderColor = System.Drawing.SystemColors.GrayText;
			this.btnUyeOl.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnUyeOl.Appearance.Options.UseBackColor = true;
			this.btnUyeOl.Appearance.Options.UseBorderColor = true;
			this.btnUyeOl.Appearance.Options.UseFont = true;
			this.btnUyeOl.Location = new System.Drawing.Point(35, 239);
			this.btnUyeOl.Name = "btnUyeOl";
			this.btnUyeOl.Size = new System.Drawing.Size(502, 42);
			this.btnUyeOl.TabIndex = 6;
			this.btnUyeOl.Text = "Üye Ol";
			this.btnUyeOl.Click += new System.EventHandler(this.BtnUyeOl_Click);
			// 
			// btnGiris
			// 
			this.btnGiris.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
			this.btnGiris.Appearance.BorderColor = System.Drawing.Color.DodgerBlue;
			this.btnGiris.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btnGiris.Appearance.Options.UseBackColor = true;
			this.btnGiris.Appearance.Options.UseBorderColor = true;
			this.btnGiris.Appearance.Options.UseFont = true;
			this.btnGiris.Location = new System.Drawing.Point(35, 191);
			this.btnGiris.Name = "btnGiris";
			this.btnGiris.Size = new System.Drawing.Size(502, 42);
			this.btnGiris.TabIndex = 5;
			this.btnGiris.Text = "Giriş";
			this.btnGiris.Click += new System.EventHandler(this.BtnGiris_Click);
			// 
			// linkSifreUnuttum
			// 
			this.linkSifreUnuttum.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.linkSifreUnuttum.Appearance.Options.UseFont = true;
			this.linkSifreUnuttum.Location = new System.Drawing.Point(420, 137);
			this.linkSifreUnuttum.Name = "linkSifreUnuttum";
			this.linkSifreUnuttum.Size = new System.Drawing.Size(117, 19);
			this.linkSifreUnuttum.TabIndex = 4;
			this.linkSifreUnuttum.Text = "Şifremi Unuttum";
			this.linkSifreUnuttum.Click += new System.EventHandler(this.LinkSifreUnuttum_Click);
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.labelControl2.Appearance.Options.UseFont = true;
			this.labelControl2.Location = new System.Drawing.Point(203, 100);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(76, 25);
			this.labelControl2.TabIndex = 3;
			this.labelControl2.Text = "Şifreniz:";
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.labelControl1.Appearance.Options.UseFont = true;
			this.labelControl1.Location = new System.Drawing.Point(66, 45);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(213, 25);
			this.labelControl1.TabIndex = 2;
			this.labelControl1.Text = "T.C. Kimlik Numaranız:";
			// 
			// txtSifre
			// 
			this.txtSifre.EditValue = "1234";
			this.txtSifre.Location = new System.Drawing.Point(297, 91);
			this.txtSifre.Name = "txtSifre";
			this.txtSifre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.txtSifre.Properties.Appearance.ForeColor = System.Drawing.Color.Gray;
			this.txtSifre.Properties.Appearance.Options.UseFont = true;
			this.txtSifre.Properties.Appearance.Options.UseForeColor = true;
			this.txtSifre.Properties.PasswordChar = '*';
			this.txtSifre.Size = new System.Drawing.Size(240, 40);
			this.txtSifre.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label1.Location = new System.Drawing.Point(324, 163);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(276, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Merkezi Hekim Randevu Sistemi";
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox2.Image = global::MerkeziHekimRandevuSistemi.Properties.Resources.saglikBakanligiLogo;
			this.pictureBox2.Location = new System.Drawing.Point(815, 110);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(61, 58);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::MerkeziHekimRandevuSistemi.Properties.Resources.alo182Logo;
			this.pictureBox1.Location = new System.Drawing.Point(356, 103);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(63, 57);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label2.Location = new System.Drawing.Point(785, 171);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "T.C. SAĞLIK BAKANLIĞI";
			// 
			// FormGiris
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
			this.BackgroundImageStore = global::MerkeziHekimRandevuSistemi.Properties.Resources.background;
			this.ClientSize = new System.Drawing.Size(1192, 653);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.panel1);
			this.Name = "FormGiris";
			this.Text = "Giriş";
			((System.ComponentModel.ISupportInitialize)(this.txtTCKN.Properties)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.TextEdit txtTCKN;
		private System.Windows.Forms.Panel panel1;
		private DevExpress.XtraEditors.SimpleButton btnGiris;
		private DevExpress.XtraEditors.HyperlinkLabelControl linkSifreUnuttum;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.TextEdit txtSifre;
		private DevExpress.XtraEditors.SimpleButton btnUyeOl;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label2;
	}
}

