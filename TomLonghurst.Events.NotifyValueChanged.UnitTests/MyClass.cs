﻿using System.Collections.Generic;
using TomLonghurst.Events.NotifyValueChanged.SourceGeneration.Implementation;

namespace TomLonghurst.Events.NotifyValueChanged.UnitTests;

public partial class MyClass
{
    [NotifyValueChange(GenerateGenericTypeValueChangeEvent = true)]
    private string _myString1;
    
    [NotifyValueChange]
    private string _myString2;
    
    [NotifyValueChange]
    private int _myInt1;
    
    [NotifyValueChange]
    private int _myInt2;
    
    [NotifyValueChange]
    private int? _myNullableInt1;
    
    [NotifyValueChange]
    private int? _myNullableInt2;

    [NotifyValueChange]
    private IEnumerable<string> _genericEnumerable;
    
    [NotifyValueChange]
    private IEnumerable<string>? _genericNullableEnumerable;
    
    [NotifyValueChange]
    private IEnumerable<string?> _genericEnumerableWithNullableTypeParameter;
    
    [NotifyValueChange]
    private IEnumerable<string?>? _genericNullableEnumerableWithNullableTypeParameter;
    
    [NotifyValueChange]
    private IDictionary<string, int> _genericWithTwoTypeParameters;
    
    [NotifyValueChange]
    private IDictionary<string?, int> _genericWithTwoTypeParametersNullableFirstType;
    
    [NotifyValueChange]
    private IDictionary<string, int?> _genericWithTwoTypeParametersNullableSecondType;
    
    [NotifyValueChange]
    private IDictionary<string?, int?> _genericWithTwoTypeParametersNullableBothType;
    
    [NotifyValueChange]
    private IDictionary<string, int>? _nullableGenericWithTwoTypeParameters;
    
    [NotifyValueChange]
    private IDictionary<string?, int>? _nullableGenericWithTwoTypeParametersNullableFirstType;
    
    [NotifyValueChange]
    private IDictionary<string, int?>? _nullableGenericWithTwoTypeParametersNullableSecondType;
    
    [NotifyValueChange]
    private IDictionary<string?, int?>? _nullableGenericWithTwoTypeParametersNullableBothType;
}