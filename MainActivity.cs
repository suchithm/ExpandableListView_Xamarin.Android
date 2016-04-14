using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace ExpandableListViewSample
{
	[Activity (Label = "ExpandableListView", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{ 
		
		ExpandableListAdapter listAdapter;
		ExpandableListView expListView;
		List<string> listDataHeader;
		Dictionary<string, List<string>> listDataChild;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
 
			SetContentView (Resource.Layout.Main); 
			expListView = FindViewById<ExpandableListView>(Resource.Id.lvExp);

			// Prepare list data
			FnGetListData();

			//Bind list
			listAdapter = new ExpandableListAdapter(this, listDataHeader, listDataChild); 
			expListView.SetAdapter (listAdapter); 

			FnClickEvents();
		}
		void FnClickEvents()
		{ 
			expListView.ChildClick+= delegate(object sender, ExpandableListView.ChildClickEventArgs e) {
				Toast.MakeText(this,"child clicked",ToastLength.Short).Show();
			};
			expListView.GroupExpand += delegate(object sender, ExpandableListView.GroupExpandEventArgs e) {
				Toast.MakeText(this,"group expanded",ToastLength.Short).Show();
			};
			expListView.GroupCollapse+= delegate(object sender, ExpandableListView.GroupCollapseEventArgs e) {
				Toast.MakeText(this,"group collapsed",ToastLength.Short).Show();
			}; 

		}
		 void FnGetListData() {
			listDataHeader = new List<string>();
			listDataChild = new Dictionary<string, List<string>>();

			// Adding child data
			listDataHeader.Add("Computer science");
			listDataHeader.Add("Electrocs & comm.");
			listDataHeader.Add("Mechanical");

			// Adding child data
			List<string> lstCS = new List<string>();
			lstCS.Add("Data structure");
			lstCS.Add("C# Programming");
			lstCS.Add("Java programming");
			lstCS.Add("ADA");
			lstCS.Add("Operation reserach");
			lstCS.Add("OOPS with C");
			lstCS.Add("C++ Programming");

			List<string> lstEC = new List<string>();
			lstEC.Add("Field Theory");
			lstEC.Add("Logic Design");
			lstEC.Add("Analog electronics");
			lstEC.Add("Network analysis");
			lstEC.Add("Micro controller");
			lstEC.Add("Signals and system");

			List<string> lstMech = new List<string>();
			lstMech.Add("Instrumentation technology");
			lstMech.Add("Dynamics of machinnes");
			lstMech.Add("Energy engineering");
			lstMech.Add("Design of machine");
			lstMech.Add("Turbo machine");
			lstMech.Add("Energy conversion");

			listDataChild.Add(listDataHeader[0], lstCS); // Header, Child data
			listDataChild.Add(listDataHeader[1], lstEC);
			listDataChild.Add(listDataHeader[2], lstMech);
		}
	}
}


