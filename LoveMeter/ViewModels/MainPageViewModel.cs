using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StyleMVVM.DependencyInjection;
using StyleMVVM.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;

namespace LoveMeter.ViewModels
{
	public class MainPageViewModel : PageViewModel
	{
        private string meterValue;
        public string MeterValue
        {
            get { return meterValue; }
            set 
            { 
                meterValue = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            MeterValue = "0";
            
            FullGrid = Visibility.Visible;
            SnapGrid = Visibility.Collapsed;

            InitView();


        }

        void InitView()
        {
            Window.Current.SizeChanged += OnSizeChanged;
        }

        protected override void OnNavigatedTo(object sender, StyleMVVM.View.StyleNavigationEventArgs e)
        {
            InitView();
            base.OnNavigatedTo(sender, e);
        }


        private void OnSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            // Obtain view state by explicitly querying for it
            if (Windows.UI.ViewManagement.ApplicationView.Value == ApplicationViewState.Snapped)
            {
                SnapGrid = Visibility.Visible;
                FullGrid = Visibility.Collapsed;
            }
            else
                if (Windows.UI.ViewManagement.ApplicationView.Value == ApplicationViewState.Filled || Windows.UI.ViewManagement.ApplicationView.Value == ApplicationViewState.FullScreenLandscape)
                {
                    SnapGrid = Visibility.Collapsed;
                    FullGrid = Visibility.Visible;
                }
        }



        private string mode;

        public string Mode
        {
            get { return mode; }
            set
            {
                mode = value;
                OnPropertyChanged("Mode");
            }
        }

        private Visibility fullGrid = Visibility.Visible;
        public Visibility FullGrid
        {
            get { return fullGrid; }
            set
            {
                fullGrid = value;
                OnPropertyChanged("FullGrid");
            }

        }

        private Visibility snapGrid = Visibility.Collapsed;
        public Visibility SnapGrid
        {
            get { return snapGrid; }
            set
            {
                snapGrid = value;
                OnPropertyChanged("SnapGrid");
            }
        }


        private void TryUnsnapView()
        {
            Windows.UI.ViewManagement.ApplicationView.TryUnsnap();
            SnapGrid = Visibility.Collapsed;
            FullGrid = Visibility.Visible;
        }

        

        private void RandomValueMethod()
        {
            Random rand = new Random();
            var dupa = rand.Next(1, 100);
            MeterValue = dupa.ToString();
        }
	}
}
