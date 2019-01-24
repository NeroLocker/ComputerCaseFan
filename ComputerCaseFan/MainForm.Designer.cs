namespace ComputerCaseFan
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.frameLengthLabel = new System.Windows.Forms.Label();
            this.holesDiameterLabel = new System.Windows.Forms.Label();
            this.bladeThicknessLabel = new System.Windows.Forms.Label();
            this.bladesQuantityLabel = new System.Windows.Forms.Label();
            this.bladeTurnLabel = new System.Windows.Forms.Label();
            this.frameLengthTextBox = new System.Windows.Forms.TextBox();
            this.holesDiameterTextBox = new System.Windows.Forms.TextBox();
            this.thicknessTextBox = new System.Windows.Forms.TextBox();
            this.bladeTurnTextBox = new System.Windows.Forms.TextBox();
            this.noteLabel = new System.Windows.Forms.Label();
            this.CreateFanButton = new System.Windows.Forms.Button();
            this.defaultParametersButton = new System.Windows.Forms.Button();
            this.bladesQuantityComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // frameLengthLabel
            // 
            resources.ApplyResources(this.frameLengthLabel, "frameLengthLabel");
            this.frameLengthLabel.Name = "frameLengthLabel";
            // 
            // holesDiameterLabel
            // 
            resources.ApplyResources(this.holesDiameterLabel, "holesDiameterLabel");
            this.holesDiameterLabel.Name = "holesDiameterLabel";
            // 
            // bladeThicknessLabel
            // 
            resources.ApplyResources(this.bladeThicknessLabel, "bladeThicknessLabel");
            this.bladeThicknessLabel.Name = "bladeThicknessLabel";
            // 
            // bladesQuantityLabel
            // 
            resources.ApplyResources(this.bladesQuantityLabel, "bladesQuantityLabel");
            this.bladesQuantityLabel.Name = "bladesQuantityLabel";
            // 
            // bladeTurnLabel
            // 
            resources.ApplyResources(this.bladeTurnLabel, "bladeTurnLabel");
            this.bladeTurnLabel.Name = "bladeTurnLabel";
            // 
            // frameLengthTextBox
            // 
            resources.ApplyResources(this.frameLengthTextBox, "frameLengthTextBox");
            this.frameLengthTextBox.Name = "frameLengthTextBox";
            this.frameLengthTextBox.Enter += new System.EventHandler(this.FrameLengthTextBox_Enter);
            this.frameLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrameLengthTextBox_KeyPress);
            // 
            // holesDiameterTextBox
            // 
            resources.ApplyResources(this.holesDiameterTextBox, "holesDiameterTextBox");
            this.holesDiameterTextBox.Name = "holesDiameterTextBox";
            this.holesDiameterTextBox.Enter += new System.EventHandler(this.HolesDiameterTextBox_Enter);
            this.holesDiameterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HolesDiameterTextBox_KeyPress);
            // 
            // thicknessTextBox
            // 
            resources.ApplyResources(this.thicknessTextBox, "thicknessTextBox");
            this.thicknessTextBox.Name = "thicknessTextBox";
            this.thicknessTextBox.Enter += new System.EventHandler(this.ThicknessTextBox_Enter);
            this.thicknessTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ThicknessTextBox_KeyPress);
            // 
            // bladeTurnTextBox
            // 
            resources.ApplyResources(this.bladeTurnTextBox, "bladeTurnTextBox");
            this.bladeTurnTextBox.Name = "bladeTurnTextBox";
            this.bladeTurnTextBox.Enter += new System.EventHandler(this.BladeTurnTextBox_Enter);
            this.bladeTurnTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BladeTurnTextBox_KeyPress);
            // 
            // noteLabel
            // 
            resources.ApplyResources(this.noteLabel, "noteLabel");
            this.noteLabel.Name = "noteLabel";
            // 
            // CreateFanButton
            // 
            resources.ApplyResources(this.CreateFanButton, "CreateFanButton");
            this.CreateFanButton.Name = "CreateFanButton";
            this.CreateFanButton.UseVisualStyleBackColor = true;
            this.CreateFanButton.Click += new System.EventHandler(this.CreateFanButton_Click);
            // 
            // defaultParametersButton
            // 
            resources.ApplyResources(this.defaultParametersButton, "defaultParametersButton");
            this.defaultParametersButton.Name = "defaultParametersButton";
            this.defaultParametersButton.UseVisualStyleBackColor = true;
            this.defaultParametersButton.Click += new System.EventHandler(this.DefaultParametersButton_Click);
            // 
            // bladesQuantityComboBox
            // 
            this.bladesQuantityComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.bladesQuantityComboBox, "bladesQuantityComboBox");
            this.bladesQuantityComboBox.Name = "bladesQuantityComboBox";
            this.bladesQuantityComboBox.SelectedIndexChanged += new System.EventHandler(this.BladesQuantityComboBox_SelectedIndexChanged);
            this.bladesQuantityComboBox.Enter += new System.EventHandler(this.BladesQuantityComboBox_Enter);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bladesQuantityComboBox);
            this.Controls.Add(this.defaultParametersButton);
            this.Controls.Add(this.CreateFanButton);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.bladeTurnTextBox);
            this.Controls.Add(this.thicknessTextBox);
            this.Controls.Add(this.holesDiameterTextBox);
            this.Controls.Add(this.frameLengthTextBox);
            this.Controls.Add(this.bladeTurnLabel);
            this.Controls.Add(this.bladesQuantityLabel);
            this.Controls.Add(this.bladeThicknessLabel);
            this.Controls.Add(this.holesDiameterLabel);
            this.Controls.Add(this.frameLengthLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label frameLengthLabel;
        private System.Windows.Forms.Label holesDiameterLabel;
        private System.Windows.Forms.Label bladeThicknessLabel;
        private System.Windows.Forms.Label bladesQuantityLabel;
        private System.Windows.Forms.Label bladeTurnLabel;
        private System.Windows.Forms.TextBox frameLengthTextBox;
        private System.Windows.Forms.TextBox holesDiameterTextBox;
        private System.Windows.Forms.TextBox thicknessTextBox;
        private System.Windows.Forms.TextBox bladeTurnTextBox;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Button CreateFanButton;
        private System.Windows.Forms.Button defaultParametersButton;
        private System.Windows.Forms.ComboBox bladesQuantityComboBox;
    }
}