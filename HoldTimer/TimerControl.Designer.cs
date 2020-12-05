
namespace HoldTimer
{
    partial class TimerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.deleteTimerButton = new System.Windows.Forms.Button();
            this.pauseTimerButton = new System.Windows.Forms.Button();
            this.resetTimerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(150)))), ((int)(((byte)(131)))));
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 43);
            this.label2.TabIndex = 1;
            this.label2.Text = "00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Past Timers";
            // 
            // deleteTimerButton
            // 
            this.deleteTimerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteTimerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteTimerButton.Font = new System.Drawing.Font("Wingdings 2", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.deleteTimerButton.ForeColor = System.Drawing.Color.IndianRed;
            this.deleteTimerButton.Image = global::HoldTimer.Properties.Resources.Remove_Icon;
            this.deleteTimerButton.Location = new System.Drawing.Point(434, 79);
            this.deleteTimerButton.Name = "deleteTimerButton";
            this.deleteTimerButton.Size = new System.Drawing.Size(31, 31);
            this.deleteTimerButton.TabIndex = 5;
            this.deleteTimerButton.UseVisualStyleBackColor = true;
            this.deleteTimerButton.Click += new System.EventHandler(this.deleteTimerButton_Click);
            // 
            // pauseTimerButton
            // 
            this.pauseTimerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseTimerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pauseTimerButton.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.pauseTimerButton.Image = global::HoldTimer.Properties.Resources.Pause_Icon;
            this.pauseTimerButton.Location = new System.Drawing.Point(434, 42);
            this.pauseTimerButton.Name = "pauseTimerButton";
            this.pauseTimerButton.Size = new System.Drawing.Size(31, 31);
            this.pauseTimerButton.TabIndex = 4;
            this.pauseTimerButton.UseVisualStyleBackColor = true;
            this.pauseTimerButton.Click += new System.EventHandler(this.pauseTimerButton_Click);
            // 
            // resetTimerButton
            // 
            this.resetTimerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetTimerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetTimerButton.Font = new System.Drawing.Font("Wingdings 3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.resetTimerButton.Image = global::HoldTimer.Properties.Resources.Restart_Icon;
            this.resetTimerButton.Location = new System.Drawing.Point(434, 5);
            this.resetTimerButton.Name = "resetTimerButton";
            this.resetTimerButton.Size = new System.Drawing.Size(31, 31);
            this.resetTimerButton.TabIndex = 3;
            this.resetTimerButton.UseVisualStyleBackColor = true;
            this.resetTimerButton.Click += new System.EventHandler(this.resetTimerButton_Click);
            // 
            // TimerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.Controls.Add(this.deleteTimerButton);
            this.Controls.Add(this.pauseTimerButton);
            this.Controls.Add(this.resetTimerButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TimerControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(473, 117);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button resetTimerButton;
        private System.Windows.Forms.Button pauseTimerButton;
        private System.Windows.Forms.Button deleteTimerButton;
    }
}
