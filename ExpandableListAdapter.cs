﻿using System;
using Android.Widget;
using System.Collections.Generic;
using Android.App;
using Android.Views;

namespace ExpandableListViewSample
{
	public class ExpandableListAdapter :BaseExpandableListAdapter
	{
		private Activity _context;
		private List<string> _listDataHeader; // header titles
		// child data in format of header title, child title
		private Dictionary<string, List<string>> _listDataChild;

		public ExpandableListAdapter(Activity context, List<string> listDataHeader,Dictionary<String, List<string>> listChildData) {
			this._context = context;
			this._listDataHeader = listDataHeader;
			this._listDataChild = listChildData;
		}
 
		public override Java.Lang.Object GetChild (int groupPosition, int childPosition)
		{ 
			return _listDataChild[_listDataHeader[groupPosition]][childPosition];
		} 
		public override long GetChildId (int groupPosition, int childPosition)
		{
			return childPosition;
		} 

		public override View GetChildView (int groupPosition, int childPosition, bool isLastChild, View convertView,ViewGroup parent)
		{ 
			 string childText = (string) GetChild(groupPosition, childPosition);
			if (convertView == null) {
				convertView = _context.LayoutInflater.Inflate (Resource.Layout.ListItemCustomLayout,null); 
			}
			TextView  txtListChild = (TextView) convertView.FindViewById(Resource.Id.lblListItem);
			txtListChild.Text=childText;
			return convertView;
		} 
		public override int GetChildrenCount (int groupPosition)
		{ 
			return _listDataChild [_listDataHeader [groupPosition]].Count; 
		} 
		public override Java.Lang.Object GetGroup (int groupPosition)
		{
			return _listDataHeader[groupPosition];
		}  
		public override int GroupCount {
			get {
				return _listDataHeader.Count;
			}
		}  
		public override long GetGroupId (int groupPosition)
		{
			return groupPosition;
		} 
		public override View GetGroupView (int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
		{
			string headerTitle = (string) GetGroup(groupPosition);
			if (convertView == null) { 
				convertView =_context.LayoutInflater.Inflate(Resource.Layout.HeaderCustomLayout,null); //infalInflater.inflate(R.layout.list_group, null);
			}

			TextView lblListHeader = (TextView)convertView.FindViewById (Resource.Id.lblListHeader); 
			lblListHeader.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
			lblListHeader.Text=headerTitle;

			return convertView;
		} 
		public override bool HasStableIds {
			get {
				return false;
			}
		} 
		public override bool IsChildSelectable (int groupPosition, int childPosition)
		{
			return true;
		} 

		class ViewHolderItem :Java.Lang.Object
		{
		}
	}
}

