using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Thread.CurrentThread.Name = "Main UI Thread";
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SchedulingObseveOn1();
            SchedulingObseveOn2();
        }

        private void SchedulingObseveOn2()
        {
            var observable = Observable.Interval(TimeSpan.FromSeconds(.5));
            observable.ObserveOnDispatcher()
                .Subscribe(i => ResultLabel.Content = i);
        }

        private void SchedulingObseveOn1()
        {
            var timer = new System.Timers.Timer(1000);
            var observable = Observable.FromEventPattern<ElapsedEventArgs>
                (timer, "Elapsed");
            //observable.Subscribe(ie => Console.WriteLine(ie.EventArgs.SignalTime));
            timer.Start(); // Timer fires notifications

            // Observe and print
            observable
                //.ObserveOn(Dispatcher.CurrentDispatcher)
                .ObserveOnDispatcher()
                .Subscribe(i => ResultLabel.Content = string.Format("{0} - {1}", i.EventArgs.SignalTime,
                    Thread.CurrentThread.Name));
        }

    }
}
