﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace CameraLiveFeed.Core.Adorners
{
    public class WatermarkAdorner : Adorner
    {
        #region Fields
        private readonly ContentPresenter contentPresenter;
        #endregion

        #region Ctor
        public WatermarkAdorner(UIElement adornedElement, object watermark) :
           base(adornedElement)
        {
            this.IsHitTestVisible = false;

            this.contentPresenter = new ContentPresenter
            {
                Content = watermark,
                Margin = new Thickness(Control.Margin.Left + Control.Padding.Left, Control.Margin.Top + Control.Padding.Top, 0, 0)
            };

            if (this.Control is ItemsControl && !(this.Control is ComboBox))
            {
                this.contentPresenter.VerticalAlignment = VerticalAlignment.Center;
                this.contentPresenter.HorizontalAlignment = HorizontalAlignment.Center;
            }

            Binding binding = new Binding("IsVisible");
            binding.Source = adornedElement;
            binding.Converter = new BooleanToVisibilityConverter();
            this.SetBinding(VisibilityProperty, binding);
        }
        #endregion

        #region Protected Properties
        protected override int VisualChildrenCount
        {
            get { return 1; }
        }
        #endregion

        #region Private Properties
        private Control Control
        {
            get { return (Control)this.AdornedElement; }
        }
        #endregion

        #region Protected Overrides
        protected override Visual GetVisualChild(int index)
        {
            return this.contentPresenter;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            // Here's the secret to getting the adorner to cover the whole control
            this.contentPresenter.Measure(Control.RenderSize);
            return Control.RenderSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            this.contentPresenter.Arrange(new Rect(finalSize));
            return finalSize;
        }
        #endregion
    }
}
