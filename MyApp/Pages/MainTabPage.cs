﻿using System;
using MyApp.PageModels;
using Xamarin.Forms;
using FreshMvvm;
using MyApp.Models;

namespace MyApp.Pages
{
    public class MainTabPage : TabbedPage
    {
        protected override void OnAppearing() {
            base.OnAppearing();

            if (!Loaded)
            {
                Loaded = true;

                var viewModel = BindingContext as MainTabPageModel;

                if (viewModel != null)
                {
                    var page1 = FreshPageModelResolver.ResolvePageModel(typeof(DashboardPageModel), (object)new User { FullName = "child 1" });
                    page1.Title = "Page 1";
                    Children.Add(page1);

                    var page2 = FreshPageModelResolver.ResolvePageModel(typeof(DashboardPageModel), (object)new User { FullName = "child 2" });
                    page2.Title = "Page 2";
                    Children.Add(page2);
                }
            }
        }

        protected internal bool Loaded { get; set; }
    }
}
