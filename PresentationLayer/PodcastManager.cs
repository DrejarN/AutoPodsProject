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

namespace PresentationLayer
{
    public partial class Form1 : Form
    {

        EntityHandler eHandler = new EntityHandler();
        PodcastHandler pHandler = new PodcastHandler();
        SerializerService serializer = new SerializerService();
        public Form1()
        {
            InitializeComponent();
            CategoryList.DataSource = pHandler.FillCategoryList();
            categoryCb.DataSource = eHandler.fillCategoryDropBox();
            frequencyCb.DataSource = pHandler.testMetod();
            FillPodcastFeed();
            pHandler.StartTimers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Doin a lil test
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

        private void AddPodcastBtn_Click(object sender, EventArgs e)
        {
            pHandler.addPodcast(urlInput.Text, categoryCb.Text, frequencyCb.Text);
        }

        private void UpdatePodcastBtn_Click(object sender, EventArgs e)
        {
            eHandler.ChangePodcastFromList(PodcastFeed.SelectedItems[0].Text, urlInput.Text, frequencyCb.Text, categoryCb.Text);

        }

        private void NewCategoryBtn_Click(object sender, EventArgs e)
        {
            String input = categoryInput.Text;
            eHandler.AddNewCategoryToList(input);
            categoryInput.Clear();
            CategoryList.DataSource = pHandler.FillCategoryList();
        }

        private void RemovePodcastBtn_Click(object sender, EventArgs e)
        {
             eHandler.RemovePodcastFromList(PodcastFeed.SelectedItems[0].Text);
        }

        private void RemoveCategoryBtn_Click(object sender, EventArgs e)
        {
            eHandler.RemoveCategoryFromList(CategoryList.SelectedItem.ToString());
            CategoryList.DataSource = pHandler.FillCategoryList();
        }

        private void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveCategoryBtn_Click(object sender, EventArgs e)
        {
            eHandler.ChangeCategoryFromList(CategoryList.SelectedItem.ToString(), categoryInput.Text);
            CategoryList.DataSource = pHandler.FillCategoryList();
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
            List<Podcast> podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
            foreach (Podcast pod in podcasts)
            {
                string[] listToArray = { pod.episodeCount.ToString(), pod.Title, pod.UpdateFrequency, pod.categories.CategoryName };
                string[] row1 = { listToArray[0], listToArray[2], listToArray[3] };
                PodcastFeed.Items.Add(listToArray[1]).SubItems.AddRange(row1);
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PodcastFeed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }

}

