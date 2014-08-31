﻿#if TEMPLATE // To add a page view class: in the Visual Studio Package Manager Console (menu View | Other Windows), enter "New-View". Alternatively: copy this file, then in the copy remove the enclosing #if TEMPLATE ... #endif lines and replace _APPNAME_ and _VIEWNAME_ with the application and view names.
using Microsoft.Phone.Controls;
using MvvmQuickCrossLibrary.Templates;

namespace MvvmQuickCross.Templates
{
    public partial class _VIEWNAME_View : PhoneApplicationPage
    {
        public _VIEWNAME_View()
        {
            InitializeComponent();
            DataContext = _APPNAME_Application.Instance._VIEWNAME_ViewModel;
        }
    }
}
#endif // TEMPLATE