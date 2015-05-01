// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace StarPrinterSample
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton PrintButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView PrintersTableView { get; set; }

		[Action ("PrintButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void PrintButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (PrintButton != null) {
				PrintButton.Dispose ();
				PrintButton = null;
			}
			if (PrintersTableView != null) {
				PrintersTableView.Dispose ();
				PrintersTableView = null;
			}
		}
	}
}
