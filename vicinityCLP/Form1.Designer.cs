using System.Threading;

namespace VicinityCLP
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
            if (process_agent != null)
            {
                try
                {
                    ProcessHandling.StopProcess((uint)process_agent.Id);
                }
                catch
                { }

                process_agent.Close();
                process_agent.Dispose();
            }

            if (process_gateway != null)
            {
                try
                {
                    ProcessHandling.StopProcess((uint)process_gateway.Id);
                }
                catch
                { }

                process_gateway.Close();
                process_gateway.Dispose();
            }

            if (worker != null)
            {
                worker.Stop();
            }


            Thread.Sleep(3000);


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
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnJAVAStartGateway = new System.Windows.Forms.Button();
            this.btnJAVAStopGateway = new System.Windows.Forms.Button();
            this.btnJAVAStartAgent = new System.Windows.Forms.Button();
            this.btnJAVAStopAgent = new System.Windows.Forms.Button();
            this.rtbLogAgent = new System.Windows.Forms.RichTextBox();
            this.rtbLogAdapter = new System.Windows.Forms.RichTextBox();
            this.rtbErrorAgent = new System.Windows.Forms.RichTextBox();
            this.rtbErrorGateway = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStartAll = new System.Windows.Forms.Button();
            this.btnStopAll = new System.Windows.Forms.Button();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(683, 12);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(75, 23);
            this.btnStartService.TabIndex = 13;
            this.btnStartService.Text = "Start service";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(764, 12);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(75, 23);
            this.btnStopService.TabIndex = 16;
            this.btnStopService.Text = "Stop service";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnJAVAStartGateway
            // 
            this.btnJAVAStartGateway.Location = new System.Drawing.Point(12, 12);
            this.btnJAVAStartGateway.Name = "btnJAVAStartGateway";
            this.btnJAVAStartGateway.Size = new System.Drawing.Size(146, 23);
            this.btnJAVAStartGateway.TabIndex = 19;
            this.btnJAVAStartGateway.Text = "start VICINITY gateway";
            this.btnJAVAStartGateway.UseVisualStyleBackColor = true;
            this.btnJAVAStartGateway.Click += new System.EventHandler(this.btnJAVAStartGateway_Click);
            // 
            // btnJAVAStopGateway
            // 
            this.btnJAVAStopGateway.Location = new System.Drawing.Point(164, 12);
            this.btnJAVAStopGateway.Name = "btnJAVAStopGateway";
            this.btnJAVAStopGateway.Size = new System.Drawing.Size(146, 23);
            this.btnJAVAStopGateway.TabIndex = 21;
            this.btnJAVAStopGateway.Text = "stop VICINITY gateway";
            this.btnJAVAStopGateway.UseVisualStyleBackColor = true;
            this.btnJAVAStopGateway.Click += new System.EventHandler(this.btnJAVAStopGateway_Click);
            // 
            // btnJAVAStartAgent
            // 
            this.btnJAVAStartAgent.Location = new System.Drawing.Point(354, 12);
            this.btnJAVAStartAgent.Name = "btnJAVAStartAgent";
            this.btnJAVAStartAgent.Size = new System.Drawing.Size(129, 23);
            this.btnJAVAStartAgent.TabIndex = 22;
            this.btnJAVAStartAgent.Text = "start VICINITY agent";
            this.btnJAVAStartAgent.UseVisualStyleBackColor = true;
            this.btnJAVAStartAgent.Click += new System.EventHandler(this.btnJAVAStartAgent_Click);
            // 
            // btnJAVAStopAgent
            // 
            this.btnJAVAStopAgent.Location = new System.Drawing.Point(489, 12);
            this.btnJAVAStopAgent.Name = "btnJAVAStopAgent";
            this.btnJAVAStopAgent.Size = new System.Drawing.Size(129, 23);
            this.btnJAVAStopAgent.TabIndex = 23;
            this.btnJAVAStopAgent.Text = "stop VICINITY agent";
            this.btnJAVAStopAgent.UseVisualStyleBackColor = true;
            this.btnJAVAStopAgent.Click += new System.EventHandler(this.btnJAVAStopAgent_Click);
            // 
            // rtbLogAgent
            // 
            this.rtbLogAgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogAgent.Location = new System.Drawing.Point(723, 3);
            this.rtbLogAgent.Name = "rtbLogAgent";
            this.rtbLogAgent.Size = new System.Drawing.Size(354, 603);
            this.rtbLogAgent.TabIndex = 19;
            this.rtbLogAgent.Text = "";
            // 
            // rtbLogAdapter
            // 
            this.rtbLogAdapter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogAdapter.Location = new System.Drawing.Point(1083, 3);
            this.rtbLogAdapter.Name = "rtbLogAdapter";
            this.rtbLogAdapter.Size = new System.Drawing.Size(357, 603);
            this.rtbLogAdapter.TabIndex = 19;
            this.rtbLogAdapter.Text = "";
            // 
            // rtbErrorAgent
            // 
            this.rtbErrorAgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbErrorAgent.Location = new System.Drawing.Point(363, 3);
            this.rtbErrorAgent.Name = "rtbErrorAgent";
            this.rtbErrorAgent.Size = new System.Drawing.Size(354, 603);
            this.rtbErrorAgent.TabIndex = 20;
            this.rtbErrorAgent.Text = "";
            // 
            // rtbErrorGateway
            // 
            this.rtbErrorGateway.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbErrorGateway.Location = new System.Drawing.Point(3, 3);
            this.rtbErrorGateway.Name = "rtbErrorGateway";
            this.rtbErrorGateway.Size = new System.Drawing.Size(354, 603);
            this.rtbErrorGateway.TabIndex = 20;
            this.rtbErrorGateway.Text = "";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.rtbLogAdapter, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.rtbLogAgent, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.rtbErrorAgent, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.rtbErrorGateway, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 68);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1443, 609);
            this.tableLayoutPanel3.TabIndex = 26;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(1363, 39);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 27;
            this.btnClearAll.Text = "clear";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1363, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Control";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStartAll
            // 
            this.btnStartAll.Location = new System.Drawing.Point(936, 11);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(75, 23);
            this.btnStartAll.TabIndex = 29;
            this.btnStartAll.Text = "Start all";
            this.btnStartAll.UseVisualStyleBackColor = true;
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);
            // 
            // btnStopAll
            // 
            this.btnStopAll.Location = new System.Drawing.Point(1017, 11);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.Size = new System.Drawing.Size(75, 23);
            this.btnStopAll.TabIndex = 30;
            this.btnStopAll.Text = "Stop all";
            this.btnStopAll.UseVisualStyleBackColor = true;
            this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 681);
            this.Controls.Add(this.btnStopAll);
            this.Controls.Add(this.btnStartAll);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.btnJAVAStopAgent);
            this.Controls.Add(this.btnJAVAStartAgent);
            this.Controls.Add(this.btnJAVAStopGateway);
            this.Controls.Add(this.btnJAVAStartGateway);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnStartService);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Button btnJAVAStartGateway;
        private System.Windows.Forms.Button btnJAVAStopGateway;
        private System.Windows.Forms.Button btnJAVAStartAgent;
        private System.Windows.Forms.Button btnJAVAStopAgent;
        private System.Windows.Forms.RichTextBox rtbLogAgent;
        private System.Windows.Forms.RichTextBox rtbLogAdapter;
        private System.Windows.Forms.RichTextBox rtbErrorAgent;
        private System.Windows.Forms.RichTextBox rtbErrorGateway;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStartAll;
        private System.Windows.Forms.Button btnStopAll;
    }
}

