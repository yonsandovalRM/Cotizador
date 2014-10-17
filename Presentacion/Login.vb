Imports Negocio

Public Class Login
    Private iOK As Int32

    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim cn As New CapaNegocio
        Dim mensaje As Boolean

        ' valido que hayan digitado algun dato en el campo usuario
        If Trim(Me.UsernameTextBox.Text) = "" Then
            MsgBox("Debe Ingresar su Usuario")
            Me.UsernameTextBox.Focus()
            Exit Sub
        End If
        ' valido que hayan digitado algun dato en el campo clave
        If Trim(Me.PasswordTextBox.Text) = "" Then
            MsgBox("Debe Ingresar su Clave")
            Me.PasswordTextBox.Focus()
            Exit Sub
        End If

        mensaje = cn.ValidaUsuario(Me.UsernameTextBox.Text, Me.PasswordTextBox.Text)

        If mensaje = True Then
            MenuPrincipal.Show()
            Me.Visible = False
        Else
            MsgBox("Error")
        End If


    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        End
    End Sub

End Class
