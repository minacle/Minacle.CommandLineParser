Public Class PositionalArgument
  Inherits Argument

  Public Sub New(name As String, type As Type)
    MyBase.New(name, type)
  End Sub

  Public Sub New(name As String, type As Type, [default] As Object)
    MyBase.New(name, type)
  End Sub
End Class
