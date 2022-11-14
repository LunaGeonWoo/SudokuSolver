namespace SudokuSolver
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.boardPanel = new System.Windows.Forms.Panel();
            this.solveButton = new System.Windows.Forms.Button();
            this.procViewCheckBox = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.integratedTrackBar = new System.Windows.Forms.TrackBar();
            this.initButton = new System.Windows.Forms.Button();
            this.leftLabel = new System.Windows.Forms.Label();
            this.rightLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.integratedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.Location = new System.Drawing.Point(0, 0);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(470, 470);
            this.boardPanel.TabIndex = 0;
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(358, 476);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(100, 30);
            this.solveButton.TabIndex = 1;
            this.solveButton.Text = "소도쿠 풀기";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // procViewCheckBox
            // 
            this.procViewCheckBox.AutoSize = true;
            this.procViewCheckBox.Location = new System.Drawing.Point(276, 485);
            this.procViewCheckBox.Name = "procViewCheckBox";
            this.procViewCheckBox.Size = new System.Drawing.Size(76, 16);
            this.procViewCheckBox.TabIndex = 2;
            this.procViewCheckBox.Text = "과정 보기";
            this.procViewCheckBox.UseVisualStyleBackColor = true;
            this.procViewCheckBox.CheckedChanged += new System.EventHandler(this.procViewCheckBox_CheckedChanged);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // integratedTrackBar
            // 
            this.integratedTrackBar.Location = new System.Drawing.Point(12, 512);
            this.integratedTrackBar.Maximum = 200;
            this.integratedTrackBar.Name = "integratedTrackBar";
            this.integratedTrackBar.Size = new System.Drawing.Size(446, 45);
            this.integratedTrackBar.TabIndex = 3;
            this.integratedTrackBar.Value = 10;
            this.integratedTrackBar.Visible = false;
            this.integratedTrackBar.Scroll += new System.EventHandler(this.integratedTrackBar_Scroll);
            // 
            // initButton
            // 
            this.initButton.Location = new System.Drawing.Point(12, 476);
            this.initButton.Name = "initButton";
            this.initButton.Size = new System.Drawing.Size(75, 25);
            this.initButton.TabIndex = 4;
            this.initButton.Text = "초기화";
            this.initButton.UseVisualStyleBackColor = true;
            this.initButton.Click += new System.EventHandler(this.initButton_Click);
            // 
            // leftLabel
            // 
            this.leftLabel.AutoSize = true;
            this.leftLabel.Location = new System.Drawing.Point(10, 560);
            this.leftLabel.Name = "leftLabel";
            this.leftLabel.Size = new System.Drawing.Size(41, 12);
            this.leftLabel.TabIndex = 5;
            this.leftLabel.Text = "느리게";
            this.leftLabel.Visible = false;
            // 
            // rightLabel
            // 
            this.rightLabel.AutoSize = true;
            this.rightLabel.Location = new System.Drawing.Point(417, 560);
            this.rightLabel.Name = "rightLabel";
            this.rightLabel.Size = new System.Drawing.Size(41, 12);
            this.rightLabel.TabIndex = 6;
            this.rightLabel.Text = "빠르게";
            this.rightLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 582);
            this.Controls.Add(this.rightLabel);
            this.Controls.Add(this.leftLabel);
            this.Controls.Add(this.initButton);
            this.Controls.Add(this.integratedTrackBar);
            this.Controls.Add(this.procViewCheckBox);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.boardPanel);
            this.Name = "MainForm";
            this.Text = "SudokuSolver";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.integratedTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel boardPanel;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.CheckBox procViewCheckBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TrackBar integratedTrackBar;
        private System.Windows.Forms.Button initButton;
        private System.Windows.Forms.Label leftLabel;
        private System.Windows.Forms.Label rightLabel;
    }
}

