namespace KeyboardSimulator
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
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.delayBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.repeatCheck = new System.Windows.Forms.CheckBox();
            this.hotkeyButton = new System.Windows.Forms.Button();
            this.helpLabel = new System.Windows.Forms.Label();
            this.tooltips = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(14, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(118, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(137, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(118, 23);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // delayBox
            // 
            this.delayBox.Location = new System.Drawing.Point(55, 41);
            this.delayBox.Name = "delayBox";
            this.delayBox.Size = new System.Drawing.Size(65, 20);
            this.delayBox.TabIndex = 3;
            this.delayBox.Text = "100";
            this.tooltips.SetToolTip(this.delayBox, "The delay between each character of output");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Delay:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Output:";
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(55, 67);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(199, 20);
            this.outputBox.TabIndex = 7;
            this.tooltips.SetToolTip(this.outputBox, "Keys to be simulated");
            // 
            // repeatCheck
            // 
            this.repeatCheck.AutoSize = true;
            this.repeatCheck.Location = new System.Drawing.Point(195, 43);
            this.repeatCheck.Name = "repeatCheck";
            this.repeatCheck.Size = new System.Drawing.Size(61, 17);
            this.repeatCheck.TabIndex = 8;
            this.repeatCheck.Text = "Repeat";
            this.tooltips.SetToolTip(this.repeatCheck, "Repeat the output");
            this.repeatCheck.UseVisualStyleBackColor = true;
            // 
            // hotkeyButton
            // 
            this.hotkeyButton.Location = new System.Drawing.Point(14, 93);
            this.hotkeyButton.Name = "hotkeyButton";
            this.hotkeyButton.Size = new System.Drawing.Size(241, 23);
            this.hotkeyButton.TabIndex = 9;
            this.hotkeyButton.Text = "Record hotkey";
            this.hotkeyButton.UseVisualStyleBackColor = true;
            this.hotkeyButton.Click += new System.EventHandler(this.hotkeyButton_Click);
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel.ForeColor = System.Drawing.Color.Blue;
            this.helpLabel.Location = new System.Drawing.Point(12, 120);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(29, 13);
            this.helpLabel.TabIndex = 10;
            this.helpLabel.Text = "Help";
            this.helpLabel.Click += new System.EventHandler(this.helpLabel_Click);
            // 
            // tooltips
            // 
            this.tooltips.AutoPopDelay = 5000;
            this.tooltips.InitialDelay = 300;
            this.tooltips.ReshowDelay = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 140);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.hotkeyButton);
            this.Controls.Add(this.repeatCheck);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delayBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Keyboard Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox delayBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.CheckBox repeatCheck;
        private System.Windows.Forms.Button hotkeyButton;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.ToolTip tooltips;
    }
}

