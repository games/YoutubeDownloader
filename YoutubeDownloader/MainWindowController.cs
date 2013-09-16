using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using MonoMac.Foundation;
using MonoMac.AppKit;
using YoutubeExtractor;

namespace YoutubeDownder
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		#region Constructors
		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
			Initialize ();
		}
		// Shared initialization code
		void Initialize ()
		{

		}
		#endregion
		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}

		private List<VideoInfo> currentVideoInfos;
		private DownloadingTableViewSource tableSource;

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();
			savePathInput.StringValue = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			tableSource = new DownloadingTableViewSource (tasksTableView); 
		}

		partial void clickParseButtonHandler (NSObject sender)
		{
			var url = urlInput.StringValue;
			if(String.IsNullOrEmpty(url) == false){
				try {
					videoInfos.RemoveAll();
					currentVideoInfos = DownloadUrlResolver.GetDownloadUrls(url) as List<VideoInfo>;
					currentVideoInfos.All(info => {
						videoInfos.Add(new NSString("[" + info.VideoType.ToString() + " " + info.Resolution + "P] " + info.Title));
						return true;
					});
					videoInfos.SelectItem(0);
				} catch {}
			}
		}

		partial void clickStartButtonHandler (NSObject sender)
		{
			var video = currentVideoInfos[videoInfos.SelectedIndex];
			var downloader = new VideoDownloader(video, Path.Combine(savePathInput.StringValue, video.Title + video.VideoExtension));
			tableSource.Add(downloader);
			tasksTableView.ReloadData();
			ThreadPool.QueueUserWorkItem(state => downloader.Execute() );
		}
	}
}


















