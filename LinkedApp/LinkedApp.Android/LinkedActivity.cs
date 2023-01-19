using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using LinkedApp.Models;
using Org.Apache.Http.Params;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using static Xamarin.Essentials.Platform;

namespace LinkedApp.Droid
{


    [Activity(Label = "LinkedActivity")]
    public class LinkedActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            var Data = Intent.Data.EncodedQuery;
            string uri = null;
            string DataFromPreferences=Preferences.Get("XASDAFASEWEQEQAC", "NoDataFound","SharedContainer");
            GetSharedPreferences("", FileCreationMode.Private);
            QueryParams parameters = new QueryParams();
            if (Data !=null)
            {
                SecureStorage.LegacyKeyHashFallback = false;
                parameters.SetParameterList(Data);
                string page = parameters.GetValueOf("page");
                if (page == "ItemsPage")
                {
                    uri = $"{nameof(Views.ItemsPage)}";
                }
                if (page == "NewItem")
                {
                    uri = $"{nameof(Views.NewItemPage)}";
                }
            }
            
        
        


         

            if(uri != null)
            {
                await AppShell.Current.GoToAsync(uri);

            }

         
        }
   


    }
}