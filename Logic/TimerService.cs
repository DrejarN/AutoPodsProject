using System;
using System.Timers;

using SharedModels;


namespace Logic
{
    public class TimerService
    {
        PodcastHandler pHandler = new PodcastHandler();
        Validation validator = new Validation();

        public void StartTimer(Podcast podcast)
        {
            Timer updateTimer = new Timer();
            podcast.updateTimer = updateTimer;
            updateTimer.Stop();
            updateTimer.Start();

            updateTimer.Elapsed += (sender, e) => TimerElapsedHandler(sender, e, podcast);
            updateTimer.Interval = Int32.Parse(podcast.UpdateFrequency) * 6000;
            updateTimer.Enabled = true;
            updateTimer.AutoReset = true;
        }

        public void StopTimer(Podcast podcast)
        {
            Timer timer = podcast.updateTimer;
            timer.Stop();
        }
        public void StartFeedTimer(Podcast podcast)
        {
            StopTimer(podcast);
            StartTimer(podcast);
        }
        public void TimerElapsedHandler(object sender, ElapsedEventArgs e, Podcast podcast)
        {
            if(validator.IfFileExists(@"C:\podFeeds\poddar.txt"))
            { 
                pHandler.UpdateEpisodes(podcast.Url);
            }
            else 
            {
                StopTimer(podcast);
            }
        }
    }
}
