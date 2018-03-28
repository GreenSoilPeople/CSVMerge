Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CSVMerge

<TestClass()>
Public Class UnitTest1

    <TestMethod>
    Public Sub Return1IfNoFilesInDir()
        Dim _opt As New Options With {.InputDir = "\", .Extension = "*.csv", .OutputFile = "output.csv"}
        Dim result As Integer = FileProcess.MergeFiles(_opt)

        Assert.AreEqual(1, result)
    End Sub

    <TestMethod>
    Public Sub Return2IfDirDoesNotExist()
        Dim _opt As New Options With {.InputDir = "adfjao4h4", .Extension = "*.csv", .OutputFile = "output.csv"}
        Dim result As Integer = FileProcess.MergeFiles(_opt)

        Assert.AreEqual(2, result)
    End Sub

    <TestMethod>
    Public Sub Return3IfSpecifiedHeaderFileDoesNotExist()
        Dim _opt As New Options With {.InputDir = "D:\TEST\cqs\test", .Extension = "*.csv", .OutputFile = "output.csv", .HeaderFile = "asdasda"}
        Dim result As Integer = FileProcess.MergeFiles(_opt)

        Assert.AreEqual(3, result)
    End Sub

    <TestMethod>
    Friend Sub Return0IfAllOk()
        Dim _opt As New Options With {.InputDir = "D:\TEST\cqs\test", .Extension = "*.csv", .OutputFile = "output.csv", .HeaderFile = "D:\TEST\cqs\test\1.csv"}
        Dim result As Integer = FileProcess.MergeFiles(_opt)

        Assert.AreEqual(0, result)
    End Sub
End Class