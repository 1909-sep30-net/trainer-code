using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Delegates
{
    public class MoviePlayer
    {
        public string CurrentMovie { get; set; }

        // events are entities that work on a publish-subscribe idea
        // C# lets you subscribe event handler delegates to events.

        // the type for handling the event:
        public delegate void MovieFinishedHandler();
        // defines a delegate type for void-return and zero-parameters.
        // this describes the shape of functions that can subscribe to this event i'm about to define.

        // the event member, one distinct event per instance of this class
        public event MovieFinishedHandler MovieFinished;

        public void PlayMovie()
        {
            Console.WriteLine($"Playing movie {CurrentMovie}");

            Thread.Sleep(3000); // wait for 3 seconds

            // fire the event. (the syntax looks just like calling a method)
            // what it effectively does is call all the subscribing delegates

            // weird issue - if there are no subscribers, the event is kind of "null"
            //if (MovieFinished != null)
            //{
            //    MovieFinished();
            //}
            MovieFinished?.Invoke(); // does same thing as above code - do nothing if no subscribers
        }
    }
}
