﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CameraLiveFeed.Core.Controls
{
    /// <summary>
    /// Interaction logic for WaterMarkTextBox.xaml
    /// </summary>
    public partial class WaterMarkTextBox : UserControl, INotifyPropertyChanged
    {
        #region Const Fields
        private const int _ancestorType = 1;
        #endregion

        #region Dependency Properties
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(WaterMarkTextBox), new PropertyMetadata(string.Empty));

        public string HintText
        {
            get { return (string)GetValue(HintTextProperty); }
            set { SetValue(HintTextProperty, value); }
        }
        public static readonly DependencyProperty HintTextProperty =
            DependencyProperty.Register("HintText", typeof(string), typeof(WaterMarkTextBox),
                new PropertyMetadata(string.Empty, new PropertyChangedCallback(HintTextPropertyChanged)));

        public ICommand TextChangedCommand
        {
            get { return (ICommand)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }

        public static readonly DependencyProperty TextChangedCommandProperty =
            DependencyProperty.Register(nameof(TextChangedCommand), typeof(ICommand), typeof(WaterMarkTextBox), new UIPropertyMetadata(null));
        #endregion

        #region Ctor
        public WaterMarkTextBox()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private static void HintTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is WaterMarkTextBox watermarkTextBox)
                watermarkTextBox.OnHintTextPropertyChanged(e);
        }

        private void OnHintTextPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            this.txtBlock.Text = e.NewValue.ToString();
        }

        private void TxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangedCommand?.Execute(sender);
        }
        #endregion

        #region INotofyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
