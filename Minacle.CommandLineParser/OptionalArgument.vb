Public Class OptionalArgument
  Inherits Argument

  Public Property ShortName As Char
  Public Property IsSwitch As Boolean
  Public Property SwitchValue As Object

  Public Sub New(name As String, type As Type)
    MyBase.New(name, type)
  End Sub

  Public Sub New(shortName As Char, type As Type)
    MyBase.New(shortName, type)
    Me.ShortName = shortName
  End Sub

  Public Sub New(name As String, shortName As Char, type As Type)
    MyBase.New(name, type)
    Me.ShortName = shortName
  End Sub

  Public Sub New(name As String, type As Type, [default] As Object)
    MyBase.New(name, type, [default])
  End Sub

  Public Sub New(shortName As Char, type As Type, [default] As Object)
    MyBase.New(shortName, type, [default])
    Me.ShortName = shortName
  End Sub

  Public Sub New(name As String, shortName As Char, type As Type, [default] As Object)
    MyBase.New(name, type, [default])
    Me.ShortName = shortName
  End Sub

  Public Sub New(name As String, isSwitch As Boolean)
    MyBase.New(name, GetType(Boolean), False)
    Me.IsSwitch = isSwitch
    Me.SwitchValue = True
  End Sub

  Public Sub New(shortName As Char, isSwitch As Boolean)
    MyBase.New(shortName, GetType(Boolean), False)
    Me.ShortName = shortName
    Me.IsSwitch = isSwitch
    Me.SwitchValue = True
  End Sub

  Public Sub New(name As String, shortName As Char, isSwitch As Boolean)
    MyBase.New(name, GetType(Boolean), False)
    Me.ShortName = shortName
    Me.IsSwitch = isSwitch
    Me.SwitchValue = True
  End Sub

  Public Sub New(name As String, type As Type, [default] As Object, isSwitch As Boolean, switchValue As Object)
    MyBase.New(name, type, [default])
    Me.IsSwitch = isSwitch
    Me.SwitchValue = switchValue
  End Sub

  Public Sub New(shortName As Char, type As Type, [default] As Object, isSwitch As Boolean, switchValue As Object)
    MyBase.New(shortName, type, [default])
    Me.ShortName = shortName
    Me.IsSwitch = isSwitch
    Me.SwitchValue = switchValue
  End Sub

  Public Sub New(name As String, shortName As Char, type As Type, [default] As Object, isSwitch As Boolean, switchValue As Object)
    MyBase.New(name, type, [default])
    Me.ShortName = ShortName
    Me.IsSwitch = isSwitch
    Me.SwitchValue = switchValue
  End Sub
End Class
