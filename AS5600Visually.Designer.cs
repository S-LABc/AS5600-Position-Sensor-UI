
namespace AS5600PositionSensorUI
{
    partial class FormAS5600
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.btnConn = new System.Windows.Forms.Button();
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.lblReadAng = new System.Windows.Forms.Label();
            this.lblDegAng = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbPort
            // 
            this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPort.Location = new System.Drawing.Point(12, 314);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(73, 21);
            this.cbPort.TabIndex = 0;
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(162, 314);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(75, 23);
            this.btnConn.TabIndex = 1;
            this.btnConn.Text = "Connect";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.BtnConn_Click);
            // 
            // SerialPort
            // 
            this.SerialPort.BaudRate = 115200;
            this.SerialPort.ReadBufferSize = 10;
            this.SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // lblReadAng
            // 
            this.lblReadAng.AutoSize = true;
            this.lblReadAng.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblReadAng.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblReadAng.Location = new System.Drawing.Point(141, 223);
            this.lblReadAng.Name = "lblReadAng";
            this.lblReadAng.Size = new System.Drawing.Size(74, 31);
            this.lblReadAng.TabIndex = 2;
            this.lblReadAng.Text = "4095";
            // 
            // lblDegAng
            // 
            this.lblDegAng.AutoSize = true;
            this.lblDegAng.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDegAng.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblDegAng.Location = new System.Drawing.Point(140, 261);
            this.lblDegAng.Name = "lblDegAng";
            this.lblDegAng.Size = new System.Drawing.Size(97, 31);
            this.lblDegAng.TabIndex = 3;
            this.lblDegAng.Text = "360,00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "ADC Raw Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "DEGREE Angle";
            // 
            // FormAS5600
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 357);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDegAng);
            this.Controls.Add(this.lblReadAng);
            this.Controls.Add(this.btnConn);
            this.Controls.Add(this.cbPort);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAS5600";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AS5600 Visually";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAS5600_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Button btnConn;
        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.Label lblReadAng;
        private System.Windows.Forms.Label lblDegAng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

