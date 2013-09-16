// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface MainWindowController : NSWindowController {
	NSTextField *_savePathInput;
	NSTableView *_tasksTableView;
	NSTextField *_urlInput;
	NSComboBox *_videoInfos;
}

@property (nonatomic, retain) IBOutlet NSTextField *savePathInput;

@property (nonatomic, retain) IBOutlet NSTableView *tasksTableView;

@property (nonatomic, retain) IBOutlet NSTextField *urlInput;

@property (nonatomic, retain) IBOutlet NSComboBox *videoInfos;

- (IBAction)clickParseButtonHandler:(id)sender;

- (IBAction)clickStartButtonHandler:(id)sender;

@end
