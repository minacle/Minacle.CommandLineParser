Public MustInherit Class Argument

  Public Property Name As String
  Public Property Type As Type
  Public Property [Default] As Object

  Public Sub New(name As String, type As Type)
    Me.Name = name
    Me.Type = type
  End Sub

  Public Sub New(name As String, type As Type, [default] As Object)
    Me.Name = name
    Me.Type = type
    Me.Default = [default]
  End Sub
End Class
