Imports CommandLine.Text
Public Class Options

    <CommandLine.Option("e", "extension", [Default]:="*.csv", Required:=False)>
    Public Property Extension As String

    <CommandLine.Option("h", "header file", HelpText:="Specify file that contains header")>
    Public Property HeaderFile As String

    <CommandLine.Value(0, MetaName:="input folder", Required:=True)>
    Public Property InputDir As String

    <CommandLine.Value(1, MetaName:="outpur file", [Default]:="output.csv", Required:=False)>
    Public Property OutputFile As String
End Class
