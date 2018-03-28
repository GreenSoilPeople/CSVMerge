Imports System.IO
Imports System.Runtime.CompilerServices
Imports CommandLine

<Assembly: InternalsVisibleTo("UnitTestProject1")>
Public Class FileProcess
    Public Shared Function MergeFiles(opts As Options) As Integer

        Dim fileList As List(Of String)
        Dim sr As StreamReader
        Dim sw As StreamWriter

        If String.IsNullOrWhiteSpace(opts.InputDir) Then
            opts.InputDir = Environment.CurrentDirectory
        ElseIf Not Directory.Exists(opts.InputDir) Then
            Console.WriteLine("Input directory does not exist.")
            Return 2
        End If

        fileList = Directory.GetFiles(opts.InputDir, opts.Extension).ToList

        'remove output file from file list
        fileList.RemoveAll(Function(f) Path.GetFileName(f).Equals(opts.OutputFile))

        If fileList.Count < 1 Then Return 1

        Dim header As String
        'read header line
        If Not String.IsNullOrWhiteSpace(opts.HeaderFile) Then
            If Not File.Exists(opts.HeaderFile) Then
                Console.WriteLine("Header file does not exist.")
                Return 3
            End If
            header = ReadHeader(opts.HeaderFile)
        Else
            header = ReadHeader(fileList(0))
        End If

        'if append flag is set then append output
        sw = New StreamWriter(opts.OutputFile, IIf(opts.Append, True, False))
        sw.WriteLine(header)

        For Each filePath As String In fileList
            sr = New StreamReader(filePath)

            Dim line As String = ""

            While Not sr.EndOfStream
                line = sr.ReadLine

                If Not line.Equals(header) Then
                    sw.WriteLine(line)
                End If
            End While
        Next

        Console.WriteLine("All files have been processed.")
        Return 0
    End Function

    Friend Shared Function ReadHeader(path As String)
        If Not File.Exists(path) Then Return Nothing
        Dim sr = New StreamReader(path)
        Return sr.ReadLine()
    End Function

    Public Shared Function WriteErrors(errs As IEnumerable(Of [Error]))
        For Each er In errs
            Console.WriteLine(er.Tag)
        Next
    End Function
End Class
