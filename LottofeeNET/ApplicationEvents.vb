Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.Devices

Namespace My

  Partial Friend NotInheritable Class MyApplication

    Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles _
      Me.ApplyApplicationDefaults

    End Sub

    Private Sub MyApplication_NetworkAvailabilityChanged(sender As Object, e As NetworkAvailableEventArgs) Handles _
      Me.NetworkAvailabilityChanged

    End Sub

    Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles _
      Me.Shutdown

    End Sub

    Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles _
      Me.Startup

    End Sub

    Private Sub MyApplication_StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs) Handles _
      Me.StartupNextInstance

    End Sub

    Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles _
      Me.UnhandledException

    End Sub

  End Class

End Namespace
