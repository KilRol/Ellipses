namespace Ellipses
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.bigEllipseRotateSpeed = new System.Windows.Forms.NumericUpDown();
            this.mediumEllipseRotateSpeed = new System.Windows.Forms.NumericUpDown();
            this.smallEllipseRotateSpeed = new System.Windows.Forms.NumericUpDown();
            this.mediumEllipseMoveSpeed = new System.Windows.Forms.NumericUpDown();
            this.smallEllipseMoveSpeed = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.bigEllipseRotateSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediumEllipseRotateSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallEllipseRotateSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediumEllipseMoveSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallEllipseMoveSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bigEllipseRotateSpeed
            // 
            this.bigEllipseRotateSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.bigEllipseRotateSpeed, "bigEllipseRotateSpeed");
            this.bigEllipseRotateSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.bigEllipseRotateSpeed.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.bigEllipseRotateSpeed.Name = "bigEllipseRotateSpeed";
            // 
            // mediumEllipseRotateSpeed
            // 
            resources.ApplyResources(this.mediumEllipseRotateSpeed, "mediumEllipseRotateSpeed");
            this.mediumEllipseRotateSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.mediumEllipseRotateSpeed.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.mediumEllipseRotateSpeed.Name = "mediumEllipseRotateSpeed";
            // 
            // smallEllipseRotateSpeed
            // 
            resources.ApplyResources(this.smallEllipseRotateSpeed, "smallEllipseRotateSpeed");
            this.smallEllipseRotateSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.smallEllipseRotateSpeed.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.smallEllipseRotateSpeed.Name = "smallEllipseRotateSpeed";
            // 
            // mediumEllipseMoveSpeed
            // 
            resources.ApplyResources(this.mediumEllipseMoveSpeed, "mediumEllipseMoveSpeed");
            this.mediumEllipseMoveSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.mediumEllipseMoveSpeed.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.mediumEllipseMoveSpeed.Name = "mediumEllipseMoveSpeed";
            // 
            // smallEllipseMoveSpeed
            // 
            resources.ApplyResources(this.smallEllipseMoveSpeed, "smallEllipseMoveSpeed");
            this.smallEllipseMoveSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.smallEllipseMoveSpeed.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.smallEllipseMoveSpeed.Name = "smallEllipseMoveSpeed";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.smallEllipseMoveSpeed);
            this.Controls.Add(this.mediumEllipseMoveSpeed);
            this.Controls.Add(this.smallEllipseRotateSpeed);
            this.Controls.Add(this.mediumEllipseRotateSpeed);
            this.Controls.Add(this.bigEllipseRotateSpeed);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint_1);
            ((System.ComponentModel.ISupportInitialize)(this.bigEllipseRotateSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediumEllipseRotateSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallEllipseRotateSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediumEllipseMoveSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallEllipseMoveSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private NumericUpDown bigEllipseRotateSpeed;
        private NumericUpDown mediumEllipseRotateSpeed;
        private NumericUpDown smallEllipseRotateSpeed;
        private NumericUpDown mediumEllipseMoveSpeed;
        private NumericUpDown smallEllipseMoveSpeed;
    }
}