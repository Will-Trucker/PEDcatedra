namespace PEDcatedra
{
    partial class FormDependencias
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTarea = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboPredecesora = new System.Windows.Forms.ComboBox();
            this.btnAgregarD = new System.Windows.Forms.Button();
            this.btnEliminarD = new System.Windows.Forms.Button();
            this.dataGridViewRelaciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dependencias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tarea";
            // 
            // comboTarea
            // 
            this.comboTarea.FormattingEnabled = true;
            this.comboTarea.Location = new System.Drawing.Point(27, 120);
            this.comboTarea.Name = "comboTarea";
            this.comboTarea.Size = new System.Drawing.Size(159, 21);
            this.comboTarea.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tarea Predecesora";
            // 
            // comboPredecesora
            // 
            this.comboPredecesora.FormattingEnabled = true;
            this.comboPredecesora.Location = new System.Drawing.Point(27, 211);
            this.comboPredecesora.Name = "comboPredecesora";
            this.comboPredecesora.Size = new System.Drawing.Size(159, 21);
            this.comboPredecesora.TabIndex = 4;
            // 
            // btnAgregarD
            // 
            this.btnAgregarD.Location = new System.Drawing.Point(429, 160);
            this.btnAgregarD.Name = "btnAgregarD";
            this.btnAgregarD.Size = new System.Drawing.Size(96, 36);
            this.btnAgregarD.TabIndex = 5;
            this.btnAgregarD.Text = "Agregar";
            this.btnAgregarD.UseVisualStyleBackColor = true;
            this.btnAgregarD.Click += new System.EventHandler(this.btnAgregarD_Click);
            // 
            // btnEliminarD
            // 
            this.btnEliminarD.Location = new System.Drawing.Point(568, 160);
            this.btnEliminarD.Name = "btnEliminarD";
            this.btnEliminarD.Size = new System.Drawing.Size(94, 36);
            this.btnEliminarD.TabIndex = 6;
            this.btnEliminarD.Text = "Eliminar";
            this.btnEliminarD.UseVisualStyleBackColor = true;
            this.btnEliminarD.Click += new System.EventHandler(this.btnEliminarD_Click);
            // 
            // dataGridViewRelaciones
            // 
            this.dataGridViewRelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRelaciones.Location = new System.Drawing.Point(27, 258);
            this.dataGridViewRelaciones.Name = "dataGridViewRelaciones";
            this.dataGridViewRelaciones.Size = new System.Drawing.Size(742, 142);
            this.dataGridViewRelaciones.TabIndex = 7;
            // 
            // FormDependencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewRelaciones);
            this.Controls.Add(this.btnEliminarD);
            this.Controls.Add(this.btnAgregarD);
            this.Controls.Add(this.comboPredecesora);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboTarea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormDependencias";
            this.Text = "FormDependencias";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTarea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboPredecesora;
        private System.Windows.Forms.Button btnAgregarD;
        private System.Windows.Forms.Button btnEliminarD;
        private System.Windows.Forms.DataGridView dataGridViewRelaciones;
    }
}