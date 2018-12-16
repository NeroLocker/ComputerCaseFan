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
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.diameterTextBox = new System.Windows.Forms.TextBox();
            this.thicknessTextBox = new System.Windows.Forms.TextBox();
            this.bladesTextBox = new System.Windows.Forms.TextBox();
            this.turnTextBox = new System.Windows.Forms.TextBox();
            this.noteLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
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
            // lengthTextBox
            // 
            resources.ApplyResources(this.lengthTextBox, "lengthTextBox");
            this.lengthTextBox.Name = "lengthTextBox";
            // 
            // diameterTextBox
            // 
            resources.ApplyResources(this.diameterTextBox, "diameterTextBox");
            this.diameterTextBox.Name = "diameterTextBox";
            // 
            // thicknessTextBox
            // 
            resources.ApplyResources(this.thicknessTextBox, "thicknessTextBox");
            this.thicknessTextBox.Name = "thicknessTextBox";
            // 
            // bladesTextBox
            // 
            resources.ApplyResources(this.bladesTextBox, "bladesTextBox");
            this.bladesTextBox.Name = "bladesTextBox";
            // 
            // turnTextBox
            // 
            resources.ApplyResources(this.turnTextBox, "turnTextBox");
            this.turnTextBox.Name = "turnTextBox";
            // 
            // noteLabel
            // 
            resources.ApplyResources(this.noteLabel, "noteLabel");
            this.noteLabel.Name = "noteLabel";
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.turnTextBox);
            this.Controls.Add(this.bladesTextBox);
            this.Controls.Add(this.thicknessTextBox);
            this.Controls.Add(this.diameterTextBox);
            this.Controls.Add(this.lengthTextBox);
            this.Controls.Add(this.bladeTurnLabel);
            this.Controls.Add(this.bladesQuantityLabel);
            this.Controls.Add(this.bladeThicknessLabel);
            this.Controls.Add(this.holesDiameterLabel);
            this.Controls.Add(this.frameLengthLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label frameLengthLabel;
        private System.Windows.Forms.Label holesDiameterLabel;
        private System.Windows.Forms.Label bladeThicknessLabel;
        private System.Windows.Forms.Label bladesQuantityLabel;
        private System.Windows.Forms.Label bladeTurnLabel;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.TextBox diameterTextBox;
        private System.Windows.Forms.TextBox thicknessTextBox;
        private System.Windows.Forms.TextBox bladesTextBox;
        private System.Windows.Forms.TextBox turnTextBox;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}