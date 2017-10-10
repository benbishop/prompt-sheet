## RendrKit.PromptSheet for Xamarin.Forms (Droid and iOS)

Fancy dialogs using shared code for your Xamarin.Forms apps.

## Nuget

* [RendrKit.PromptSheet](https://www.nuget.org/packages/RendrKit.PromptSheet) [![NuGet](https://img.shields.io/nuget/v/RendrKit.PromptSheet.svg?label=NuGet)](https://www.nuget.org/packages/RendrKit.PromptSheet)

## Build

* [![Build status](https://ci.appveyor.com/api/projects/status/ukf2k6olf64lg4bs?svg=true)](https://ci.appveyor.com/project/pauloortins/prompt-sheet)
* CI Nuget Feed: https://ci.appveyor.com/nuget/prompt-sheet-xidf53962l91

## Getting Started

```
PM> Install-Package RendrKit.PromptSheet
```

The page you want to use PromptSheet should have an AbsoluteLayout as root content.

```xaml
...
<ContentPage.Content>
  <AbsoluteLayout HorizontalOptions="FillAndExpand" VerticalOptions="FillAndExpand">
  <!-- Your Content Here -->
            
  </AbsoluteLayout>
</ContentPage.Content>
...  
```

## Showing an Alert Dialog

To show an alert dialog you should call the static method ShowAlert from the static class PromptSheet.

```csharp
var buttonIndex = await PromptSheet.ShowAlert(this.PageContainer, 
"Oops", 
"Sorry, the supplied credentials are incorrect. Do you want to try again?",
"Yes",
new string[]{"No", "Maybe"});
```

### Params

```csharp
Task<int> ShowAlert(AbsoluteLayout targetContainer, 
string title, 
string body, 
string primaryButtonTitle = "Okay",
string[] additionalButtons = null,
AlertSheetStyle style = null)
```

**AbsoluteLayout targetContainer:** Your root view  
**string title:** Popup title  
**string body:** Popup body  
**string primaryButtonTitle:** Title for the primary button    
**string[] additionalButtons:** Titles for secondary buttons   
**AlertSheetStyle style:** Custom Style, see the Styling section

### Return

Button index represents the button that were tapped, 0 for the primary button and increasing for each secondary button.

## Showing an Input Dialog

To show an alert dialog you should call the static method ShowInputPopup from the static class PromptSheet.

```csharp
var inputResult = await PromptSheet.ShowInputPopup(this.PageContainer, 
"We can help!", 
"May we can send you an email to reset your password.", 
new InputOptions() { Placeholder = "Your Email" }, 
new string[] { "Yes, Sent it!", "No, thanks" });
```

### Params

```csharp
Task<InputResult> ShowInputPopup(AbsoluteLayout targetContainer, 
string title,
string body,
InputOptions inputOptions,
string[] buttons,
InputPopupStyle style = null)
```

**AbsoluteLayout targetContainer:** Your root view   
**string title:** Popup title    
**string body:** Popup body  
**InputOptions inputoptions:** Set input custom config, until now, the only property available is the input placeholder   
**string[] buttons:** Popup buttons    
**InputPopupStyle style:** Custom Style, see the Styling section  

### Return

The input popup will return a **InputResult** with the following attributes:

**ButtonIndex:** Button that was tapped  
**InputText:** Text that was typed

## Styling

We can use the AlertSheetStyle and InputPopupStyle to add custom styling for the dialogs.

```csharp
// AlertSheetStyle.cs
public class AlertSheetStyle : SheetViewStyle
{
  public SheetLabelStyle TitleLabelStyle { get; set; }
  public SheetLabelStyle BodyLabelStyle { get; set; }
  public SheetButtonStyle PrimaryButtonStyle { get; set; }
  public SheetButtonStyle SecondaryButtonStyle { get; set; }
  public Thickness Padding { get; set; }
}
```

```csharp
// InputPopupStyle.cs
public class InputPopupStyle : SheetViewStyle
{
  public SheetLabelStyle TitleLabelStyle { get; set; }
  public SheetLabelStyle BodyLabelStyle { get; set; }
  public SheetEntryStyle EntryStyle { get; set; }
  public SheetButtonStyle PrimaryButtonStyle { get; set; }
  public SheetButtonStyle SecondaryButtonStyle { get; set; }
  public Thickness Padding { get; set; }
```

```csharp
// SheetViewStyle.cs
public class SheetViewStyle
{
  public Color BackgroundEndColor { get; set; }
  public Color BackgroundStartColor { get; set; }
  public Color OverlayColor { get; set; }
  public float OverlayOpacity { get; set; }
}
```

```csharp
// SheetLabelStyle.cs
public class SheetLabelStyle
{
  public double FontSize { get; set; }
  public string FontFamily { get; set; }
  public FontAttributes FontAttributes { get; set; }
  public Color TextColor { get; set; }
  public TextAlignment Alignment { get; set; }
  public Thickness Margin { get; set; }
}
```

```csharp
// SheetButtonStyle.cs
public class SheetButtonStyle
{
  public Color BackgroundColor { get; set; }
  public Color BorderColor  { get; set; }
  public double BorderWidth  { get; set; }
  public int BorderRadius  { get; set; }
  public FontAttributes FontAttributes  { get; set; }  
  public double FontSize  { get; set; }
  public string FontFamily  { get; set; }
  public TextAlignment TextAlignment  { get; set; }
  public Color TextColor  { get; set; }
  public Thickness Margin  { get; set; }  
}
```

```csharp
// SheetEntryStyle.cs
public class SheetEntryStyle
{
  public Color BackgroundColor { get; set; }
  public FontAttributes FontAttributes { get; set; }
  public double FontSize { get; set; }
  public string FontFamily { get; set; }
  public Color TextColor { get; set; }
  public Thickness Margin { get; set; }
  public double HeightRequest	{ get; set; }
}
```
