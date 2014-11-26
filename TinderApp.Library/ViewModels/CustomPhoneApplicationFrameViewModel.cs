﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TinderApp.Library.MVVM;

namespace TinderApp.Library.ViewModels
{
    public class CustomPhoneApplicationFrameViewModel : ObservableObject
    {
        private Boolean _topBarVisible = false;

        public ImageBrush ProfileImageBrush
        {
            get
            {
                if (TinderSession.CurrentSession != null && TinderSession.CurrentSession.IsAuthenticated)
                    return new ImageBrush() { ImageSource = new BitmapImage(new Uri(String.Format("https://graph.facebook.com/me/picture?access_token={0}&height=60&width=60", TinderSession.CurrentSession.FbSessionInfo.FacebookToken))) };
                return null;
            }
        }

        public Visibility TopBarVisibility
        {
            get
            {
                if (_topBarVisible)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public Boolean TopBarVisible
        {
            get
            {
                return _topBarVisible;
            }
            set
            {
                _topBarVisible = value;
                base.RaisePropertyChanged("TopBarVisibility");
            }
        }

        public void ProfileImageBrushChanged()
        {
            base.RaisePropertyChanged("ProfileImageBrush");
        }
    }
}