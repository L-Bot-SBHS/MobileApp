﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LBot.Templates {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class snrDataView:ContentView {
        public snrDataView() {
            (Application.Current as App).libInfo.currentLibrary = "snr";
            InitializeComponent();
        }
    }
}