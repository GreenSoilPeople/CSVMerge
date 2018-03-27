Imports System.IO
Imports CommandLine

Module Program

    Sub Main()

        Dim args As String() = My.Application.CommandLineArgs.ToArray

        CommandLine.Parser.Default.ParseArguments(Of Options)(args) _
        .WithParsed(Function(opts As Options) FileProcess.MergeFiles(opts)) _
        .WithNotParsed(Function(errs As IEnumerable(Of [Error])) FileProcess.WriteErrors(errs))

    End Sub



End Module
