// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace YoutubeDownder
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSTextField savePathInput { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTableView tasksTableView { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField urlInput { get; set; }

		[Outlet]
		MonoMac.AppKit.NSComboBox videoInfos { get; set; }

		[Action ("clickParseButtonHandler:")]
		partial void clickParseButtonHandler (MonoMac.Foundation.NSObject sender);

		[Action ("clickStartButtonHandler:")]
		partial void clickStartButtonHandler (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (savePathInput != null) {
				savePathInput.Dispose ();
				savePathInput = null;
			}

			if (urlInput != null) {
				urlInput.Dispose ();
				urlInput = null;
			}

			if (videoInfos != null) {
				videoInfos.Dispose ();
				videoInfos = null;
			}

			if (tasksTableView != null) {
				tasksTableView.Dispose ();
				tasksTableView = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
