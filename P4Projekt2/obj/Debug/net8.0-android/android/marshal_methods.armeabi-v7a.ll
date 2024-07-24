; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [353 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [700 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 269
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 303
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 38948123, ; 6: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 315
	i32 39109920, ; 7: Newtonsoft.Json.dll => 0x254c520 => 224
	i32 39485524, ; 8: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42244203, ; 9: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 324
	i32 42639949, ; 10: System.Threading.Thread => 0x28aa24d => 145
	i32 66541672, ; 11: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 12: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 348
	i32 68219467, ; 13: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 14: Microsoft.Maui.Graphics.dll => 0x44bb714 => 221
	i32 82292897, ; 15: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 83839681, ; 16: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 332
	i32 98325684, ; 17: Microsoft.Extensions.Diagnostics.Abstractions => 0x5dc54b4 => 201
	i32 101534019, ; 18: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 287
	i32 117431740, ; 19: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 20: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 287
	i32 122350210, ; 21: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 22: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 311
	i32 136584136, ; 23: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 347
	i32 140062828, ; 24: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 340
	i32 142721839, ; 25: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 26: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 27: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 28: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 243
	i32 176265551, ; 29: System.ServiceProcess => 0xa81994f => 132
	i32 176714968, ; 30: Microsoft.AspNetCore.WebUtilities.dll => 0xa8874d8 => 192
	i32 182336117, ; 31: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 289
	i32 184328833, ; 32: System.ValueTuple.dll => 0xafca281 => 151
	i32 205061960, ; 33: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 34: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 241
	i32 220171995, ; 35: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 221958352, ; 36: Microsoft.Extensions.Diagnostics.dll => 0xd3ad0d0 => 200
	i32 230216969, ; 37: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 263
	i32 230752869, ; 38: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 39: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 40: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 41: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 261689757, ; 42: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 246
	i32 276479776, ; 43: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 277295747, ; 44: Refit.HttpClientFactory => 0x10873283 => 226
	i32 278686392, ; 45: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 265
	i32 280482487, ; 46: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 262
	i32 291076382, ; 47: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 291275502, ; 48: Microsoft.Extensions.Http.dll => 0x115c82ee => 207
	i32 298918909, ; 49: System.Net.Ping.dll => 0x11d123fd => 69
	i32 317674968, ; 50: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 345
	i32 318968648, ; 51: Xamarin.AndroidX.Activity.dll => 0x13031348 => 232
	i32 321597661, ; 52: System.Numerics => 0x132b30dd => 83
	i32 321963286, ; 53: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 323
	i32 342366114, ; 54: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 264
	i32 360082299, ; 55: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 56: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 57: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 58: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 59: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 60: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 61: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 62: _Microsoft.Android.Resource.Designer => 0x17969339 => 349
	i32 403441872, ; 63: WindowsBase => 0x180c08d0 => 165
	i32 409257351, ; 64: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 343
	i32 441335492, ; 65: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 247
	i32 442565967, ; 66: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 67: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 260
	i32 451504562, ; 68: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 455823026, ; 69: P4Projekt2 => 0x1b2b4eb2 => 0
	i32 456227837, ; 70: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 458494020, ; 71: Microsoft.AspNetCore.SignalR.Common.dll => 0x1b541044 => 190
	i32 459347974, ; 72: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 73: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 74: System.dll => 0x1bff388e => 164
	i32 476646585, ; 75: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 262
	i32 486930444, ; 76: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 275
	i32 489220957, ; 77: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 321
	i32 490002678, ; 78: Microsoft.AspNetCore.Hosting.Server.Abstractions.dll => 0x1d34d8f6 => 179
	i32 498788369, ; 79: System.ObjectModel => 0x1dbae811 => 84
	i32 513247710, ; 80: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 214
	i32 526420162, ; 81: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 82: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 311
	i32 530272170, ; 83: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 538707440, ; 84: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 342
	i32 539058512, ; 85: Microsoft.Extensions.Logging => 0x20216150 => 208
	i32 540030774, ; 86: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 87: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 88: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 89: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 90: Jsr305Binding => 0x213954e7 => 300
	i32 569601784, ; 91: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 298
	i32 577335427, ; 92: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 601371474, ; 93: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 94: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 95: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 96: Xamarin.AndroidX.CustomView => 0x2568904f => 252
	i32 627931235, ; 97: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 334
	i32 639843206, ; 98: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 258
	i32 643868501, ; 99: System.Net => 0x2660a755 => 81
	i32 662205335, ; 100: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 101: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 294
	i32 666292255, ; 102: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 239
	i32 672442732, ; 103: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 104: System.Net.Security => 0x28bdabca => 73
	i32 690569205, ; 105: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 106: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 313
	i32 693804605, ; 107: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 108: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 109: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 308
	i32 700358131, ; 110: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 720511267, ; 111: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 312
	i32 722857257, ; 112: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 731701662, ; 113: Microsoft.Extensions.Options.ConfigurationExtensions => 0x2b9ce19e => 213
	i32 735137430, ; 114: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 115: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 116: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 229
	i32 759454413, ; 117: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 118: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 119: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 120: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 340
	i32 789151979, ; 121: Microsoft.Extensions.Options => 0x2f0980eb => 212
	i32 790371945, ; 122: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 253
	i32 804715423, ; 123: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 124: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 267
	i32 823281589, ; 125: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 126: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 127: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 832711436, ; 128: Microsoft.AspNetCore.SignalR.Protocols.Json.dll => 0x31a22b0c => 191
	i32 834051424, ; 129: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 130: Xamarin.AndroidX.Print => 0x3246f6cd => 280
	i32 869139383, ; 131: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 325
	i32 873119928, ; 132: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 133: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 134: System.Net.Http.Json => 0x3463c971 => 63
	i32 880668424, ; 135: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 339
	i32 904024072, ; 136: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 908337989, ; 137: Refit => 0x36242345 => 225
	i32 908888060, ; 138: Microsoft.Maui.Maps => 0x362c87fc => 222
	i32 911108515, ; 139: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 918734561, ; 140: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 336
	i32 928116545, ; 141: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 303
	i32 952186615, ; 142: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 955402788, ; 143: Newtonsoft.Json => 0x38f24a24 => 224
	i32 956575887, ; 144: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 312
	i32 961460050, ; 145: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 329
	i32 966729478, ; 146: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 301
	i32 967690846, ; 147: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 264
	i32 975236339, ; 148: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 149: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 150: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 151: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 990727110, ; 152: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 338
	i32 992768348, ; 153: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 154: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 999186168, ; 155: Microsoft.Extensions.FileSystemGlobbing.dll => 0x3b8e5ef8 => 205
	i32 1001831731, ; 156: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 157: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 284
	i32 1019214401, ; 158: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 159: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 199
	i32 1031528504, ; 160: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 302
	i32 1035644815, ; 161: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 237
	i32 1036536393, ; 162: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1043950537, ; 163: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 319
	i32 1044663988, ; 164: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1048992957, ; 165: Microsoft.Extensions.Diagnostics.Abstractions.dll => 0x3e865cbd => 201
	i32 1052210849, ; 166: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 271
	i32 1067306892, ; 167: GoogleGson => 0x3f9dcf8c => 173
	i32 1082857460, ; 168: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 169: Xamarin.Kotlin.StdLib => 0x409e66d8 => 309
	i32 1092741930, ; 170: Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.dll => 0x4121eb2a => 188
	i32 1098259244, ; 171: System => 0x41761b2c => 164
	i32 1106973742, ; 172: Microsoft.Extensions.Configuration.FileExtensions.dll => 0x41fb142e => 197
	i32 1108272742, ; 173: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 341
	i32 1110309514, ; 174: Microsoft.Extensions.Hosting.Abstractions => 0x422dfa8a => 206
	i32 1117529484, ; 175: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 335
	i32 1118262833, ; 176: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 331
	i32 1121599056, ; 177: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 270
	i32 1122549021, ; 178: Refit.HttpClientFactory.dll => 0x42e8bd1d => 226
	i32 1127624469, ; 179: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 210
	i32 1149092582, ; 180: Xamarin.AndroidX.Window => 0x447dc2e6 => 297
	i32 1168523401, ; 181: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 337
	i32 1170634674, ; 182: System.Web.dll => 0x45c677b2 => 153
	i32 1173126369, ; 183: Microsoft.Extensions.FileProviders.Abstractions.dll => 0x45ec7ce1 => 203
	i32 1175144683, ; 184: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 293
	i32 1178241025, ; 185: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 278
	i32 1204270330, ; 186: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 239
	i32 1208641965, ; 187: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1219128291, ; 188: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1220193633, ; 189: Microsoft.Net.Http.Headers => 0x48baad61 => 223
	i32 1233093933, ; 190: Microsoft.AspNetCore.SignalR.Client.Core.dll => 0x497f852d => 189
	i32 1235881722, ; 191: Microsoft.AspNetCore.Server.Kestrel.Transport.Abstractions.dll => 0x49aa0efa => 187
	i32 1236289705, ; 192: Microsoft.AspNetCore.Hosting.Server.Abstractions => 0x49b048a9 => 179
	i32 1243150071, ; 193: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 298
	i32 1253011324, ; 194: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 195: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 317
	i32 1264511973, ; 196: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 288
	i32 1267360935, ; 197: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 292
	i32 1273260888, ; 198: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 244
	i32 1275534314, ; 199: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 313
	i32 1278448581, ; 200: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 236
	i32 1293217323, ; 201: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 255
	i32 1308624726, ; 202: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 326
	i32 1309188875, ; 203: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1322716291, ; 204: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 297
	i32 1324164729, ; 205: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 206: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1336711579, ; 207: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 346
	i32 1364015309, ; 208: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 209: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 347
	i32 1376866003, ; 210: Xamarin.AndroidX.SavedState => 0x52114ed3 => 284
	i32 1379779777, ; 211: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 212: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 213: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 248
	i32 1408764838, ; 214: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 215: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1414043276, ; 216: Microsoft.AspNetCore.Connections.Abstractions.dll => 0x5448968c => 176
	i32 1422545099, ; 217: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 218: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 315
	i32 1434145427, ; 219: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 220: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 301
	i32 1439761251, ; 221: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 222: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 223: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1457743152, ; 224: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 225: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1461004990, ; 226: es\Microsoft.Maui.Controls.resources => 0x57152abe => 321
	i32 1461234159, ; 227: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 228: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 229: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 230: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 238
	i32 1470490898, ; 231: Microsoft.Extensions.Primitives => 0x57a5e912 => 214
	i32 1479771757, ; 232: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 233: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 234: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 235: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 285
	i32 1505131794, ; 236: Microsoft.Extensions.Http => 0x59b67d12 => 207
	i32 1521091094, ; 237: Microsoft.Extensions.FileSystemGlobbing => 0x5aaa0216 => 205
	i32 1526286932, ; 238: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 345
	i32 1536373174, ; 239: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 240: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 241: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 242: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1565862583, ; 243: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 244: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 245: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 246: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 247: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 254
	i32 1592978981, ; 248: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1597949149, ; 249: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 302
	i32 1601112923, ; 250: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 251: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 252: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 253: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 274
	i32 1622358360, ; 254: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 255: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 296
	i32 1632079564, ; 256: Microsoft.AspNet.SignalR.Client.dll => 0x61478ecc => 175
	i32 1635184631, ; 257: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 258
	i32 1636350590, ; 258: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 251
	i32 1639515021, ; 259: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 260: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 261: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 262: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 263: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 290
	i32 1658251792, ; 264: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 299
	i32 1670060433, ; 265: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 246
	i32 1675553242, ; 266: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 267: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 268: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 269: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 270: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 271: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 272: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 310
	i32 1701541528, ; 273: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 274: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 267
	i32 1726116996, ; 275: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 276: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 277: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 242
	i32 1743415430, ; 278: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 316
	i32 1744735666, ; 279: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746115085, ; 280: System.IO.Pipelines.dll => 0x68139a0d => 227
	i32 1746316138, ; 281: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 282: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 283: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 284: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 285: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 286: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 289
	i32 1770582343, ; 287: Microsoft.Extensions.Logging.dll => 0x6988f147 => 208
	i32 1776026572, ; 288: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 289: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1777249951, ; 290: Microsoft.AspNetCore.Server.Kestrel.Core.dll => 0x69eeae9f => 185
	i32 1780572499, ; 291: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782862114, ; 292: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 332
	i32 1788241197, ; 293: Xamarin.AndroidX.Fragment => 0x6a96652d => 260
	i32 1793755602, ; 294: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 324
	i32 1808609942, ; 295: Xamarin.AndroidX.Loader => 0x6bcd3296 => 274
	i32 1813058853, ; 296: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 309
	i32 1813201214, ; 297: Xamarin.Google.Android.Material => 0x6c13413e => 299
	i32 1818569960, ; 298: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 279
	i32 1818787751, ; 299: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1819327070, ; 300: Microsoft.AspNetCore.Http.Features.dll => 0x6c70ba5e => 183
	i32 1824175904, ; 301: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 302: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1828688058, ; 303: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 209
	i32 1847515442, ; 304: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 229
	i32 1853025655, ; 305: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 341
	i32 1858542181, ; 306: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1865370778, ; 307: P4Projekt2.dll => 0x6f2f4c9a => 0
	i32 1870277092, ; 308: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1875480394, ; 309: IdentityModel => 0x6fc98f4a => 174
	i32 1875935024, ; 310: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 323
	i32 1879696579, ; 311: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 312: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 240
	i32 1888955245, ; 313: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 314: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1893218855, ; 315: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 317
	i32 1898237753, ; 316: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 317: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1908813208, ; 318: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 305
	i32 1910275211, ; 319: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1928288591, ; 320: Microsoft.AspNetCore.Http.Abstractions => 0x72ef594f => 181
	i32 1939592360, ; 321: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1945717188, ; 322: Microsoft.AspNetCore.SignalR.Client.Core => 0x73f949c4 => 189
	i32 1953182387, ; 323: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 328
	i32 1956758971, ; 324: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 325: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 286
	i32 1967334205, ; 326: Microsoft.AspNetCore.SignalR.Common => 0x7543233d => 190
	i32 1968388702, ; 327: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 193
	i32 1983156543, ; 328: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 310
	i32 1985761444, ; 329: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 231
	i32 2003115576, ; 330: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 320
	i32 2011961780, ; 331: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 332: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 271
	i32 2031763787, ; 333: Xamarin.Android.Glide => 0x791a414b => 228
	i32 2045470958, ; 334: System.Private.Xml => 0x79eb68ee => 88
	i32 2048278909, ; 335: Microsoft.Extensions.Configuration.Binder.dll => 0x7a16417d => 195
	i32 2052370377, ; 336: Microsoft.AspNetCore.Server.Kestrel.dll => 0x7a54afc9 => 184
	i32 2055257422, ; 337: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 266
	i32 2060060697, ; 338: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 339: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 319
	i32 2070888862, ; 340: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2072397586, ; 341: Microsoft.Extensions.FileProviders.Physical => 0x7b864712 => 204
	i32 2075706075, ; 342: Microsoft.AspNetCore.Http.Abstractions.dll => 0x7bb8c2db => 181
	i32 2079903147, ; 343: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 344: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2111797732, ; 345: Microsoft.AspNetCore.Server.Kestrel => 0x7ddf79e4 => 184
	i32 2127167465, ; 346: System.Console => 0x7ec9ffe9 => 20
	i32 2129483829, ; 347: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 304
	i32 2142473426, ; 348: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 349: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 350: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 351: Microsoft.Maui => 0x80bd55ad => 219
	i32 2169148018, ; 352: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 327
	i32 2181898931, ; 353: Microsoft.Extensions.Options.dll => 0x820d22b3 => 212
	i32 2192057212, ; 354: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 209
	i32 2193016926, ; 355: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2193681939, ; 356: Microsoft.Extensions.Configuration.EnvironmentVariables.dll => 0x82c0ee13 => 196
	i32 2201107256, ; 357: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 314
	i32 2201231467, ; 358: System.Net.Http => 0x8334206b => 64
	i32 2204417087, ; 359: Microsoft.Extensions.ObjectPool => 0x8364bc3f => 211
	i32 2207618523, ; 360: it\Microsoft.Maui.Controls.resources => 0x839595db => 329
	i32 2217644978, ; 361: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 293
	i32 2222056684, ; 362: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2229158877, ; 363: Microsoft.Extensions.Features.dll => 0x84de43dd => 202
	i32 2240986525, ; 364: Microsoft.AspNet.SignalR.Client => 0x8592bd9d => 175
	i32 2242871324, ; 365: Microsoft.AspNetCore.Http.dll => 0x85af801c => 180
	i32 2244775296, ; 366: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 275
	i32 2252106437, ; 367: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 368: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 369: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 370: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 194
	i32 2267999099, ; 371: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 230
	i32 2279755925, ; 372: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 282
	i32 2293034957, ; 373: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 374: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 375: System.Net.Mail => 0x88ffe49e => 66
	i32 2303073227, ; 376: Microsoft.Maui.Controls.Maps.dll => 0x89461bcb => 217
	i32 2303942373, ; 377: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 333
	i32 2305521784, ; 378: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2315684594, ; 379: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 234
	i32 2320631194, ; 380: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 381: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 382: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 383: System.Net.Primitives => 0x8c40e0db => 70
	i32 2366048013, ; 384: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 327
	i32 2368005991, ; 385: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2371007202, ; 386: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 193
	i32 2378619854, ; 387: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 388: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 389: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 328
	i32 2401565422, ; 390: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 391: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 257
	i32 2408036941, ; 392: Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets => 0x8f87ba4d => 188
	i32 2421380589, ; 393: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 394: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 244
	i32 2427813419, ; 395: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 325
	i32 2435356389, ; 396: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 397: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 398: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 399: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 400: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465532216, ; 401: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 247
	i32 2471841756, ; 402: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 403: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 404: Microsoft.Maui.Controls => 0x93dba8a1 => 216
	i32 2483903535, ; 405: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 406: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 407: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 408: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2503351294, ; 409: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 331
	i32 2505896520, ; 410: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 269
	i32 2522472828, ; 411: Xamarin.Android.Glide.dll => 0x9659e17c => 228
	i32 2538310050, ; 412: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 413: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 326
	i32 2562349572, ; 414: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 415: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2576534780, ; 416: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 330
	i32 2581783588, ; 417: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 270
	i32 2581819634, ; 418: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 292
	i32 2585220780, ; 419: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 420: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 421: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2592341985, ; 422: Microsoft.Extensions.FileProviders.Abstractions => 0x9a83ffe1 => 203
	i32 2593496499, ; 423: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 335
	i32 2594125473, ; 424: Microsoft.AspNetCore.Hosting.Abstractions => 0x9a9f36a1 => 178
	i32 2605712449, ; 425: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 314
	i32 2615233544, ; 426: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 261
	i32 2616218305, ; 427: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 210
	i32 2617129537, ; 428: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 429: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 430: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 251
	i32 2624644809, ; 431: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 256
	i32 2626831493, ; 432: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 330
	i32 2627185994, ; 433: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 434: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 435: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 265
	i32 2633959305, ; 436: Microsoft.AspNetCore.Http.Extensions.dll => 0x9cff0789 => 182
	i32 2637500010, ; 437: Microsoft.Extensions.Features => 0x9d350e6a => 202
	i32 2663391936, ; 438: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 230
	i32 2663698177, ; 439: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 440: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 441: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 442: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 443: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 444: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 445: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 290
	i32 2715334215, ; 446: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 447: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 448: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 449: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 450: Xamarin.AndroidX.Activity => 0xa2e0939b => 232
	i32 2735172069, ; 451: System.Threading.Channels => 0xa30769e5 => 139
	i32 2737747696, ; 452: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 238
	i32 2740698338, ; 453: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 316
	i32 2740948882, ; 454: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 455: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 456: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 336
	i32 2758225723, ; 457: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 218
	i32 2764765095, ; 458: Microsoft.Maui.dll => 0xa4caf7a7 => 219
	i32 2765824710, ; 459: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 460: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 308
	i32 2778768386, ; 461: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 295
	i32 2779977773, ; 462: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 283
	i32 2785988530, ; 463: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 342
	i32 2788224221, ; 464: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 261
	i32 2801831435, ; 465: Microsoft.Maui.Graphics => 0xa7008e0b => 221
	i32 2803228030, ; 466: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2810250172, ; 467: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 248
	i32 2819470561, ; 468: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 469: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 470: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 283
	i32 2824502124, ; 471: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2836739085, ; 472: Microsoft.AspNetCore.Hosting => 0xa915340d => 177
	i32 2838993487, ; 473: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 272
	i32 2847418871, ; 474: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 304
	i32 2849599387, ; 475: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2850549256, ; 476: Microsoft.AspNetCore.Http.Features => 0xa9e7ee08 => 183
	i32 2853208004, ; 477: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 295
	i32 2855708567, ; 478: Xamarin.AndroidX.Transition => 0xaa36a797 => 291
	i32 2861098320, ; 479: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 480: Microsoft.Maui.Essentials => 0xaa8a4878 => 220
	i32 2870099610, ; 481: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 233
	i32 2875164099, ; 482: Jsr305Binding.dll => 0xab5f85c3 => 300
	i32 2875220617, ; 483: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 484: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 259
	i32 2887636118, ; 485: System.Net.dll => 0xac1dd496 => 81
	i32 2899753641, ; 486: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 487: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 488: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 489: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 490: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2911054922, ; 491: Microsoft.Extensions.FileProviders.Physical.dll => 0xad832c4a => 204
	i32 2916838712, ; 492: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 296
	i32 2919462931, ; 493: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 494: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 235
	i32 2936416060, ; 495: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 496: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 497: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 498: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 499: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2971004615, ; 500: Microsoft.Extensions.Options.ConfigurationExtensions.dll => 0xb115eec7 => 213
	i32 2972252294, ; 501: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978368250, ; 502: Microsoft.AspNetCore.Hosting.Abstractions.dll => 0xb1864afa => 178
	i32 2978675010, ; 503: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 255
	i32 2987532451, ; 504: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 286
	i32 2996646946, ; 505: Microsoft.AspNetCore.Http => 0xb29d3422 => 180
	i32 2996846495, ; 506: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 268
	i32 3016983068, ; 507: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 288
	i32 3017076677, ; 508: Xamarin.GooglePlayServices.Maps => 0xb3d4efc5 => 306
	i32 3020703001, ; 509: Microsoft.Extensions.Diagnostics => 0xb40c4519 => 200
	i32 3023353419, ; 510: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 511: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 263
	i32 3036999524, ; 512: Microsoft.AspNetCore.Http.Extensions => 0xb504ef64 => 182
	i32 3038032645, ; 513: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 349
	i32 3053864966, ; 514: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 322
	i32 3056245963, ; 515: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 285
	i32 3057625584, ; 516: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 276
	i32 3058099980, ; 517: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 307
	i32 3059408633, ; 518: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 519: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 520: System.Threading.Tasks => 0xb755818f => 144
	i32 3090735792, ; 521: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 522: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 523: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 524: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 525: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 526: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 527: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3147165239, ; 528: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3148237826, ; 529: GoogleGson.dll => 0xbba64c02 => 173
	i32 3159123045, ; 530: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 531: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3178803400, ; 532: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 277
	i32 3188578740, ; 533: Microsoft.Extensions.Configuration.EnvironmentVariables => 0xbe0dd9b4 => 196
	i32 3192346100, ; 534: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 535: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 536: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 537: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 538: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 254
	i32 3220365878, ; 539: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 540: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3230466174, ; 541: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 305
	i32 3251039220, ; 542: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 543: Xamarin.AndroidX.CardView => 0xc235e84d => 242
	i32 3265493905, ; 544: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 545: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3277815716, ; 546: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 547: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 548: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 549: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 550: System.Text.Encoding => 0xc4a8494a => 135
	i32 3300764913, ; 551: Microsoft.AspNetCore.WebUtilities => 0xc4bdacf1 => 192
	i32 3303498502, ; 552: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 553: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 322
	i32 3316684772, ; 554: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 555: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 252
	i32 3317144872, ; 556: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 557: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 240
	i32 3345895724, ; 558: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 281
	i32 3346324047, ; 559: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 278
	i32 3357674450, ; 560: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 339
	i32 3358260929, ; 561: System.Text.Json => 0xc82afec1 => 137
	i32 3362336904, ; 562: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 233
	i32 3362522851, ; 563: Xamarin.AndroidX.Core => 0xc86c06e3 => 249
	i32 3366347497, ; 564: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 565: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 282
	i32 3381016424, ; 566: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 318
	i32 3395150330, ; 567: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 568: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 569: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 253
	i32 3421170118, ; 570: Microsoft.Extensions.Configuration.Binder => 0xcbeae9c6 => 195
	i32 3421580071, ; 571: Microsoft.AspNetCore.Server.Kestrel.Https => 0xcbf12b27 => 186
	i32 3428513518, ; 572: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 198
	i32 3429136800, ; 573: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 574: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 575: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 256
	i32 3445260447, ; 576: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 577: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 215
	i32 3458724246, ; 578: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 337
	i32 3471940407, ; 579: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 580: Mono.Android => 0xcf3163e6 => 171
	i32 3484440000, ; 581: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 338
	i32 3485117614, ; 582: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 583: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 584: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 245
	i32 3500773090, ; 585: Microsoft.Maui.Controls.Maps => 0xd0a98ee2 => 217
	i32 3509114376, ; 586: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 587: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 588: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 589: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3560100363, ; 590: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 591: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3580758918, ; 592: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 346
	i32 3592228221, ; 593: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 348
	i32 3597029428, ; 594: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 231
	i32 3598340787, ; 595: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3608519521, ; 596: System.Linq.dll => 0xd715a361 => 61
	i32 3611087749, ; 597: Microsoft.AspNetCore.Hosting.dll => 0xd73cd385 => 177
	i32 3624195450, ; 598: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 599: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 280
	i32 3633644679, ; 600: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 235
	i32 3638274909, ; 601: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 602: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 266
	i32 3643446276, ; 603: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 343
	i32 3643854240, ; 604: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 277
	i32 3645089577, ; 605: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3655397943, ; 606: Microsoft.AspNetCore.Server.Kestrel.Core => 0xd9e0f237 => 185
	i32 3657292374, ; 607: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 194
	i32 3660523487, ; 608: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 609: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 610: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 241
	i32 3684561358, ; 611: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 245
	i32 3691870036, ; 612: Microsoft.AspNetCore.SignalR.Protocols.Json => 0xdc0d7754 => 191
	i32 3700866549, ; 613: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3704054342, ; 614: Microsoft.AspNetCore.Server.Kestrel.Https.dll => 0xdcc76246 => 186
	i32 3706696989, ; 615: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 250
	i32 3716563718, ; 616: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 617: Xamarin.AndroidX.Annotation => 0xdda814c6 => 234
	i32 3724971120, ; 618: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 276
	i32 3732100267, ; 619: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 620: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 621: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 622: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3751619990, ; 623: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 318
	i32 3758424670, ; 624: Microsoft.Extensions.Configuration.FileExtensions => 0xe005025e => 197
	i32 3765508441, ; 625: Microsoft.Extensions.ObjectPool.dll => 0xe0711959 => 211
	i32 3786282454, ; 626: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 243
	i32 3787005001, ; 627: Microsoft.AspNetCore.Connections.Abstractions => 0xe1b91c49 => 176
	i32 3792276235, ; 628: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 629: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 215
	i32 3802395368, ; 630: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 631: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 632: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 633: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 634: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 199
	i32 3844307129, ; 635: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 636: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3870376305, ; 637: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 638: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 639: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 640: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 641: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 291
	i32 3888767677, ; 642: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 281
	i32 3896106733, ; 643: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 644: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 249
	i32 3901907137, ; 645: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3919979020, ; 646: Microsoft.AspNetCore.Server.Kestrel.Transport.Abstractions => 0xe9a6220c => 187
	i32 3920221145, ; 647: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 334
	i32 3920810846, ; 648: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 649: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 294
	i32 3928044579, ; 650: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 651: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 652: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 279
	i32 3945713374, ; 653: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 654: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 655: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 237
	i32 3959773229, ; 656: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 268
	i32 3970018735, ; 657: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 307
	i32 4003436829, ; 658: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 659: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 236
	i32 4023392905, ; 660: System.IO.Pipelines => 0xefd01a89 => 227
	i32 4025784931, ; 661: System.Memory => 0xeff49a63 => 62
	i32 4044155772, ; 662: Microsoft.Net.Http.Headers.dll => 0xf10ceb7c => 223
	i32 4044257358, ; 663: IdentityModel.dll => 0xf10e784e => 174
	i32 4046471985, ; 664: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 218
	i32 4054681211, ; 665: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4068434129, ; 666: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 667: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4078967171, ; 668: Microsoft.Extensions.Hosting.Abstractions.dll => 0xf3201983 => 206
	i32 4091086043, ; 669: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 320
	i32 4094352644, ; 670: Microsoft.Maui.Essentials.dll => 0xf40add04 => 220
	i32 4099507663, ; 671: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 672: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 673: Xamarin.AndroidX.Emoji2 => 0xf479582c => 257
	i32 4103439459, ; 674: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 344
	i32 4126470640, ; 675: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 198
	i32 4127667938, ; 676: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 677: System.AppContext => 0xf6318da0 => 6
	i32 4144683026, ; 678: Refit.dll => 0xf70ad812 => 225
	i32 4147896353, ; 679: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150914736, ; 680: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 344
	i32 4151237749, ; 681: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 682: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 683: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 684: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 685: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 686: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 273
	i32 4185676441, ; 687: System.Security => 0xf97c5a99 => 130
	i32 4190991637, ; 688: Microsoft.Maui.Maps.dll => 0xf9cd7515 => 222
	i32 4196529839, ; 689: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 690: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4249188766, ; 691: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 333
	i32 4256097574, ; 692: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 250
	i32 4258378803, ; 693: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 272
	i32 4260525087, ; 694: System.Buffers => 0xfdf2741f => 7
	i32 4271975918, ; 695: Microsoft.Maui.Controls.dll => 0xfea12dee => 216
	i32 4274976490, ; 696: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4278134329, ; 697: Xamarin.GooglePlayServices.Maps.dll => 0xfeff2639 => 306
	i32 4292120959, ; 698: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 273
	i32 4294763496 ; 699: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 259
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [700 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 269, ; 3
	i32 303, ; 4
	i32 48, ; 5
	i32 315, ; 6
	i32 224, ; 7
	i32 80, ; 8
	i32 324, ; 9
	i32 145, ; 10
	i32 30, ; 11
	i32 348, ; 12
	i32 124, ; 13
	i32 221, ; 14
	i32 102, ; 15
	i32 332, ; 16
	i32 201, ; 17
	i32 287, ; 18
	i32 107, ; 19
	i32 287, ; 20
	i32 139, ; 21
	i32 311, ; 22
	i32 347, ; 23
	i32 340, ; 24
	i32 77, ; 25
	i32 124, ; 26
	i32 13, ; 27
	i32 243, ; 28
	i32 132, ; 29
	i32 192, ; 30
	i32 289, ; 31
	i32 151, ; 32
	i32 18, ; 33
	i32 241, ; 34
	i32 26, ; 35
	i32 200, ; 36
	i32 263, ; 37
	i32 1, ; 38
	i32 59, ; 39
	i32 42, ; 40
	i32 91, ; 41
	i32 246, ; 42
	i32 147, ; 43
	i32 226, ; 44
	i32 265, ; 45
	i32 262, ; 46
	i32 54, ; 47
	i32 207, ; 48
	i32 69, ; 49
	i32 345, ; 50
	i32 232, ; 51
	i32 83, ; 52
	i32 323, ; 53
	i32 264, ; 54
	i32 131, ; 55
	i32 55, ; 56
	i32 149, ; 57
	i32 74, ; 58
	i32 145, ; 59
	i32 62, ; 60
	i32 146, ; 61
	i32 349, ; 62
	i32 165, ; 63
	i32 343, ; 64
	i32 247, ; 65
	i32 12, ; 66
	i32 260, ; 67
	i32 125, ; 68
	i32 0, ; 69
	i32 152, ; 70
	i32 190, ; 71
	i32 113, ; 72
	i32 166, ; 73
	i32 164, ; 74
	i32 262, ; 75
	i32 275, ; 76
	i32 321, ; 77
	i32 179, ; 78
	i32 84, ; 79
	i32 214, ; 80
	i32 150, ; 81
	i32 311, ; 82
	i32 60, ; 83
	i32 342, ; 84
	i32 208, ; 85
	i32 51, ; 86
	i32 103, ; 87
	i32 114, ; 88
	i32 40, ; 89
	i32 300, ; 90
	i32 298, ; 91
	i32 120, ; 92
	i32 52, ; 93
	i32 44, ; 94
	i32 119, ; 95
	i32 252, ; 96
	i32 334, ; 97
	i32 258, ; 98
	i32 81, ; 99
	i32 136, ; 100
	i32 294, ; 101
	i32 239, ; 102
	i32 8, ; 103
	i32 73, ; 104
	i32 155, ; 105
	i32 313, ; 106
	i32 154, ; 107
	i32 92, ; 108
	i32 308, ; 109
	i32 45, ; 110
	i32 312, ; 111
	i32 109, ; 112
	i32 213, ; 113
	i32 129, ; 114
	i32 25, ; 115
	i32 229, ; 116
	i32 72, ; 117
	i32 55, ; 118
	i32 46, ; 119
	i32 340, ; 120
	i32 212, ; 121
	i32 253, ; 122
	i32 22, ; 123
	i32 267, ; 124
	i32 86, ; 125
	i32 43, ; 126
	i32 160, ; 127
	i32 191, ; 128
	i32 71, ; 129
	i32 280, ; 130
	i32 325, ; 131
	i32 3, ; 132
	i32 42, ; 133
	i32 63, ; 134
	i32 339, ; 135
	i32 16, ; 136
	i32 225, ; 137
	i32 222, ; 138
	i32 53, ; 139
	i32 336, ; 140
	i32 303, ; 141
	i32 105, ; 142
	i32 224, ; 143
	i32 312, ; 144
	i32 329, ; 145
	i32 301, ; 146
	i32 264, ; 147
	i32 34, ; 148
	i32 158, ; 149
	i32 85, ; 150
	i32 32, ; 151
	i32 338, ; 152
	i32 12, ; 153
	i32 51, ; 154
	i32 205, ; 155
	i32 56, ; 156
	i32 284, ; 157
	i32 36, ; 158
	i32 199, ; 159
	i32 302, ; 160
	i32 237, ; 161
	i32 35, ; 162
	i32 319, ; 163
	i32 58, ; 164
	i32 201, ; 165
	i32 271, ; 166
	i32 173, ; 167
	i32 17, ; 168
	i32 309, ; 169
	i32 188, ; 170
	i32 164, ; 171
	i32 197, ; 172
	i32 341, ; 173
	i32 206, ; 174
	i32 335, ; 175
	i32 331, ; 176
	i32 270, ; 177
	i32 226, ; 178
	i32 210, ; 179
	i32 297, ; 180
	i32 337, ; 181
	i32 153, ; 182
	i32 203, ; 183
	i32 293, ; 184
	i32 278, ; 185
	i32 239, ; 186
	i32 29, ; 187
	i32 52, ; 188
	i32 223, ; 189
	i32 189, ; 190
	i32 187, ; 191
	i32 179, ; 192
	i32 298, ; 193
	i32 5, ; 194
	i32 317, ; 195
	i32 288, ; 196
	i32 292, ; 197
	i32 244, ; 198
	i32 313, ; 199
	i32 236, ; 200
	i32 255, ; 201
	i32 326, ; 202
	i32 85, ; 203
	i32 297, ; 204
	i32 61, ; 205
	i32 112, ; 206
	i32 346, ; 207
	i32 57, ; 208
	i32 347, ; 209
	i32 284, ; 210
	i32 99, ; 211
	i32 19, ; 212
	i32 248, ; 213
	i32 111, ; 214
	i32 101, ; 215
	i32 176, ; 216
	i32 102, ; 217
	i32 315, ; 218
	i32 104, ; 219
	i32 301, ; 220
	i32 71, ; 221
	i32 38, ; 222
	i32 32, ; 223
	i32 103, ; 224
	i32 73, ; 225
	i32 321, ; 226
	i32 9, ; 227
	i32 123, ; 228
	i32 46, ; 229
	i32 238, ; 230
	i32 214, ; 231
	i32 9, ; 232
	i32 43, ; 233
	i32 4, ; 234
	i32 285, ; 235
	i32 207, ; 236
	i32 205, ; 237
	i32 345, ; 238
	i32 31, ; 239
	i32 138, ; 240
	i32 92, ; 241
	i32 93, ; 242
	i32 49, ; 243
	i32 141, ; 244
	i32 112, ; 245
	i32 140, ; 246
	i32 254, ; 247
	i32 115, ; 248
	i32 302, ; 249
	i32 157, ; 250
	i32 76, ; 251
	i32 79, ; 252
	i32 274, ; 253
	i32 37, ; 254
	i32 296, ; 255
	i32 175, ; 256
	i32 258, ; 257
	i32 251, ; 258
	i32 64, ; 259
	i32 138, ; 260
	i32 15, ; 261
	i32 116, ; 262
	i32 290, ; 263
	i32 299, ; 264
	i32 246, ; 265
	i32 48, ; 266
	i32 70, ; 267
	i32 80, ; 268
	i32 126, ; 269
	i32 94, ; 270
	i32 121, ; 271
	i32 310, ; 272
	i32 26, ; 273
	i32 267, ; 274
	i32 97, ; 275
	i32 28, ; 276
	i32 242, ; 277
	i32 316, ; 278
	i32 149, ; 279
	i32 227, ; 280
	i32 169, ; 281
	i32 4, ; 282
	i32 98, ; 283
	i32 33, ; 284
	i32 93, ; 285
	i32 289, ; 286
	i32 208, ; 287
	i32 21, ; 288
	i32 41, ; 289
	i32 185, ; 290
	i32 170, ; 291
	i32 332, ; 292
	i32 260, ; 293
	i32 324, ; 294
	i32 274, ; 295
	i32 309, ; 296
	i32 299, ; 297
	i32 279, ; 298
	i32 2, ; 299
	i32 183, ; 300
	i32 134, ; 301
	i32 111, ; 302
	i32 209, ; 303
	i32 229, ; 304
	i32 341, ; 305
	i32 58, ; 306
	i32 0, ; 307
	i32 95, ; 308
	i32 174, ; 309
	i32 323, ; 310
	i32 39, ; 311
	i32 240, ; 312
	i32 25, ; 313
	i32 94, ; 314
	i32 317, ; 315
	i32 89, ; 316
	i32 99, ; 317
	i32 305, ; 318
	i32 10, ; 319
	i32 181, ; 320
	i32 87, ; 321
	i32 189, ; 322
	i32 328, ; 323
	i32 100, ; 324
	i32 286, ; 325
	i32 190, ; 326
	i32 193, ; 327
	i32 310, ; 328
	i32 231, ; 329
	i32 320, ; 330
	i32 7, ; 331
	i32 271, ; 332
	i32 228, ; 333
	i32 88, ; 334
	i32 195, ; 335
	i32 184, ; 336
	i32 266, ; 337
	i32 154, ; 338
	i32 319, ; 339
	i32 33, ; 340
	i32 204, ; 341
	i32 181, ; 342
	i32 116, ; 343
	i32 82, ; 344
	i32 184, ; 345
	i32 20, ; 346
	i32 304, ; 347
	i32 11, ; 348
	i32 162, ; 349
	i32 3, ; 350
	i32 219, ; 351
	i32 327, ; 352
	i32 212, ; 353
	i32 209, ; 354
	i32 84, ; 355
	i32 196, ; 356
	i32 314, ; 357
	i32 64, ; 358
	i32 211, ; 359
	i32 329, ; 360
	i32 293, ; 361
	i32 143, ; 362
	i32 202, ; 363
	i32 175, ; 364
	i32 180, ; 365
	i32 275, ; 366
	i32 157, ; 367
	i32 41, ; 368
	i32 117, ; 369
	i32 194, ; 370
	i32 230, ; 371
	i32 282, ; 372
	i32 131, ; 373
	i32 75, ; 374
	i32 66, ; 375
	i32 217, ; 376
	i32 333, ; 377
	i32 172, ; 378
	i32 234, ; 379
	i32 143, ; 380
	i32 106, ; 381
	i32 151, ; 382
	i32 70, ; 383
	i32 327, ; 384
	i32 156, ; 385
	i32 193, ; 386
	i32 121, ; 387
	i32 127, ; 388
	i32 328, ; 389
	i32 152, ; 390
	i32 257, ; 391
	i32 188, ; 392
	i32 141, ; 393
	i32 244, ; 394
	i32 325, ; 395
	i32 20, ; 396
	i32 14, ; 397
	i32 135, ; 398
	i32 75, ; 399
	i32 59, ; 400
	i32 247, ; 401
	i32 167, ; 402
	i32 168, ; 403
	i32 216, ; 404
	i32 15, ; 405
	i32 74, ; 406
	i32 6, ; 407
	i32 23, ; 408
	i32 331, ; 409
	i32 269, ; 410
	i32 228, ; 411
	i32 91, ; 412
	i32 326, ; 413
	i32 1, ; 414
	i32 136, ; 415
	i32 330, ; 416
	i32 270, ; 417
	i32 292, ; 418
	i32 134, ; 419
	i32 69, ; 420
	i32 146, ; 421
	i32 203, ; 422
	i32 335, ; 423
	i32 178, ; 424
	i32 314, ; 425
	i32 261, ; 426
	i32 210, ; 427
	i32 88, ; 428
	i32 96, ; 429
	i32 251, ; 430
	i32 256, ; 431
	i32 330, ; 432
	i32 31, ; 433
	i32 45, ; 434
	i32 265, ; 435
	i32 182, ; 436
	i32 202, ; 437
	i32 230, ; 438
	i32 109, ; 439
	i32 158, ; 440
	i32 35, ; 441
	i32 22, ; 442
	i32 114, ; 443
	i32 57, ; 444
	i32 290, ; 445
	i32 144, ; 446
	i32 118, ; 447
	i32 120, ; 448
	i32 110, ; 449
	i32 232, ; 450
	i32 139, ; 451
	i32 238, ; 452
	i32 316, ; 453
	i32 54, ; 454
	i32 105, ; 455
	i32 336, ; 456
	i32 218, ; 457
	i32 219, ; 458
	i32 133, ; 459
	i32 308, ; 460
	i32 295, ; 461
	i32 283, ; 462
	i32 342, ; 463
	i32 261, ; 464
	i32 221, ; 465
	i32 159, ; 466
	i32 248, ; 467
	i32 163, ; 468
	i32 132, ; 469
	i32 283, ; 470
	i32 161, ; 471
	i32 177, ; 472
	i32 272, ; 473
	i32 304, ; 474
	i32 140, ; 475
	i32 183, ; 476
	i32 295, ; 477
	i32 291, ; 478
	i32 169, ; 479
	i32 220, ; 480
	i32 233, ; 481
	i32 300, ; 482
	i32 40, ; 483
	i32 259, ; 484
	i32 81, ; 485
	i32 56, ; 486
	i32 37, ; 487
	i32 97, ; 488
	i32 166, ; 489
	i32 172, ; 490
	i32 204, ; 491
	i32 296, ; 492
	i32 82, ; 493
	i32 235, ; 494
	i32 98, ; 495
	i32 30, ; 496
	i32 159, ; 497
	i32 18, ; 498
	i32 127, ; 499
	i32 213, ; 500
	i32 119, ; 501
	i32 178, ; 502
	i32 255, ; 503
	i32 286, ; 504
	i32 180, ; 505
	i32 268, ; 506
	i32 288, ; 507
	i32 306, ; 508
	i32 200, ; 509
	i32 165, ; 510
	i32 263, ; 511
	i32 182, ; 512
	i32 349, ; 513
	i32 322, ; 514
	i32 285, ; 515
	i32 276, ; 516
	i32 307, ; 517
	i32 170, ; 518
	i32 16, ; 519
	i32 144, ; 520
	i32 125, ; 521
	i32 118, ; 522
	i32 38, ; 523
	i32 115, ; 524
	i32 47, ; 525
	i32 142, ; 526
	i32 117, ; 527
	i32 34, ; 528
	i32 173, ; 529
	i32 95, ; 530
	i32 53, ; 531
	i32 277, ; 532
	i32 196, ; 533
	i32 129, ; 534
	i32 153, ; 535
	i32 24, ; 536
	i32 161, ; 537
	i32 254, ; 538
	i32 148, ; 539
	i32 104, ; 540
	i32 305, ; 541
	i32 89, ; 542
	i32 242, ; 543
	i32 60, ; 544
	i32 142, ; 545
	i32 100, ; 546
	i32 5, ; 547
	i32 13, ; 548
	i32 122, ; 549
	i32 135, ; 550
	i32 192, ; 551
	i32 28, ; 552
	i32 322, ; 553
	i32 72, ; 554
	i32 252, ; 555
	i32 24, ; 556
	i32 240, ; 557
	i32 281, ; 558
	i32 278, ; 559
	i32 339, ; 560
	i32 137, ; 561
	i32 233, ; 562
	i32 249, ; 563
	i32 168, ; 564
	i32 282, ; 565
	i32 318, ; 566
	i32 101, ; 567
	i32 123, ; 568
	i32 253, ; 569
	i32 195, ; 570
	i32 186, ; 571
	i32 198, ; 572
	i32 163, ; 573
	i32 167, ; 574
	i32 256, ; 575
	i32 39, ; 576
	i32 215, ; 577
	i32 337, ; 578
	i32 17, ; 579
	i32 171, ; 580
	i32 338, ; 581
	i32 137, ; 582
	i32 150, ; 583
	i32 245, ; 584
	i32 217, ; 585
	i32 155, ; 586
	i32 130, ; 587
	i32 19, ; 588
	i32 65, ; 589
	i32 147, ; 590
	i32 47, ; 591
	i32 346, ; 592
	i32 348, ; 593
	i32 231, ; 594
	i32 79, ; 595
	i32 61, ; 596
	i32 177, ; 597
	i32 106, ; 598
	i32 280, ; 599
	i32 235, ; 600
	i32 49, ; 601
	i32 266, ; 602
	i32 343, ; 603
	i32 277, ; 604
	i32 14, ; 605
	i32 185, ; 606
	i32 194, ; 607
	i32 68, ; 608
	i32 171, ; 609
	i32 241, ; 610
	i32 245, ; 611
	i32 191, ; 612
	i32 78, ; 613
	i32 186, ; 614
	i32 250, ; 615
	i32 108, ; 616
	i32 234, ; 617
	i32 276, ; 618
	i32 67, ; 619
	i32 63, ; 620
	i32 27, ; 621
	i32 160, ; 622
	i32 318, ; 623
	i32 197, ; 624
	i32 211, ; 625
	i32 243, ; 626
	i32 176, ; 627
	i32 10, ; 628
	i32 215, ; 629
	i32 11, ; 630
	i32 78, ; 631
	i32 126, ; 632
	i32 83, ; 633
	i32 199, ; 634
	i32 66, ; 635
	i32 107, ; 636
	i32 65, ; 637
	i32 128, ; 638
	i32 122, ; 639
	i32 77, ; 640
	i32 291, ; 641
	i32 281, ; 642
	i32 8, ; 643
	i32 249, ; 644
	i32 2, ; 645
	i32 187, ; 646
	i32 334, ; 647
	i32 44, ; 648
	i32 294, ; 649
	i32 156, ; 650
	i32 128, ; 651
	i32 279, ; 652
	i32 23, ; 653
	i32 133, ; 654
	i32 237, ; 655
	i32 268, ; 656
	i32 307, ; 657
	i32 29, ; 658
	i32 236, ; 659
	i32 227, ; 660
	i32 62, ; 661
	i32 223, ; 662
	i32 174, ; 663
	i32 218, ; 664
	i32 90, ; 665
	i32 87, ; 666
	i32 148, ; 667
	i32 206, ; 668
	i32 320, ; 669
	i32 220, ; 670
	i32 36, ; 671
	i32 86, ; 672
	i32 257, ; 673
	i32 344, ; 674
	i32 198, ; 675
	i32 50, ; 676
	i32 6, ; 677
	i32 225, ; 678
	i32 90, ; 679
	i32 344, ; 680
	i32 21, ; 681
	i32 162, ; 682
	i32 96, ; 683
	i32 50, ; 684
	i32 113, ; 685
	i32 273, ; 686
	i32 130, ; 687
	i32 222, ; 688
	i32 76, ; 689
	i32 27, ; 690
	i32 333, ; 691
	i32 250, ; 692
	i32 272, ; 693
	i32 7, ; 694
	i32 216, ; 695
	i32 110, ; 696
	i32 306, ; 697
	i32 273, ; 698
	i32 259 ; 699
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ af27162bee43b7fecdca59b4f67aa8c175cbc875"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
