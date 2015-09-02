using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace PickupLib
{
    public class PickupHelper
    {
        Random _rng = new Random();
        List<string> _lines = new List<string>();
        List<string> _responses = new List<string>();

        public PickupHelper()
        {
            _lines.Add("Can I buy you a drink?");
            _lines.Add("Didn't we go out a couple times?");
            _lines.Add("Where have you been all my life?");
            _lines.Add("Do you want to ask me out?");
            _lines.Add("Haven't I seen you somewhere before?");
            _lines.Add("Where have you been all my life?");
            
            _responses.Add("I'd rather have the money.");
            _responses.Add("Nope, I never make the same mistake twice.");
            _responses.Add("Hiding from guys like you.");
            _responses.Add("Yes, please get out.");
            _responses.Add("Yes, that's why I don't go there anymore.");
            _responses.Add("For the first half of it, I probably wasn’t born yet.");
        }

        public int LineCount
        {
            get { return _lines.Count; }
        }

        public string GetLine(int index)
        {
            return _lines[index];
        }

        public string GetResponse(int index)
        {
            int random = _rng.Next(_responses.Count * 2); // causes out of range exception
            string response = _responses[random];
            if (index == random)
	        {
                string excMsg = "That's the lamest pickup line I've ever heard!";
                throw new DrinkInYourFaceException(excMsg);
	        }
            return response;
        }

        public Task<string> GetLineAsync(int index)
        {
            int secs = _rng.Next(2);
            return Delay(secs).ContinueWith<string>(t => GetLine(index));
        }

        public Task<string> GetResponseAsync(int index)
        {
            int secs = _rng.Next(4);
            return Delay(secs).ContinueWith<string>(t => GetResponse(index));
        }

        private Task Delay(int seconds)
        {
            var tcs = new TaskCompletionSource<bool>();
            var timer = new Timer();
            timer.Elapsed += (obj, args) =>
            {
                tcs.TrySetResult(true);
            };
            if (seconds == 0) seconds = 1;
            timer.Interval = seconds * 1000;
            timer.AutoReset = false;
            timer.Start();
            return tcs.Task;
        }
    }
}
