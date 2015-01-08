using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Eventarin.Core.ViewModels;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Eventarin.Core.Pages
{
    public partial class DashboardPage : BaseContentPage
    {
        DashboardViewModel viewModel;
        public DashboardPage()
        {
            InitializeComponent();
            viewModel = App.SimpleIoC.Resolve<DashboardViewModel>();
            BindingContext = viewModel;


            this.ToolbarItems.Add(new ToolbarItem
            {
                Text = "Refresh",
                Icon = "reload.png",
                Command = viewModel.RefreshCommand
            });

            ListSessions.ItemSelected += (sender, e) =>
            {
                viewModel.SessionItemClicked.Execute(null);
            };
            
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            viewModel.RefreshCommand.Execute(null);
        }
    }
}

