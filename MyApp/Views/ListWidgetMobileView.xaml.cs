using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MyApp.Helpers;

namespace MyApp.Views
{
    public partial class ListWidgetMobileView : ContentView
    {
        public ListWidgetMobileView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty RecordProperty = BindableProperty.Create(
                                          "Record", //Public name to use
                                          typeof(object), //this type
            typeof(ListWidgetMobileView), //parent type (tihs control)
                                          null); //default value
        public object Record
        {
            get { return (object)GetValue(RecordProperty); }
            set { SetValue(RecordProperty, value); }
        }

        public static readonly BindableProperty TitlePropertyNameProperty = BindableProperty.Create(
                                          "TitlePropertyName", //Public name to use
                                          typeof(string), //this type
            typeof(ListWidgetMobileView), //parent type (tihs control)
                                          null); //default value
        public string TitlePropertyName
        {
            get { return (string)GetValue(TitlePropertyNameProperty); }
            set
            {
                SetValue(TitlePropertyNameProperty, value);
            }
        }

        public static readonly BindableProperty SubTitlePropertyNameProperty = BindableProperty.Create(
                                                  "SubTitlePropertyName", //Public name to use
                                                  typeof(string), //this type
            typeof(ListWidgetMobileView), //parent type (tihs control)
                                                  null); //default value
        public string SubTitlePropertyName
        {
            get { return (string)GetValue(SubTitlePropertyNameProperty); }
            set { SetValue(SubTitlePropertyNameProperty, value); }
        }

        public static readonly BindableProperty DetailPropertyNameProperty = BindableProperty.Create(
                                                  "DetailPropertyName", //Public name to use
                                                  typeof(string), //this type
            typeof(ListWidgetMobileView), //parent type (tihs control)
                                                  null); //default value
        public string DetailPropertyName
        {
            get { return (string)GetValue(DetailPropertyNameProperty); }
            set { SetValue(DetailPropertyNameProperty, value); }
        }

        public static readonly BindableProperty SubDetailPropertyNameProperty = BindableProperty.Create(
                                                  "SubDetailPropertyName", //Public name to use
                                                  typeof(string), //this type
            typeof(ListWidgetMobileView), //parent type (tihs control)
                                                  null); //default value

        public string SubDetailPropertyName
        {
            get { return (string)GetValue(SubDetailPropertyNameProperty); }
            set { SetValue(SubDetailPropertyNameProperty, value); }
        }

        public static readonly BindableProperty SummaryPropertyNameProperty = BindableProperty.Create(
                                                  "SummaryPropertyName", //Public name to use
                                                  typeof(string), //this type
            typeof(ListWidgetMobileView), //parent type (tihs control)
                                                  null); //default value

        public string SummaryPropertyName
        {
            get { return (string)GetValue(SummaryPropertyNameProperty); }
            set { SetValue(SummaryPropertyNameProperty, value); }
        }

        public static readonly BindableProperty SubTitleLabelPropertyNameProperty = BindableProperty.Create(
                                                  "SubTitleLabelPropertyName", //Public name to use
                                                  typeof(string), //this type
            typeof(ListWidgetMobileView), //parent type (tihs control)
                                                  null); //default value

        public string SubTitleLabelPropertyName
        {
            get { return (string)GetValue(SubTitleLabelPropertyNameProperty); }
            set { SetValue(SubTitleLabelPropertyNameProperty, value); }
        }

        public static readonly BindableProperty DetailLabelPropertyNameProperty = BindableProperty.Create(
                                                    "DetailLabelPropertyName", //Public name to use
                                                    typeof(string), //this type
            typeof(ListWidgetMobileView), //parent type (tihs control)
                                                    null); //default value

        public string DetailLabelPropertyName
        {
            get { return (string)GetValue(DetailLabelPropertyNameProperty); }
            set { SetValue(DetailLabelPropertyNameProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (TitlePropertyName != null)
            {
                title.SetBinding(Label.TextProperty, "Record." + StringUtils.UppercaseFirst(TitlePropertyName));
            }

            if (SubTitlePropertyName != null)
            {
                subTitle.SetBinding(Label.TextProperty, "Record." + StringUtils.UppercaseFirst(SubTitlePropertyName));
            }

            if (SubTitleLabelPropertyName != null)
            {
                subTitleLabel.SetBinding(Label.TextProperty, "Record." + StringUtils.UppercaseFirst(SubTitleLabelPropertyName));
            }

            if (DetailPropertyName != null)
            {
                detail.SetBinding(Label.TextProperty, "Record." + StringUtils.UppercaseFirst(DetailPropertyName));
            }

            if (DetailLabelPropertyName != null)
            {
                detailLabel.SetBinding(Label.TextProperty, "Record." + StringUtils.UppercaseFirst(DetailLabelPropertyName));
            }

            if (SubDetailPropertyName != null)
            {
                subDetail.SetBinding(Label.TextProperty, "Record." + StringUtils.UppercaseFirst(SubDetailPropertyName));
            }
        }
    }
}
