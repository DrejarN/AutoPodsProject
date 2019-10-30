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
            //var header1 = categoryList.Columns.Add("Categories", -2, HorizontalAlignment.Left);
            //FillPodcastFeed();
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
            episodeDesc.AppendText(PodcastHandler.GetPodcastFeed().ToString());
        }

        private void UpdatePodcastBtn_Click(object sender, EventArgs e)
        {
            //SerializerService.SerializerPodcastfeed();
        }

        private void NewCategoryBtn_Click(object sender, EventArgs e)
        {
            String input = categoryInput.Text;
            eHandler.AddNewCategoryToList(input);
            categoryInput.Clear();
        }

        private void RemovePodcastBtn_Click(object sender, EventArgs e)
        {
            eHandler.testMetod();
        }

        private void RemoveCategoryBtn_Click(object sender, EventArgs e)
        {
            eHandler.testMetod2();
        }

        private void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveCategoryBtn_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = pHandler.FillCategoryList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

