Sub FormatReport()
 InsertHyperlink
 InsertPics
End Sub


Sub InsertPics()

Dim ws As Worksheet
Set ws = ThisWorkbook.Worksheets("Report")

Dim lastrow As Long
lastrow = ws.Cells(ws.Rows.Count, "A").End(xlUp).Row

Dim targetColumn As Range
Set targetColumn = ws.Range("G2:G" & lastrow)

Dim cell As Range

Dim topCoord As Long
Dim leftCoord As Long
Dim picHeight As Long
Dim picWidth As Long

picHeight = 100
picWidth = 150

For Each cell In targetColumn

    topCoord = Range(cell.Address).Top + Range(cell.Address).Height / 2 - picHeight / 2
    leftCoord = Range(cell.Address).Left + Range(cell.Address).Width / 2 - picWidth / 2

    If cell.Value <> "-" Then
        ws.Shapes.AddPicture cell.Value, msoFalse, msoCTrue, leftCoord, topCoord, picWidth, picHeight
    End If

    cell.Value = ""
Next

End Sub

Sub InsertHyperlink()

Dim ws As Worksheet
Set ws = ThisWorkbook.Worksheets("Report")

Dim lastrow As Long
lastrow = ws.Cells(ws.Rows.Count, "A").End(xlUp).Row

Dim targetColumn As Range
Set targetColumn = ws.Range("B2:B" & lastrow)

Dim cell As Range
Dim link As String

For Each cell In targetColumn
    link = cell.Value
    cell.Value = ""
    ws.Hyperlinks.Add Anchor:=cell, Address:=link, TextToDisplay:="URL"
    cell.VerticalAlignment = xlCenter
    cell.HorizontalAlignment = xlCenter
Next
End Sub

