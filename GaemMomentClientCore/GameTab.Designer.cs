namespace GaemMoment
{
    partial class GameTab
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            moveInputBox = new System.Windows.Forms.TextBox();
            submitMoveButton = new System.Windows.Forms.Button();
            boardLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 177);
            label1.Location = new System.Drawing.Point(4, 11);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 24);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 177);
            label2.Location = new System.Drawing.Point(179, 321);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(211, 24);
            label2.TabIndex = 1;
            label2.Text = "Waiting For Opponent...";
            // 
            // moveInputBox
            // 
            moveInputBox.Location = new System.Drawing.Point(94, 277);
            moveInputBox.Name = "moveInputBox";
            moveInputBox.Size = new System.Drawing.Size(100, 23);
            moveInputBox.TabIndex = 3;
            // 
            // submitMoveButton
            // 
            submitMoveButton.Location = new System.Drawing.Point(200, 276);
            submitMoveButton.Name = "submitMoveButton";
            submitMoveButton.Size = new System.Drawing.Size(75, 23);
            submitMoveButton.TabIndex = 4;
            submitMoveButton.Text = "button1";
            submitMoveButton.UseVisualStyleBackColor = true;
            submitMoveButton.Click += SubmitMoveButton_Click;
            // 
            // boardLabel
            // 
            boardLabel.AutoSize = true;
            boardLabel.Location = new System.Drawing.Point(145, 100);
            boardLabel.Name = "boardLabel";
            boardLabel.Size = new System.Drawing.Size(66, 15);
            boardLabel.TabIndex = 6;
            boardLabel.Text = "boardLabel";
            // 
            // GameTab
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(boardLabel);
            Controls.Add(submitMoveButton);
            Controls.Add(moveInputBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "GameTab";
            Size = new System.Drawing.Size(1000, 1000);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox moveInputBox;
        private System.Windows.Forms.Button submitMoveButton;
        private System.Windows.Forms.Label boardLabel;
    }
}
