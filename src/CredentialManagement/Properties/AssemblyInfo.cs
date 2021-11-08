using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: Guid("0385cfa9-49d6-4b5e-bcf7-b0e40b0355f1")]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: InternalsVisibleTo("WindowsCredentialsManagement.Tests")]
[assembly: InternalsVisibleTo("WindowsCredentialsManagement.Explorables")]
[assembly: CompilationRelaxations(8)]
[assembly: SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "CredentialManagement.CredentialSet.#LoadInternal()")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible", Scope = "member", Target = "CredentialManagement.NativeMethods+CREDUI_INFO.#hwndParent")]
[assembly: SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "CredentialManagement.XPPrompt.#ShowDialog(System.IntPtr)")]
[assembly: AssemblyTitle("CredentialManagement")]
[assembly: AssemblyDescription("Windows Credential Management Library")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("iLya Lozovyy")]
[assembly: AssemblyProduct("CredentialManagement")]
[assembly: AssemblyCopyright("Copyright © iLya Lozovyy 2014")]
[assembly: AssemblyFileVersion("1.0.2")]
[assembly: SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "CredentialManagement.BaseCredentialsPrompt.#CreateCREDUI_INFO(System.IntPtr)")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments", MessageId = "7", Scope = "member", Target = "CredentialManagement.NativeMethods.#CredUnPackAuthenticationBuffer(System.Int32,System.IntPtr,System.UInt32,System.Text.StringBuilder,System.Int32&,System.Text.StringBuilder,System.Int32&,System.Text.StringBuilder,System.Int32&)")]
[assembly: SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "CredentialManagement.XPPrompt.#CreateCREDUI_INFO(System.IntPtr)")]
[assembly: SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible", Scope = "member", Target = "CredentialManagement.NativeMethods+CREDUI_INFO.#hbmBanner")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments", MessageId = "6", Scope = "member", Target = "CredentialManagement.NativeMethods.#CredUIPromptForCredentials(CredentialManagement.NativeMethods+CREDUI_INFO&,System.String,System.IntPtr,System.Int32,System.Text.StringBuilder,System.Int32,System.Text.StringBuilder,System.Int32,System.Boolean&,System.Int32)")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments", MessageId = "4", Scope = "member", Target = "CredentialManagement.NativeMethods.#CredUIPromptForCredentials(CredentialManagement.NativeMethods+CREDUI_INFO&,System.String,System.IntPtr,System.Int32,System.Text.StringBuilder,System.Int32,System.Text.StringBuilder,System.Int32,System.Boolean&,System.Int32)")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments", MessageId = "1", Scope = "member", Target = "CredentialManagement.NativeMethods.#CredUIPromptForCredentials(CredentialManagement.NativeMethods+CREDUI_INFO&,System.String,System.IntPtr,System.Int32,System.Text.StringBuilder,System.Int32,System.Text.StringBuilder,System.Int32,System.Boolean&,System.Int32)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable", Scope = "type", Target = "CredentialManagement.NativeMethods+CREDENTIAL")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments", MessageId = "5", Scope = "member", Target = "CredentialManagement.NativeMethods.#CredUnPackAuthenticationBuffer(System.Int32,System.IntPtr,System.UInt32,System.Text.StringBuilder,System.Int32&,System.Text.StringBuilder,System.Int32&,System.Text.StringBuilder,System.Int32&)")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments", MessageId = "3", Scope = "member", Target = "CredentialManagement.NativeMethods.#CredUnPackAuthenticationBuffer(System.Int32,System.IntPtr,System.UInt32,System.Text.StringBuilder,System.Int32&,System.Text.StringBuilder,System.Int32&,System.Text.StringBuilder,System.Int32&)")]
[assembly: SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "CredentialManagement.SecureStringHelper.#CreateString(System.Security.SecureString)")]
[assembly: SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands", Scope = "member", Target = "CredentialManagement.VistaPrompt.#ShowDialog(System.IntPtr)")]
[assembly: SuppressMessage("Microsoft.Interoperability", "CA1404:CallGetLastErrorImmediatelyAfterPInvoke", Scope = "member", Target = "CredentialManagement.VistaPrompt.#ShowDialog(System.IntPtr)")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.2.0")]
[module: UnverifiableCode]
