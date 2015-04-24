using System;
using ObjCRuntime;

[assembly: LinkWith ("StarIO.a", LinkTarget.ArmV7s | LinkTarget.ArmV7 | LinkTarget.Simulator, SmartLink = false, ForceLoad = true, Frameworks = "ExternalAccessory")]
