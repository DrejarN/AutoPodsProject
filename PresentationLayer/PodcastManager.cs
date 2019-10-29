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
        public Form1()
        {
            InitializeComponent();

        }

        public string TextBoxValue
        {
            set
            {
                episodeDesc.Text = value;
            }
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

        private void episodeDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void addPodcastBtn_Click(object sender, EventArgs e)
        {
            episodeDesc.AppendText(PodcastHandler.GetPodcastFeed().ToString());
        }

        private void updatePodcastBtn_Click(object sender, EventArgs e)
        {
            SerializerService.SerializerPodcastfeed();
        }

        private void newCategoryBtn_Click(object sender, EventArgs e)
        {
            String input = categoryInput.Text;
           // EntityHandler.CreateNewCategory(input);
            categoryInput.Clear();
        }

        private void removePodcastBtn_Click(object sender, EventArgs e)
        {
            eHandler.testMetod();
        }

        private void removeCategoryBtn_Click(object sender, EventArgs e)
        {
            eHandler.testMetod2();
        }
    }

}

