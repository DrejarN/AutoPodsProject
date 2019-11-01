namespace PresentationLayer
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
            this.label1 = new System.Windows.Forms.Label();
            this.categoryInput = new System.Windows.Forms.TextBox();
            this.newCategoryBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.urlInput = new System.Windows.Forms.TextBox();
            this.frequencyCb = new System.Windows.Forms.ComboBox();
            this.categoryCb = new System.Windows.Forms.ComboBox();
            this.saveCategoryBtn = new System.Windows.Forms.Button();
            this.removeCategoryBtn = new System.Windows.Forms.Button();
            this.addPodcastBtn = new System.Windows.Forms.Button();
            this.updatePodcastBtn = new System.Windows.Forms.Button();
            this.removePodcastBtn = new System.Windows.Forms.Button();
            this.episodeList = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.episodeDesc = new System.Windows.Forms.TextBox();
            this.CategoryList = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PodcastFeed = new System.Windows.Forms.ListView();
            this.Namn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Avsnitt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Frekvens = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kategori = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TestBtn = new System.Windows.Forms.Button();
            this.Avsnittnamn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.episodeDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kategorier";
            // 
            // categoryInput
            // 
            this.categoryInput.Location = new System.Drawing.Point(407, 191);
            this.categoryInput.Margin = new System.Windows.Forms.Padding(2);
            this.categoryInput.Name = "categoryInput";
            this.categoryInput.Size = new System.Drawing.Size(210, 20);
            this.categoryInput.TabIndex = 3;
            // 
            // newCategoryBtn
            // 
            this.newCategoryBtn.Location = new System.Drawing.Point(410, 232);
            this.newCategoryBtn.Margin = new System.Windows.Forms.Padding(2);
            this.newCategoryBtn.Name = "newCategoryBtn";
            this.newCategoryBtn.Size = new System.Drawing.Size(66, 28);
            this.newCategoryBtn.TabIndex = 4;
            this.newCategoryBtn.Text = "Ny";
            this.newCategoryBtn.UseVisualStyleBackColor = true;
            this.newCategoryBtn.Click += new System.EventHandler(this.NewCategoryBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 174);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Uppdateringsfr.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 174);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kategori:";
            // 
            // urlInput
            // 
            this.urlInput.Location = new System.Drawing.Point(13, 191);
            this.urlInput.Margin = new System.Windows.Forms.Padding(2);
            this.urlInput.Name = "urlInput";
            this.urlInput.Size = new System.Drawing.Size(149, 20);
            this.urlInput.TabIndex = 10;
            // 
            // frequencyCb
            // 
            this.frequencyCb.FormattingEnabled = true;
            this.frequencyCb.Location = new System.Drawing.Point(178, 191);
            this.frequencyCb.Margin = new System.Windows.Forms.Padding(2);
            this.frequencyCb.Name = "frequencyCb";
            this.frequencyCb.Size = new System.Drawing.Size(92, 21);
            this.frequencyCb.TabIndex = 11;
            this.frequencyCb.SelectedIndexChanged += new System.EventHandler(this.frequencyCb_SelectedIndexChanged);
            // 
            // categoryCb
            // 
            this.categoryCb.FormattingEnabled = true;
            this.categoryCb.Location = new System.Drawing.Point(285, 191);
            this.categoryCb.Margin = new System.Windows.Forms.Padding(2);
            this.categoryCb.Name = "categoryCb";
            this.categoryCb.Size = new System.Drawing.Size(92, 21);
            this.categoryCb.TabIndex = 12;
            this.categoryCb.SelectedIndexChanged += new System.EventHandler(this.categoryCb_SelectedIndexChanged);
            // 
            // saveCategoryBtn
            // 
            this.saveCategoryBtn.Location = new System.Drawing.Point(480, 232);
            this.saveCategoryBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveCategoryBtn.Name = "saveCategoryBtn";
            this.saveCategoryBtn.Size = new System.Drawing.Size(66, 28);
            this.saveCategoryBtn.TabIndex = 13;
            this.saveCategoryBtn.Text = "Spara";
            this.saveCategoryBtn.UseVisualStyleBackColor = true;
            this.saveCategoryBtn.Click += new System.EventHandler(this.saveCategoryBtn_Click);
            // 
            // removeCategoryBtn
            // 
            this.removeCategoryBtn.Location = new System.Drawing.Point(551, 232);
            this.removeCategoryBtn.Margin = new System.Windows.Forms.Padding(2);
            this.removeCategoryBtn.Name = "removeCategoryBtn";
            this.removeCategoryBtn.Size = new System.Drawing.Size(66, 28);
            this.removeCategoryBtn.TabIndex = 14;
            this.removeCategoryBtn.Text = "Ta bort";
            this.removeCategoryBtn.UseVisualStyleBackColor = true;
            this.removeCategoryBtn.Click += new System.EventHandler(this.RemoveCategoryBtn_Click);
            // 
            // addPodcastBtn
            // 
            this.addPodcastBtn.Location = new System.Drawing.Point(169, 231);
            this.addPodcastBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addPodcastBtn.Name = "addPodcastBtn";
            this.addPodcastBtn.Size = new System.Drawing.Size(66, 28);
            this.addPodcastBtn.TabIndex = 15;
            this.addPodcastBtn.Text = "Lägg till";
            this.addPodcastBtn.UseVisualStyleBackColor = true;
            this.addPodcastBtn.Click += new System.EventHandler(this.AddPodcastBtn_Click);
            // 
            // updatePodcastBtn
            // 
            this.updatePodcastBtn.Location = new System.Drawing.Point(239, 231);
            this.updatePodcastBtn.Margin = new System.Windows.Forms.Padding(2);
            this.updatePodcastBtn.Name = "updatePodcastBtn";
            this.updatePodcastBtn.Size = new System.Drawing.Size(66, 28);
            this.updatePodcastBtn.TabIndex = 16;
            this.updatePodcastBtn.Text = "Spara";
            this.updatePodcastBtn.UseVisualStyleBackColor = true;
            this.updatePodcastBtn.Click += new System.EventHandler(this.UpdatePodcastBtn_Click);
            // 
            // removePodcastBtn
            // 
            this.removePodcastBtn.Location = new System.Drawing.Point(310, 231);
            this.removePodcastBtn.Margin = new System.Windows.Forms.Padding(2);
            this.removePodcastBtn.Name = "removePodcastBtn";
            this.removePodcastBtn.Size = new System.Drawing.Size(66, 28);
            this.removePodcastBtn.TabIndex = 17;
            this.removePodcastBtn.Text = "Ta bort";
            this.removePodcastBtn.UseVisualStyleBackColor = true;
            this.removePodcastBtn.Click += new System.EventHandler(this.RemovePodcastBtn_Click);
            // 
            // episodeList
            // 
            this.episodeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Avsnittnamn});
            this.episodeList.HideSelection = false;
            this.episodeList.Location = new System.Drawing.Point(10, 294);
            this.episodeList.Margin = new System.Windows.Forms.Padding(2);
            this.episodeList.Name = "episodeList";
            this.episodeList.Size = new System.Drawing.Size(367, 253);
            this.episodeList.TabIndex = 18;
            this.episodeList.UseCompatibleStateImageBehavior = false;
            this.episodeList.View = System.Windows.Forms.View.Details;
            this.episodeList.Click += new System.EventHandler(this.episodeList_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 275);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Podcast # Avsnitt";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // episodeDesc
            // 
            this.episodeDesc.Location = new System.Drawing.Point(404, 294);
            this.episodeDesc.Margin = new System.Windows.Forms.Padding(2);
            this.episodeDesc.Multiline = true;
            this.episodeDesc.Name = "episodeDesc";
            this.episodeDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.episodeDesc.Size = new System.Drawing.Size(218, 253);
            this.episodeDesc.TabIndex = 20;
            // 
            // CategoryList
            // 
            this.CategoryList.FormattingEnabled = true;
            this.CategoryList.Location = new System.Drawing.Point(472, 30);
            this.CategoryList.Name = "CategoryList";
            this.CategoryList.Size = new System.Drawing.Size(134, 134);
            this.CategoryList.TabIndex = 21;
            this.CategoryList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Podcast Feed";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // PodcastFeed
            // 
            this.PodcastFeed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Namn,
            this.Avsnitt,
            this.Frekvens,
            this.Kategori});
            this.PodcastFeed.HideSelection = false;
            this.PodcastFeed.Location = new System.Drawing.Point(16, 30);
            this.PodcastFeed.Name = "PodcastFeed";
            this.PodcastFeed.Size = new System.Drawing.Size(407, 134);
            this.PodcastFeed.TabIndex = 24;
            this.PodcastFeed.UseCompatibleStateImageBehavior = false;
            this.PodcastFeed.View = System.Windows.Forms.View.Details;
            this.PodcastFeed.Click += new System.EventHandler(this.PodcastFeed_Click);
            // 
            // Namn
            // 
            this.Namn.Text = "Namn";
            this.Namn.Width = 151;
            // 
            // Avsnitt
            // 
            this.Avsnitt.Text = "Avsnitt";
            this.Avsnitt.Width = 55;
            // 
            // Frekvens
            // 
            this.Frekvens.Text = "Frekvens";
            this.Frekvens.Width = 100;
            // 
            // Kategori
            // 
            this.Kategori.Text = "Kategori";
            this.Kategori.Width = 97;
            // 
            // TestBtn
            // 
            this.TestBtn.Location = new System.Drawing.Point(16, 235);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(75, 23);
            this.TestBtn.TabIndex = 25;
            this.TestBtn.Text = "TestBtn";
            this.TestBtn.UseVisualStyleBackColor = true;
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // Avsnittnamn
            // 
            this.Avsnittnamn.Text = "Avsnittnamn";
            this.Avsnittnamn.Width = 360;
            // 
            // episodeDescription
            // 
            this.episodeDescription.AutoSize = true;
            this.episodeDescription.Location = new System.Drawing.Point(404, 275);
            this.episodeDescription.Name = "episodeDescription";
            this.episodeDescription.Size = new System.Drawing.Size(101, 13);
            this.episodeDescription.TabIndex = 26;
            this.episodeDescription.Text = "Episode Description";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 579);
            this.Controls.Add(this.episodeDescription);
            this.Controls.Add(this.TestBtn);
            this.Controls.Add(this.PodcastFeed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CategoryList);
            this.Controls.Add(this.episodeDesc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.episodeList);
            this.Controls.Add(this.removePodcastBtn);
            this.Controls.Add(this.updatePodcastBtn);
            this.Controls.Add(this.addPodcastBtn);
            this.Controls.Add(this.removeCategoryBtn);
            this.Controls.Add(this.saveCategoryBtn);
            this.Controls.Add(this.categoryCb);
            this.Controls.Add(this.frequencyCb);
            this.Controls.Add(this.urlInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newCategoryBtn);
            this.Controls.Add(this.categoryInput);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox categoryInput;
        private System.Windows.Forms.Button newCategoryBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox urlInput;
        private System.Windows.Forms.ComboBox frequencyCb;
        private System.Windows.Forms.ComboBox categoryCb;
        private System.Windows.Forms.Button saveCategoryBtn;
        private System.Windows.Forms.Button removeCategoryBtn;
        private System.Windows.Forms.Button addPodcastBtn;
        private System.Windows.Forms.Button updatePodcastBtn;
        private System.Windows.Forms.Button removePodcastBtn;
        private System.Windows.Forms.ListView episodeList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox episodeDesc;
        private System.Windows.Forms.ListBox CategoryList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView PodcastFeed;
        private System.Windows.Forms.ColumnHeader Avsnitt;
        private System.Windows.Forms.ColumnHeader Namn;
        private System.Windows.Forms.ColumnHeader Frekvens;
        private System.Windows.Forms.ColumnHeader Kategori;
        private System.Windows.Forms.Button TestBtn;
        private System.Windows.Forms.ColumnHeader Avsnittnamn;
        private System.Windows.Forms.Label episodeDescription;
    }
}

