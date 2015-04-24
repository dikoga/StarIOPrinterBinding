using System;
using System.Drawing;

using ObjCRuntime;
using Foundation;
using UIKit;
using ExternalAccessory;

namespace StarPrinter
{
	// @interface WBluetoothPort : NSObject <NSStreamDelegate>
	[BaseType (typeof(NSStreamDelegate))]
	[Protocol]
	interface WBluetoothPort
	{

		// -(id)initWithPortName:(NSString *)portName portSettings:(NSString *)portSettings timeout:(u_int32_t)timeout;
		[Export ("initWithPortName:portSettings:timeout:")]
		IntPtr Constructor (string portName, string portSettings, uint timeout);

		// @property (readonly, getter = isConnected) BOOL connected;
		[Export ("connected")]
		bool IsConnected { [Bind ("isConnected")] get; }

		// @property (readwrite) u_int32_t endCheckedBlockTimeoutMillis;
		[Export ("endCheckedBlockTimeoutMillis")]
		uint EndCheckedBlockTimeoutMillis { get; set; }

		// @property (readonly, retain) NSString * firmwareInformation;
		[Export ("firmwareInformation", ArgumentSemantic.Retain)]
		string FirmwareInformation { get; }

		// -(BOOL)open;
		[Export ("open")]
		bool Open ();

		// -(int32_t)write:(NSData *)data;
		[Export ("write:")]
		int Write (NSData data);

		// -(NSData *)read:(NSUInteger)bytesToRead;
		[Export ("read:")]
		NSData Read (nuint bytesToRead);

		// -(BOOL)getParsedStatus:(StarPrinterStatus_2 *)starPrinterStatus level:(u_int32_t)level;
		//		[Export ("getParsedStatus:level:")]
		//		void GetParsedStatus (ref StarPrinterStatus_2_ starPrinterStatus, uint level);

		// -(BOOL)getParsedStatus:(StarPrinterStatus_2 *)starPrinterStatus level:(u_int32_t)level timeout:(__darwin_time_t)timeoutSec;
		//		[Export ("getParsedStatus:level:timeout:")]
		//		void GetParsedStatus (ref StarPrinterStatus_2_ starPrinterStatus, uint level, nint timeoutSec);

		// -(BOOL)retrieveFirmwareInformation;
		[Export ("retrieveFirmwareInformation")]
		bool RetrieveFirmwareInformation ();

		// -(BOOL)retrieveDipSwitchInformation;
		[Export ("retrieveDipSwitchInformation")]
		bool RetrieveDipSwitchInformation ();

		// -(BOOL)getOnlineStatus:(BOOL *)onlineStatus;
		[Export ("getOnlineStatus:")]
		bool GetOnlineStatus (sbyte onlineStatus);

		// -(BOOL)beginCheckedBlock;
		[Export ("beginCheckedBlock")]
		void BeginCheckedBlock ();

		// -(BOOL)endCheckedBlock;
		[Export ("endCheckedBlock")]
		void EndCheckedBlock ();

		// -(void)close;
		[Export ("close")]
		void Close ();
	}


	//	// @interface Lock : NSObject
	//	[BaseType (typeof (NSObject))]
	//	interface Lock {
	//
	//		// +(Lock *)sharedManager;
	//		[Static, Export ("sharedManager")]
	//		Lock SharedManager ();
	//
	//		// -(void)lock;
	//		[Export ("lock")]
	//		void Lock ();
	//
	//		// -(void)unlock;
	//		[Export ("unlock")]
	//		void Unlock ();
	//	}
	// @interface BluetoothPort : NSObject <NSStreamDelegate>
	[BaseType (typeof(NSStreamDelegate))]
	[Protocol]
	interface BluetoothPort
	{

		// -(id)initWithPortName:(NSString *)portName portSettings:(NSString *)portSettings timeout:(u_int32_t)timeout;
		[Export ("initWithPortName:portSettings:timeout:")]
		IntPtr Constructor (string portName, string portSettings, uint timeout);

		// @property (readonly, getter = isConnected) BOOL connected;
		[Export ("connected")]
		bool Connected { [Bind ("isConnected")] get; }

		// @property (readwrite) u_int32_t endCheckedBlockTimeoutMillis;
		[Export ("endCheckedBlockTimeoutMillis")]
		uint EndCheckedBlockTimeoutMillis { get; set; }

		// @property (assign, nonatomic) NSInteger dataTimeoutSeconds;
		[Export ("dataTimeoutSeconds", ArgumentSemantic.UnsafeUnretained)]
		nint DataTimeoutSeconds { get; set; }

		// @property (readonly, retain) NSString * firmwareInformation;
		[Export ("firmwareInformation", ArgumentSemantic.Retain)]
		string FirmwareInformation { get; }

		// @property (readonly, retain) NSMutableArray * dipSwitchInformation;
		[Export ("dipSwitchInformation", ArgumentSemantic.Retain)]
		NSMutableArray DipSwitchInformation { get; }

		// @property (readonly, assign) BOOL isDKAirCash;
		[Export ("isDKAirCash", ArgumentSemantic.UnsafeUnretained)]
		bool IsDKAirCash { get; }

		// -(BOOL)open;
		[Export ("open")]
		bool Open ();

		// -(int)write:(NSData *)data;
		[Export ("write:")]
		int Write (NSData data);

		// -(NSData *)read:(NSUInteger)bytesToRead;
		[Export ("read:")]
		NSData Read (nuint bytesToRead);

		// -(BOOL)getParsedStatus:(StarPrinterStatus_2 *)starPrinterStatus level:(u_int32_t)level;
		//		[Export ("getParsedStatus:level:")]
		//		void GetParsedStatus (ref StarPrinterStatus_2_ starPrinterStatus, uint level);

		// -(BOOL)getOnlineStatus:(BOOL *)onlineStatus;
		[Export ("getOnlineStatus:")]
		void GetOnlineStatus (sbyte onlineStatus);

		// -(BOOL)retrieveFirmwareInformation;
		[Export ("retrieveFirmwareInformation")]
		bool RetrieveFirmwareInformation ();

		// -(BOOL)retrieveFirmwareInformation2;
		[Export ("retrieveFirmwareInformation2")]
		bool RetrieveFirmwareInformation2 ();

		// -(BOOL)retrieveDipSwitchInformation;
		[Export ("retrieveDipSwitchInformation")]
		bool RetrieveDipSwitchInformation ();

		// -(NSInteger)retrieveButtonSecurityTimeout;
		[Export ("retrieveButtonSecurityTimeout")]
		nint RetrieveButtonSecurityTimeout ();

		// -(BOOL)beginCheckedBlock:(StarPrinterStatus_2 *)starPrinterStatus level:(u_int32_t)level;
		//		[Export ("beginCheckedBlock:level:")]q
		//		void BeginCheckedBlock (ref StarPrinterStatus_2_ starPrinterStatus, uint level);

		// -(BOOL)endCheckedBlock:(StarPrinterStatus_2 *)starPrinterStatus level:(u_int32_t)level;
		//		[Export ("endCheckedBlock:level:")]
		//		void EndCheckedBlock (ref StarPrinterStatus_2_ starPrinterStatus, uint level);

		// -(void)close;
		[Export ("close")]
		void Close ();

		// -(BOOL)disconnect;
		[Export ("disconnect")]
		bool Disconnect ();

		// -(BOOL)startDataCancel;
		[Export ("startDataCancel")]
		bool StartDataCancel ();
	}

	// @interface PortException : NSException
	[BaseType (typeof(NSException))]
	[Protocol]
	interface PortException
	{

	}

	// @interface PortInfo : NSObject
	[BaseType (typeof(NSObject))]
	[Protocol]
	interface PortInfo
	{

		// -(id)initWithPortName:(NSString *)portName_ macAddress:(NSString *)macAddress_ modelName:(NSString *)modelName_;
		[Export ("initWithPortName:macAddress:modelName:")]
		IntPtr Constructor (string portName_, string macAddress_, string modelName_);

		// @property (readonly, retain) NSString * portName;
		[Export ("portName", ArgumentSemantic.Retain)]
		string PortName { get; }

		// @property (readonly, retain) NSString * macAddress;
		[Export ("macAddress", ArgumentSemantic.Retain)]
		string MacAddress { get; }

		// @property (readonly, retain) NSString * modelName;
		[Export ("modelName", ArgumentSemantic.Retain)]
		string ModelName { get; }

		// @property (readonly, getter = isConnected) BOOL connected;
		[Export ("connected")]
		bool IsConnected { [Bind ("isConnected")] get; }
	}

	// @interface SMPort : NSObject
	[BaseType (typeof(NSObject))]
	[Protocol]
	interface SMPort
	{

		// -(id)init:(NSString *)portName :(NSString *)portSettings :(u_int32_t)ioTimeoutMillis;
		[Export ("init:::")]
		IntPtr Constructor (string portName, string portSettings, uint ioTimeoutMillis);

		// @property (assign, readwrite, nonatomic) u_int32_t endCheckedBlockTimeoutMillis;
		[Export ("endCheckedBlockTimeoutMillis", ArgumentSemantic.UnsafeUnretained)]
		uint EndCheckedBlockTimeoutMillis { get; set; }

		// +(NSString *)StarIOVersion;
		[Static, Export ("StarIOVersion")]
		string StarIOVersion ();

		// +(NSArray *)searchPrinter;
		[Static, Export ("searchPrinter")]
		PortInfo [] SearchPrinter ();

		// +(NSArray *)searchPrinter:(NSString *)target;
		[Static, Export ("searchPrinter:")]
		PortInfo [] SearchPrinter (string target);

		// +(SMPort *)getPort:(NSString *)portName :(NSString *)portSettings :(u_int32_t)ioTimeoutMillis;
		[Static, Export ("getPort:::")]
		SMPort GetPort (string portName, string portSettings, uint ioTimeoutMillis);

		// +(void)releasePort:(SMPort *)port;
		[Static, Export ("releasePort:")]
		void ReleasePort (SMPort port);

		// -(u_int32_t)writePort:(const u_int8_t *)writeBuffer :(u_int32_t)offSet :(u_int32_t)size;
		[Export ("writePort:::")]
		uint WritePort (IntPtr writeBuffer, uint offSet, uint size);

		// -(u_int32_t)readPort:(u_int8_t *)readBuffer :(u_int32_t)offSet :(u_int32_t)size;
		[Export ("readPort:::")]
		uint ReadPort (IntPtr readBuffer, uint offSet, uint size);

		// -(void)getParsedStatus:(void *)starPrinterStatus :(u_int32_t)level;
		//[Export ("getParsedStatus::")]
		//void GetParsedStatus (IntPtr starPrinterStatus, uint level);

		// -(NSDictionary *)getFirmwareInformation;
		[Export ("getFirmwareInformation")]
		NSDictionary GetFirmwareInformation ();

		// -(NSDictionary *)getDipSwitchInformation;
		[Export ("getDipSwitchInformation")]
		NSDictionary GetDipSwitchInformation ();

		// -(_Bool)getOnlineStatus;
		[Export ("getOnlineStatus")]
		bool GetOnlineStatus ();

		// -(void)beginCheckedBlock:(void *)starPrinterStatus :(u_int32_t)level;
		[Export ("beginCheckedBlock::")]
		void BeginCheckedBlock (IntPtr starPrinterStatus, uint level);

		// -(void)endCheckedBlock:(void *)starPrinterStatus :(u_int32_t)level;
		[Export ("endCheckedBlock::")]
		void EndCheckedBlock (IntPtr starPrinterStatus, uint level);

		// -(BOOL)disconnect;
		[Export ("disconnect")]
		bool Disconnect ();

		// +(NSMutableData *)compressRasterData:(int32_t)width :(int32_t)height :(u_int8_t *)imageData :(NSString *)portSettings;
		[Static, Export ("compressRasterData::::")]
		NSMutableData CompressRasterData (int width, int height, byte imageData, string portSettings);

		// +(NSMutableData *)generateBitImageCommand:(int32_t)width :(int32_t)height :(u_int8_t *)imageData :(NSString *)portSettings;
		//[Availability (Deprecated = Platform.iOS | Platform.Mac)]
		[Static, Export ("generateBitImageCommand::::")]
		NSMutableData GenerateBitImageCommand (uint width, uint height, IntPtr imageData, string portSettings);

		// -(NSString *)portName;
		[Export ("portName")]
		string PortName { get; }

		// -(NSString *)portSettings;
		//[Export ("portSettings")]
		//string PortSettings ();

		// @property (readonly, retain) NSString * modelName;
		[Export ("modelName")]
		string ModelName { get; }

		[Export ("macAddress")]
		string MacAddress { get; }

		// -(u_int32_t)timeoutMillis;
		[Export ("timeoutMillis")]
		uint TimeoutMillis ();

		// -(BOOL)connected;
		[Export ("connected")]
		bool IsConnected ();

		// +(void)setMACAddressSourceBlock:(NSString *(^)(EAAccessory *))macAddressSourceBlock;
		[Static, Export ("setMACAddressSourceBlock:")]
		void SetMACAddressSourceBlock (Func<EAAccessory, NSString> macAddressSourceBlock);
	}

	// @interface Port : SMPort
	[BaseType (typeof(SMPort))]
	interface Port
	{

		// +(Port *)getPort:(NSString *)portName :(NSString *)portSettings :(u_int32_t)ioTimeoutMillis;
		[Static, Export ("getPort:::")]
		Port GetPort (string portName, string portSettings, uint ioTimeoutMillis);
	}

	//	[BaseType (typeof(NSObject))]
	//	public struct StarPrinterStatus
	//	{
	//		// printer status 1
	//		[Export ("coverOpen")]
	//		public bool CoverOpen { get; set; }
	//
	//		[Export ("offline")]
	//		public bool Offline { get; set; }
	//
	//		[Export ("compulsionSwitch")]
	//		public bool CompulsionSwitch { get; set; }
	//
	//		// printer status 2
	//		[Export ("overTemp")]
	//		public bool OverTemp { get; set; }
	//
	//		[Export ("unrecoverableError")]
	//		public bool UnrecoverableError { get; set; }
	//
	//		[Export ("cutterError")]
	//		public bool CutterError { get; set; }
	//
	//		[Export ("mechError")]
	//		public bool MechError { get; set; }
	//
	//		[Export ("headThermistorError")]
	//		public bool HeadThermistorError { get; set; }
	//
	//		// printer status 3
	//		[Export ("receiveBufferOverflow")]
	//		public bool ReceiveBufferOverflow { get; set; }
	//
	//		[Export ("pageModeCmdError")]
	//		public bool PageModeCmdError { get; set; }
	//
	//		[Export ("blackMarkError")]
	//		public bool BlackMarkError { get; set; }
	//
	//		[Export ("presenterPaperJamError")]
	//		public bool PresenterPaperJamError { get; set; }
	//
	//		[Export ("headUpError")]
	//		public bool HeadUpError { get; set; }
	//
	//		[Export ("voltageError")]
	//		public bool VoltageError { get; set; }
	//
	//		// printer status 4
	//		[Export ("receiptBlackMarkDetection")]
	//		public bool ReceiptBlackMarkDetection { get; set; }
	//
	//		[Export ("receiptPaperEmpty")]
	//		public bool ReceiptPaperEmpty { get; set; }
	//
	//		[Export ("receiptPaperNearEmptyInner")]
	//		public bool ReceiptPaperNearEmptyInner { get; set; }
	//
	//		[Export ("receiptPaperNearEmptyOuter")]
	//		public bool ReceiptPaperNearEmptyOuter { get; set; }
	//
	//		// printer status 5
	//		[Export ("presenterPaperPresent")]
	//		public bool PresenterPaperPresent { get; set; }
	//
	//		[Export ("peelerPaperPresent")]
	//		public bool PeelerPaperPresent { get; set; }
	//
	//		[Export ("stackerFull")]
	//		public bool StackerFull { get; set; }
	//
	//		[Export ("slipTOF")]
	//		public bool SlipTOF { get; set; }
	//
	//		[Export ("slipCOF")]
	//		public bool SlipCOF { get; set; }
	//
	//		[Export ("slipBOF")]
	//		public bool SlipBOF { get; set; }
	//
	//		[Export ("validationPaperPresent")]
	//		public bool ValidationPaperPresent { get; set; }
	//
	//		[Export ("slipPaperPresent")]
	//		public bool SlipPaperPresent { get; set; }
	//
	//		// printer status 6
	//		[Export ("etbAvailable")]
	//		public bool EtbAvailable { get; set; }
	//
	//		[Export ("etbCounter")]
	//		public Char EtbCounter { get; set; }
	//
	//		// printer status 7
	//		[Export ("presenterState")]
	//		public Char PresenterState { get; set; }
	//
	//		// raw
	//		[Export ("rawLength")]
	//		public UInt32 RawLength { get; set; }
	//
	//		[Export ("raws")]
	//		public Char[] Raws { get; set; }
	//	}
}

