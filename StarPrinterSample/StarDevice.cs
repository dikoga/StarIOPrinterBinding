using System;
using StarPrinter;
using System.Text;
using System.Runtime.InteropServices;

namespace StarPrinterSample
{
	public class StarDevice
	{
		private string _printerAddress;

		public StarDevice (string printerAddress)
		{
			_printerAddress = printerAddress;
		}
		public void Send(string toPrint)
		{
			//Set the status to offline because this is a new attempt to print
			bool onlineStatus = false;
			SMPort sPort = null;
			//TRY -> Use the textboxes to check if the port info given will connect to the printer.
			try
			{

				//Very important to only try opening the port in a Try, Catch incase the port is not working
				sPort = SMPort.GetPort(string.Format("TCP:{0}", _printerAddress), "", 5000);
				//GetOnlineStatus() will return a boolean to let us know if the printer was reachable.
				onlineStatus = sPort.IsConnected();
			}

			//CATCH -> If the port information is bad, catch the failure.
			catch (Exception ex)
			{
				if (sPort != null)
					ReleasePort(sPort);

				throw new Exception(string.Format("Can not connect to the printer address: {0}", _printerAddress), ex);
			}

			//If it is offline, dont setup receipt or try to write to the port.
			if (onlineStatus == false)
			{
				ReleasePort(sPort);
				throw new Exception("Printer is offline");
			}

			byte[] dataByteArray = Encoding.UTF8.GetBytes(toPrint);

			//Write bytes to printer
			uint amountWritten = 0;
			while (dataByteArray.Length > amountWritten)
			{
				//This while loop is very important because in here is where the bytes are being sent out through StarIO to the printer
				var amountWrittenKeep = amountWritten;
				try
				{
					unsafe
					{
						IntPtr unmanagedPointer = Marshal.AllocHGlobal(dataByteArray.Length);
						Marshal.Copy(dataByteArray, 0, unmanagedPointer, dataByteArray.Length);
						// Call unmanaged code

						amountWritten += sPort.WritePort(unmanagedPointer, amountWritten, (uint)dataByteArray.Length - amountWritten);

						Marshal.FreeHGlobal(unmanagedPointer);
					}
				}
				catch (Exception)
				{
					// error happen while sending data
					ReleasePort(sPort);
					return;
				}

				if (amountWrittenKeep == amountWritten) // no data is sent
				{
					SMPort.ReleasePort(sPort);
					return; //exit this entire function
				}
			}

			ReleasePort(sPort);
		}

		private static void ReleasePort(SMPort sPort)
		{
			SMPort.ReleasePort(sPort);
			sPort = null;
		}   
	}
}

