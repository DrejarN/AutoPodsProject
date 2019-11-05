using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Logic;
using SharedModels;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {

        CategoryHandler cHandler = new CategoryHandler();
        PodcastHandler pHandler = new PodcastHandler();
        SerializerService serializer = new SerializerService();
        Validation validate = new Validation();
        TimerService tService = new TimerService();
        public Form1()
        {
            InitializeComponent();
            CreateDirectory();
            CategoryList.DataSource = cHandler.FillCategoryList();
            categoryCb.DataSource = cHandler.FillCategoryList();
            frequencyCb.DataSource = cHandler.AllowedUpdateFrequencyList();
            FillPodcastFeed();
            StartTimers2();
            StartTimers();
        }


        public void StartTimers2()
        {
            List<Podcast> pList = pHandler.getPodList();
            foreach (Podcast pod in pList)
            {
                tService.StartTimer(pod);
            }
        }
        public void StartTimers()
        {
            List<Podcast> pList = pHandler.getPodList();
            foreach(Podcast pod in pList)
            {
                tService.StartFeedTimer(pod);
            }
        }

        private async void AddPodcastBtn_Click(object sender, EventArgs e)
        {
            string input = urlInput.Text;
            if (validate.IfFeedIsValidFormat(input)) {
                await pHandler.addPodcast(urlInput.Text, categoryCb.Text, frequencyCb.Text);
                PodcastFeed.Items.Clear();
                FillPodcastFeed();
            } else
            {
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show("The URL does not contain a valid RSS feed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdatePodcastBtn_Click(object sender, EventArgs e) //Ska valideras
        {
            string input = urlInput.Text;

            if(validate.IfItemNotSelected(PodcastFeed.SelectedItems.Count))
            { 
                if (validate.IfFeedIsValidFormat(input))
                {
                    pHandler.ChangePodcastFromList(PodcastFeed.SelectedItems[0].Text, urlInput.Text, frequencyCb.Text, categoryCb.Text);
                    FillPodcastFeed();
                } else
                {
                    using (new CenterWinDialog(this))
                    {
                        MessageBox.Show("You must enter the old or new URL for the podcast.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            } else
            {
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show("You must select a podcast to change it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RemovePodcastBtn_Click(object sender, EventArgs e)
        {
            if (validate.IfItemNotSelected(PodcastFeed.SelectedItems.Count))
            {
                Podcast RemovedPod = pHandler.RemovePodcastFromList(PodcastFeed.SelectedItems[0].Text);
                if (RemovedPod.updateTimer != null) {
                    tService.StopTimer(RemovedPod);
                }
                episodeDesc.Clear();
                episodeList.Items.Clear();
                FillPodcastFeed();
            }
            else
            {
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show("You must select a podcast to remove it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NewCategoryBtn_Click(object sender, EventArgs e)
        {
            String input = categoryInput.Text;

            if (validate.IfStringFieldEmpty(input))
            {
                cHandler.AddNewCategoryToList(input);
                categoryInput.Clear();
                CategoryList.DataSource = cHandler.FillCategoryList();
                categoryCb.DataSource = cHandler.FillCategoryList();
            }
            else
            {
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show("Text field cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SaveCategoryBtn_Click(object sender, EventArgs e)
        {
            string input = categoryInput.Text;
            if(validate.IfStringFieldEmpty(input))
            {
                cHandler.ChangeCategoryFromList(CategoryList.SelectedItem.ToString(), input);
                CategoryList.DataSource = cHandler.FillCategoryList();
                categoryInput.Clear();
            }
            else
            {
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show("You must enter a new category name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void RemoveCategoryBtn_Click(object sender, EventArgs e)
        {
            if (validate.IfItemNotSelected(CategoryList.Items.Count))
            {
                cHandler.RemoveCategoryFromList(CategoryList.SelectedItem.ToString());
                CategoryList.DataSource = cHandler.FillCategoryList();
                categoryCb.DataSource = cHandler.FillCategoryList();
            } else
            {
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show("No category selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          
        }
        private void SortByCategory_Click(object sender, EventArgs e)
        {
            PodcastFeed.Items.Clear();
            List<Podcast> podcasts = pHandler.SortPodcastsByCategory(categoryCb.Text);
            foreach (Podcast pod in podcasts)
            {
                string[] listToArray = { pod.episodeCount.ToString(), pod.Title, pod.UpdateFrequency, pod.categories.CategoryName };
                string[] row1 = { listToArray[0], listToArray[2], listToArray[3] };
                PodcastFeed.Items.Add(listToArray[1]).SubItems.AddRange(row1);
            }
        }

        public void FillPodcastFeed()
        {
            PodcastFeed.Items.Clear();
            if (validate.IfFileExists(@"C:\podFeeds\poddar.txt"))
            {
                List<Podcast> podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
                foreach (Podcast pod in podcasts)
                {
                    string[] listToArray = { pod.episodeCount.ToString(), pod.Title, pod.UpdateFrequency, pod.categories.CategoryName };
                    string[] row1 = { listToArray[0], listToArray[2], listToArray[3] };
                    PodcastFeed.Items.Add(listToArray[1]).SubItems.AddRange(row1);
                }
            }
        }

        private void PodcastFeed_Click(object sender, EventArgs e)
        {
            episodeList.Items.Clear();
            
            List<Podcast> podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");

            string selItem = PodcastFeed.SelectedItems[0].Text;

            foreach (Podcast podcast in podcasts)
            {
                if (podcast.Title == selItem)
                {
                    List<Episode> x = podcast.Episodes;
                    foreach (Episode episode in x)
                    {
                        string[] listToArray = { episode.Name };
                        episodeList.Items.Add(listToArray[0]);
                    }
                }
            }
        }

        private void episodeList_Click(object sender, EventArgs e)
        {
            episodeDesc.Clear();

            List<Podcast> podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");

            string selItem = PodcastFeed.SelectedItems[0].Text;

            foreach (Podcast podcast in podcasts)
            {
                if (podcast.Title == selItem)
                {
                    List<Episode> x = podcast.Episodes;
                    foreach (Episode episode in x)
                    {
                        if (episode.Name == episodeList.SelectedItems[0].Text)
                        {
                            episodeDesc.Text = episode.Description;
                        }
                    }
                }
            }
        }

        public void CreateDirectory()
        {
            if (!System.IO.Directory.Exists(@":C\podFeeds"))
            {
                System.IO.Directory.CreateDirectory(@"C:\podFeeds");
            }
        }
    }
}

