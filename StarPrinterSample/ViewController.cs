using System;

using UIKit;

using System.Threading.Tasks;
using System.Timers;
using System.Collections.Generic;
using StarPrinter;
using Foundation;

namespace StarPrinterSample
{
	public partial class ViewController : UIViewController
	{
		private Timer _timer;

		private List<PortInfo> _printers;

		private string _printerAddress;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			_printers = new List<PortInfo> ();
			_timer = new Timer (1000);
			_timer.Elapsed += timer_Elapsed;
			_timer.Enabled = true;
		}

		void timer_Elapsed (object sender, ElapsedEventArgs e)
		{
			_timer.Interval = 30000;
			_timer.Enabled = false;

			var foundPrinter = new List<PortInfo> ();

			var search = SMPort.SearchPrinter ();

			foreach (var printer in search) {
				Console.WriteLine (printer.PortName);
				Console.WriteLine (printer.ModelName);
				Console.WriteLine (printer.MacAddress);
				foundPrinter.Add (printer);
			}

			InvokeOnMainThread (() => {
				_printers.Clear ();
				_printers.AddRange (foundPrinter);

				LoadPrinters ();
			});

			_timer.Enabled = true;
		}

		private void LoadPrinters ()
		{
			var source = new PrinterTableSource (_printers);
			source.PrinterSelected += PrinterSelected;
			PrintersTableView.Source = source;
			PrintersTableView.ReloadData ();
		}

		private void PrinterSelected (int section, int index)
		{
			_printerAddress = _printers [index].PortName.Remove (0, 4);
		}

		partial void PrintButton_TouchUpInside (UIButton sender)
		{
			if (!string.IsNullOrEmpty (_printerAddress)) {
				var device = new StarDevice (_printerAddress);
				device.Send ("\x1b\x1d\x61\x1\x1b\x45Printer test receipt..\x1b\x44\x2\x10\x22\x0\n\n\n\x1b\x64\x02");
			}
		}
	}

	class PrinterTableSource : UITableViewSource
	{
		private List<PortInfo> _printers;

		public event Action<int, int> PrinterSelected;

		public PrinterTableSource (List<PortInfo> printers)
		{
			_printers = printers;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("cellIdentifier") ??
			           new UITableViewCell (UITableViewCellStyle.Subtitle, "cellIdentifier");
			cell.TextLabel.Text = _printers [indexPath.Row].ModelName;
			cell.DetailTextLabel.Text = _printers [indexPath.Row].PortName;

			return cell;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return _printers.Count;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			PrinterSelected (indexPath.Section, indexPath.Row);
		}
	}
}

