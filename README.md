# NotifyValueChanged - Automatic Event Firing on Property Value Changes

A source generated approach, to turn your backing fields into properties that can fire events when their value changes - Automagically!

[![nuget](https://img.shields.io/nuget/v/TomLonghurst.Events.NotifyValueChanged.svg)](https://www.nuget.org/packages/TomLonghurst.Events.NotifyValueChanged/)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/16305948c33040f0982da5322df8d8e1)](https://www.codacy.com/gh/thomhurst/NotifyValueChanged/dashboard?utm_source=github.com&utm_medium=referral&utm_content=thomhurst/NotifyValueChanged&utm_campaign=Badge_Grade)
[![CodeFactor](https://www.codefactor.io/repository/github/thomhurst/notifyvaluechanged/badge)](https://www.codefactor.io/repository/github/thomhurst/notifyvaluechanged)

## Support

If this library helped you, consider buying me a coffee

<a href="https://www.buymeacoffee.com/tomhurst" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a>

## Installation

Install via Nuget
`Install-Package TomLonghurst.Events.NotifyValueChanged`

## Usage

-   Make your class `partial` 
-   Declare a `private` _field_ - This is the backing field for which the property will be generated for.
-   Add the `[NotifyValueChange]` attribute to the field
-   That's it!

```csharp
public partial class Person
{
    [NotifyValueChange]
    private string _name;
}
```

Your class now has a property called `Name` - And you can subscribe to an event called `OnNameValueChange` that will fire whenever the value of `Name` changes.

You can do this for multiple fields, and each one should generate you a separate event that you can subscribe to called `On{PropertyName}ValueChange`

```csharp
var person = new Person();

person.OnNameValueChange += (sender, eventArgs) =>
{
    Console.WriteLine($"Name was: '{eventArgs.PreviousValue}' and is now '{eventArgs.NewValue}'\n");
};

person.Name = "Tom"; // Event will fire and log to the console "Name was: '' and is now 'Tom'"
person.Name = "Tom"; // No event will fire because the value hasn't changed
person.Name = ""; // Event will fire and log to the console "Name was: 'Tom' and is now ''"
```

If your class implements an interface and you want this event to be exposed on the interface, then:

-   Make your interface partial
-   Declare the property on the interface as normal
-   Add the attribute `[GenerateInterfaceValueChangeEvent`]

```csharp
public partial interface IPerson
{
    [GenerateInterfaceValueChangeEvent]
    private string Name { get; }
}
```
