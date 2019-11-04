﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Logic;
using SharedModels;
using System.Threading;
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
            CategoryList.DataSource = cHandler.FillCategoryList();
            categoryCb.DataSource = cHandler.FillCategoryList();
            frequencyCb.DataSource = cHandler.AllowedUpdateFrequencyList();
            FillPodcastFeed();
            starttimers2();
            starttimers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Doin a lil test
        }

        public void starttimers2()
        {
            List<Podcast> pList = pHandler.getPodList();
            foreach (Podcast pod in pList)
            {
                tService.StartTimer(pod);
            }
        }
        public void starttimers()
        {
            List<Podcast> pList = pHandler.getPodList();
            foreach(Podcast pod in pList)
            {
                tService.StartFeedTimer(pod);
            }
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void EpisodeDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private async void AddPodcastBtn_Click(object sender, EventArgs e)
        {
            await pHandler.addPodcast(urlInput.Text, categoryCb.Text, frequencyCb.Text);
            PodcastFeed.Items.Clear();
            FillPodcastFeed();
        }

        private void UpdatePodcastBtn_Click(object sender, EventArgs e)
        {
            pHandler.ChangePodcastFromList(PodcastFeed.SelectedItems[0].Text, urlInput.Text, frequencyCb.Text, categoryCb.Text);

        }

        private void NewCategoryBtn_Click(object sender, EventArgs e)
        {
            String input = categoryInput.Text;
            cHandler.AddNewCategoryToList(input);
            categoryInput.Clear();
            CategoryList.DataSource = cHandler.FillCategoryList();
            categoryCb.DataSource = cHandler.FillCategoryList();
        }

        private void RemovePodcastBtn_Click(object sender, EventArgs e)
        {
            pHandler.RemovePodcastFromList(PodcastFeed.SelectedItems[0].Text);
            episodeDesc.Clear();
            episodeList.Items.Clear();
            FillPodcastFeed();
        }

        private void RemoveCategoryBtn_Click(object sender, EventArgs e)
        {
            cHandler.RemoveCategoryFromList(CategoryList.SelectedItem.ToString());
            CategoryList.DataSource = cHandler.FillCategoryList();
            categoryCb.DataSource = cHandler.FillCategoryList();
        }

        private void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveCategoryBtn_Click(object sender, EventArgs e)
        {
            cHandler.ChangeCategoryFromList(CategoryList.SelectedItem.ToString(), categoryInput.Text);
            CategoryList.DataSource = cHandler.FillCategoryList();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void categoryCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frequencyCb_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void PodcastFeed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

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
    }

}

