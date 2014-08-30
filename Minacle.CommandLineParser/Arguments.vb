Public Class Arguments

  Private _args As IList(Of Argument)

  Public Property OptionalPrefix As Char = "-"c
  Public Property OptionalAssignmentOperator As Char = "="c

  Public Sub New()
    _args = New List(Of Argument)
  End Sub

  Public Sub AddArgument(arg As Argument)
    _args.Add(arg)
  End Sub

  Public Function ParseArgs(commandLineArgs As IEnumerable(Of String)) As IDictionary(Of String, Object)
    Dim optionalPrefix2 = OptionalPrefix & OptionalPrefix
    Dim flag = False
    Dim result As New Dictionary(Of String, Object)
    For Each word In commandLineArgs
      If word.StartsWith(OptionalPrefix) AndAlso Not flag Then
        For i As Integer = 0 To _args.Count - 1
          Dim arg = _args(i)
          Dim isLong As Boolean
          If Not TypeOf arg Is OptionalArgument Then Continue For
          Dim a = DirectCast(arg, OptionalArgument)
          If word.StartsWith(optionalPrefix2) Then
            If a.Name <> word.Substring(2) AndAlso If(word.Contains(OptionalAssignmentOperator), a.Name <> word.Substring(2, word.IndexOf(OptionalAssignmentOperator) - 2), True) Then Continue For
            isLong = True
          Else
            If a.ShortName <> word.Substring(1) Then Continue For
            isLong = False
          End If
          If a.IsSwitch Then
            result(a.Name) = CTypeDynamic(a.SwitchValue, a.Type)
          Else
            If isLong Then
              result(a.Name) = CTypeDynamic(word.Substring(word.IndexOf(OptionalAssignmentOperator) + 1), a.Type)
            Else
              i += 1
              result(a.Name) = CTypeDynamic(commandLineArgs(i), a.Type)
            End If
          End If
        Next
      Else
        flag = True
        For Each arg In _args
          If Not TypeOf arg Is PositionalArgument AndAlso result.ContainsKey(arg.Name) Then Continue For
          result(arg.Name) = CTypeDynamic(word, arg.Type)
        Next
      End If
    Next
    For Each arg In _args
      If Not result.ContainsKey(arg.Name) Then result.Add(arg.Name, CTypeDynamic(arg.Default, arg.Type))
    Next
    Return result
  End Function
End Class
