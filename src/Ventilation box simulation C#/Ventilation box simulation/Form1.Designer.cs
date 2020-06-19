namespace Ventilation_box_simulation
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.lblCO2 = new System.Windows.Forms.Label();
            this.lblVOC = new System.Windows.Forms.Label();
            this.timerGetValues = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.spSensorBoard = new System.IO.Ports.SerialPort(this.components);
            this.pbAirflow = new System.Windows.Forms.PictureBox();
            this.lblGr5 = new System.Windows.Forms.Label();
            this.lblGr1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGr3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timerSendData = new System.Windows.Forms.Timer(this.components);
            this.lblFan = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAirflow)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(92, 84);
            this.lblTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(153, 29);
            this.lblTemp.TabIndex = 0;
            this.lblTemp.Text = "Temperature";
            // 
            // lblHumidity
            // 
            this.lblHumidity.AutoSize = true;
            this.lblHumidity.Location = new System.Drawing.Point(92, 190);
            this.lblHumidity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(106, 29);
            this.lblHumidity.TabIndex = 1;
            this.lblHumidity.Text = "Humidity";
            // 
            // lblCO2
            // 
            this.lblCO2.AutoSize = true;
            this.lblCO2.Location = new System.Drawing.Point(92, 299);
            this.lblCO2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCO2.Name = "lblCO2";
            this.lblCO2.Size = new System.Drawing.Size(62, 29);
            this.lblCO2.TabIndex = 2;
            this.lblCO2.Text = "CO2";
            // 
            // lblVOC
            // 
            this.lblVOC.AutoSize = true;
            this.lblVOC.Location = new System.Drawing.Point(92, 408);
            this.lblVOC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVOC.Name = "lblVOC";
            this.lblVOC.Size = new System.Drawing.Size(64, 29);
            this.lblVOC.TabIndex = 3;
            this.lblVOC.Text = "VOC";
            // 
            // timerGetValues
            // 
            this.timerGetValues.Enabled = true;
            this.timerGetValues.Interval = 200;
            this.timerGetValues.Tick += new System.EventHandler(this.timerGetValues_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.lblHumidity);
            this.groupBox1.Controls.Add(this.lblVOC);
            this.groupBox1.Controls.Add(this.lblTemp);
            this.groupBox1.Controls.Add(this.lblCO2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(48, 45);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(518, 494);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atmospheric values";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(20, 396);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(65, 65);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(20, 281);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(65, 65);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(20, 168);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(65, 65);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(20, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 65);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(618, 66);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(548, 244);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // spSensorBoard
            // 
            this.spSensorBoard.PortName = "COM8";
            // 
            // pbAirflow
            // 
            this.pbAirflow.Image = ((System.Drawing.Image)(resources.GetObject("pbAirflow.Image")));
            this.pbAirflow.Location = new System.Drawing.Point(664, 248);
            this.pbAirflow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbAirflow.Name = "pbAirflow";
            this.pbAirflow.Size = new System.Drawing.Size(486, 80);
            this.pbAirflow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAirflow.TabIndex = 8;
            this.pbAirflow.TabStop = false;
            this.pbAirflow.Visible = false;
            // 
            // lblGr5
            // 
            this.lblGr5.AutoSize = true;
            this.lblGr5.Location = new System.Drawing.Point(7, 128);
            this.lblGr5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGr5.Name = "lblGr5";
            this.lblGr5.Size = new System.Drawing.Size(74, 18);
            this.lblGr5.TabIndex = 9;
            this.lblGr5.Text = "Group 5:";
            // 
            // lblGr1
            // 
            this.lblGr1.AutoSize = true;
            this.lblGr1.Location = new System.Drawing.Point(7, 37);
            this.lblGr1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGr1.Name = "lblGr1";
            this.lblGr1.Size = new System.Drawing.Size(74, 18);
            this.lblGr1.TabIndex = 10;
            this.lblGr1.Text = "Group 1:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 13;
            // 
            // lblGr3
            // 
            this.lblGr3.AutoSize = true;
            this.lblGr3.Location = new System.Drawing.Point(7, 84);
            this.lblGr3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGr3.Name = "lblGr3";
            this.lblGr3.Size = new System.Drawing.Size(74, 18);
            this.lblGr3.TabIndex = 14;
            this.lblGr3.Text = "Group 3:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.lblGr1);
            this.groupBox2.Controls.Add(this.lblGr3);
            this.groupBox2.Controls.Add(this.lblGr5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(48, 572);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1129, 178);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other shields";
            // 
            // timerSendData
            // 
            this.timerSendData.Enabled = true;
            this.timerSendData.Interval = 5000;
            this.timerSendData.Tick += new System.EventHandler(this.timerSendData_Tick);
            // 
            // lblFan
            // 
            this.lblFan.AutoSize = true;
            this.lblFan.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFan.Location = new System.Drawing.Point(584, 418);
            this.lblFan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFan.Name = "lblFan";
            this.lblFan.Size = new System.Drawing.Size(159, 29);
            this.lblFan.TabIndex = 5;
            this.lblFan.Text = "Ventilation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1216, 782);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbAirflow);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFan);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Comfort Home";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAirflow)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.Label lblCO2;
        private System.Windows.Forms.Label lblVOC;
        private System.Windows.Forms.Timer timerGetValues;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.IO.Ports.SerialPort spSensorBoard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbAirflow;
        private System.Windows.Forms.Label lblGr5;
        private System.Windows.Forms.Label lblGr1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblGr3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timerSendData;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblFan;
    }
}

