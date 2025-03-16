' *************************************************************************************************
' 
' Form1.vb
' Copyright (c)2025 by Andreas Sauer 
'
' *************************************************************************************************

Imports System.ComponentModel

Public Class FormMain

  Private _Random As New Random
  Private _ZahlenListe As New List(Of Integer)

  Public Sub New()
    ' Dieser Aufruf ist für den Designer erforderlich.
    InitializeComponent()
    ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
    SetFormPropertys()
    SetGroupBoxTitle()
    ClearLabels()
  End Sub

  Private Sub ClearLabels()
    For i As Integer = 1 To 7
      SetLabelText(i, $"")
    Next
  End Sub

  <CodeAnalysis.SuppressMessage("Globalization", "CA1305:IFormatProvider angeben", Justification:="<Ausstehend>")>
  Private Sub SetGroupBoxTitle()
    Dim groupboxtitle As String = My.Resources.GroupBoxTitle
    Dim datum As String = Now.Date.ToLongDateString
    GroupBox.Text = String.Format(groupboxtitle, datum)
  End Sub

  Private Sub SetLabelText(LabelNumber As Integer, Text As String)
    Dim labelname As String = $"Label{LabelNumber}"
    Dim label As Label = CType(GroupBox.Controls(labelname), Label)
    label.Text = Text
  End Sub

  <CodeAnalysis.SuppressMessage("Globalization", "CA1305:IFormatProvider angeben", Justification:="<Ausstehend>")>
  Private Sub SetFormPropertys()
    Dim version As Version = My.Application.Info.Version
    Dim copyright As String = My.Application.Info.Copyright
    Dim companyname As String = My.Application.Info.CompanyName
    Dim formtitle As String = My.Resources.FormMainTitle
    Text = String.Format(formtitle, version, copyright, companyname)
    Icon = My.Resources.Lottofee
  End Sub

  Private Sub FormMain_Closing(sender As Object, e As CancelEventArgs) Handles _
    Me.Closing
    My.Settings.LocationX = Location.X
    My.Settings.LocationY = Location.Y
    My.Settings.Save()
  End Sub

  Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles _
    Me.Load
    Dim point As New Point With {.X = My.Settings.LocationX, .Y = My.Settings.LocationY}
    Location = point
  End Sub

  Private Sub ButtonNeueZiehung_Click(sender As Object, e As EventArgs) Handles _
    ButtonNeueZiehung.Click
    Dim button As Button = CType(sender, Button)
    button.Enabled = False
    ClearLabels()
    CreateNewZahlen()
    ShowNewZahlen()
    button.Enabled = True
  End Sub

  Private Sub ButtonNeueZiehung_EnabledChanged(sender As Object, e As EventArgs) Handles _
    ButtonNeueZiehung.EnabledChanged
    Dim Button As Button = CType(sender, Button)
    If Button.Enabled Then
      Cursor = Cursors.Default
    Else
      Cursor = Cursors.WaitCursor
    End If
  End Sub

  Private Sub CreateNewZahlen()
    _ZahlenListe.Clear() 'alte Zahlen löschen
    Dim Zahl As Integer
    For i As Integer = 1 To 7
      Do
        Zahl = _Random.Next(1, 50) '50 ist exklusiv, daher wird 1 bis 49 generiert
      Loop While _ZahlenListe.Contains(zahl) 'verhindert das eine Zahl doppelt erzeugt wird
      _ZahlenListe.Add(Zahl)
    Next
  End Sub

  Private Sub ShowNewZahlen()
    For i As Integer = 1 To 7
      SetLabelText(i, $"{_ZahlenListe.ElementAt(i - 1)}")
      Task.Delay(1000).Wait() '1 Sekunde warten
    Next
  End Sub

End Class
