using System;
using System.Collections.Generic;
using MonoMac.Foundation;
using MonoMac.AppKit;
using YoutubeExtractor;

namespace YoutubeDownder
{
	[Register ("TableViewDataSource")]
	public class DownloadingTableViewSource : NSTableViewDataSource
	{
		private List<VideoDownloader> downloaders;
		private NSTableView table;

		public DownloadingTableViewSource (NSTableView table)
		{
			downloaders = new List<VideoDownloader> ();
			this.table = table;
			table.DataSource = this;
		}

		[Export ("numberOfRowsInTableView:")]
		public int NumberOfRowsInTableView(NSTableView table)
		{
			return downloaders.Count;
		}

		// This method will be called by the control for each column and each row.
		[Export ("tableView:objectValueForTableColumn:row:")]
		public NSObject ObjectValueForTableColumn(NSTableView table, NSTableColumn col, int row)
		{
			var downloader = downloaders [row];
			if (col.Identifier == "type") {
				return new NSString (downloader.Video.VideoType.ToString());
			} else if (col.Identifier == "resolution") {
				return new NSString (downloader.Video.Resolution.ToString());
			} else if (col.Identifier == "title") {
				return new NSString (downloader.Video.Title);
			} else if (col.Identifier == "progress") {
				if(downloader.ProgressPercentage > 0)
					return new NSString (downloader.Completed ? "Finished" : 
					                     String.Format("{0:0.0}%", downloader.ProgressPercentage));
				return new NSString ("Pending");
			}
			return new NSString (downloaders[row].Video.Title);
		}

		public void Add(VideoDownloader downloader){
			downloaders.Add (downloader);
			var row = downloaders.Count - 1;
			downloader.DownloadProgressChanged += (sender, e) => {
				table.InvokeOnMainThread(new NSAction(() => table.ReloadData(new NSIndexSet(row), new NSIndexSet(3))));
			};
		}
	}
}

