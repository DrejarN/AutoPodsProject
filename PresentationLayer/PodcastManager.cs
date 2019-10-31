using System;
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
using Data;
using Logic;

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
           // pHandler.TestMethod();
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
             eHandler.RemovePodcastFromList("http://businesspodden.libsyn.com/rss");
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

        private void TestBtn_Click(object sender, EventArgs e)
        {
            if(pHandler.CheckPodcasts())
            {
                var result = pHandler.FillPodcastFeed();
                string[] listToArray = result.ToArray();

                string[] row1 = { listToArray[1], listToArray[2], listToArray[3] };
                PodcastFeed.Items.Add(listToArray[0]).SubItems.AddRange(row1);

            }
          


            //List<string> list = pHandler.FillPodcastFeed();



        }

        private void categoryCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frequencyCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

