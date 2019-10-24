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
            this.podcastList = new System.Windows.Forms.ListView();
            this.categoryList = new System.Windows.Forms.ListView();
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
            this.Avsnitt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Namn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Frekvens = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kategori = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // podcastList
            // 
            this.podcastList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Avsnitt,
            this.Namn,
            this.Frekvens,
            this.Kategori});
            this.podcastList.HideSelection = false;
            this.podcastList.Location = new System.Drawing.Point(12, 34);
            this.podcastList.Name = "podcastList";
            this.podcastList.Size = new System.Drawing.Size(489, 130);
            this.podcastList.TabIndex = 0;
            this.podcastList.UseCompatibleStateImageBehavior = false;
            this.podcastList.View = System.Windows.Forms.View.Details;
            // 
            // categoryList
            // 
            this.categoryList.HideSelection = false;
            this.categoryList.Location = new System.Drawing.Point(549, 34);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(279, 130);
            this.categoryList.TabIndex = 1;
            this.categoryList.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(549, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kategorier";
            // 
            // categoryInput
            // 
            this.categoryInput.Location = new System.Drawing.Point(549, 195);
            this.categoryInput.Name = "categoryInput";
            this.categoryInput.Size = new System.Drawing.Size(279, 22);
            this.categoryInput.TabIndex = 3;
            // 
            // newCategoryBtn
            // 
            this.newCategoryBtn.Location = new System.Drawing.Point(549, 239);
            this.newCategoryBtn.Name = "newCategoryBtn";
            this.newCategoryBtn.Size = new System.Drawing.Size(88, 35);
            this.newCategoryBtn.TabIndex = 4;
            this.newCategoryBtn.Text = "Ny";
            this.newCategoryBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Uppdateringsfr.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kategori:";
            // 
            // urlInput
            // 
            this.urlInput.Location = new System.Drawing.Point(12, 216);
            this.urlInput.Name = "urlInput";
            this.urlInput.Size = new System.Drawing.Size(203, 22);
            this.urlInput.TabIndex = 10;
            // 
            // frequencyCb
            // 
            this.frequencyCb.FormattingEnabled = true;
            this.frequencyCb.Location = new System.Drawing.Point(237, 216);
            this.frequencyCb.Name = "frequencyCb";
            this.frequencyCb.Size = new System.Drawing.Size(121, 24);
            this.frequencyCb.TabIndex = 11;
            // 
            // categoryCb
            // 
            this.categoryCb.FormattingEnabled = true;
            this.categoryCb.Location = new System.Drawing.Point(380, 216);
            this.categoryCb.Name = "categoryCb";
            this.categoryCb.Size = new System.Drawing.Size(121, 24);
            this.categoryCb.TabIndex = 12;
            // 
            // saveCategoryBtn
            // 
            this.saveCategoryBtn.Location = new System.Drawing.Point(643, 239);
            this.saveCategoryBtn.Name = "saveCategoryBtn";
            this.saveCategoryBtn.Size = new System.Drawing.Size(88, 35);
            this.saveCategoryBtn.TabIndex = 13;
            this.saveCategoryBtn.Text = "Spara";
            this.saveCategoryBtn.UseVisualStyleBackColor = true;
            // 
            // removeCategoryBtn
            // 
            this.removeCategoryBtn.Location = new System.Drawing.Point(737, 239);
            this.removeCategoryBtn.Name = "removeCategoryBtn";
            this.removeCategoryBtn.Size = new System.Drawing.Size(88, 35);
            this.removeCategoryBtn.TabIndex = 14;
            this.removeCategoryBtn.Text = "Ta bort";
            this.removeCategoryBtn.UseVisualStyleBackColor = true;
            // 
            // addPodcastBtn
            // 
            this.addPodcastBtn.Location = new System.Drawing.Point(225, 266);
            this.addPodcastBtn.Name = "addPodcastBtn";
            this.addPodcastBtn.Size = new System.Drawing.Size(88, 35);
            this.addPodcastBtn.TabIndex = 15;
            this.addPodcastBtn.Text = "Lägg till";
            this.addPodcastBtn.UseVisualStyleBackColor = true;
            // 
            // updatePodcastBtn
            // 
            this.updatePodcastBtn.Location = new System.Drawing.Point(319, 266);
            this.updatePodcastBtn.Name = "updatePodcastBtn";
            this.updatePodcastBtn.Size = new System.Drawing.Size(88, 35);
            this.updatePodcastBtn.TabIndex = 16;
            this.updatePodcastBtn.Text = "Spara";
            this.updatePodcastBtn.UseVisualStyleBackColor = true;
            // 
            // removePodcastBtn
            // 
            this.removePodcastBtn.Location = new System.Drawing.Point(413, 266);
            this.removePodcastBtn.Name = "removePodcastBtn";
            this.removePodcastBtn.Size = new System.Drawing.Size(88, 35);
            this.removePodcastBtn.TabIndex = 17;
            this.removePodcastBtn.Text = "Ta bort";
            this.removePodcastBtn.UseVisualStyleBackColor = true;
            // 
            // episodeList
            // 
            this.episodeList.HideSelection = false;
            this.episodeList.Location = new System.Drawing.Point(13, 362);
            this.episodeList.Name = "episodeList";
            this.episodeList.Size = new System.Drawing.Size(488, 135);
            this.episodeList.TabIndex = 18;
            this.episodeList.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Podcast # Avsnitt";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // episodeDesc
            // 
            this.episodeDesc.Location = new System.Drawing.Point(538, 321);
            this.episodeDesc.Multiline = true;
            this.episodeDesc.Name = "episodeDesc";
            this.episodeDesc.Size = new System.Drawing.Size(290, 176);
            this.episodeDesc.TabIndex = 20;
            // 
            // Avsnitt
            // 
            this.Avsnitt.Text = "Avsnitt";
            this.Avsnitt.Width = 103;
            // 
            // Namn
            // 
            this.Namn.Text = "Namn";
            this.Namn.Width = 113;
            // 
            // Frekvens
            // 
            this.Frekvens.Text = "Frekvens";
            this.Frekvens.Width = 147;
            // 
            // Kategori
            // 
            this.Kategori.Text = "Kategori";
            this.Kategori.Width = 121;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 509);
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
            this.Controls.Add(this.categoryList);
            this.Controls.Add(this.podcastList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView podcastList;
        private System.Windows.Forms.ListView categoryList;
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
        private System.Windows.Forms.ColumnHeader Avsnitt;
        private System.Windows.Forms.ColumnHeader Namn;
        private System.Windows.Forms.ColumnHeader Frekvens;
        private System.Windows.Forms.ColumnHeader Kategori;
    }
}

