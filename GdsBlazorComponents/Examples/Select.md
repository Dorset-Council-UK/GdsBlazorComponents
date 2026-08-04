# Select List

Render GOV.UK Design System styled select lists. Option definition is controlled by the calling application.

> [!CAUTION]
> The select component should only be used as a last resort in public-facing services because research shows that some users find selects very difficult to use.

## Example image

![Select list example](Select.png)

## How it works

- Renders a ```<select class="govuk-select">```.
- Bind this component to a property using `@bind-Value` to track and set the selected value.
- This wraps Blazor's built-in `InputSelect` component.
- The `Id` attribute is optional, letting you choose your own form control id.
- If `Id` is not set, and used within `GdsFormGroup`, a default id is generated.

## Simple examples

```razor
<GdsFormGroup>
    <GdsLabel Text="Contact type" />
    <GdsHint>The primary way to contact you</GdsHint>
    <GdsErrorMessage />
    <GdsSelect @bind-Value="model.SelectedContactType" T="int?">
        <option value="">Please select</option>
        @foreach(var contactType in ContactTypes)
        {
            bool selected = contactType.Key == model.SelectedContactType;
            <option value="@contactType.Key" selected="@selected">@contactType.Value</option>
        }
    </GdsSelect>
    <p>Selected Value: @model.SelectedContactType</p>
</GdsFormGroup>

<GdsFormGroup>
    <GdsLabel Text="Contact type" />
    <GdsHint>The primary way to contact you</GdsHint>
    <GdsErrorMessage />
    <GdsSelect @bind-Value="model.SelectedContactTypeEnum" T="ContactTypeEnum?">
        <option value="">Please select</option>
        @foreach (var contactType in Enum.GetValues<ContactTypeEnum>())
        {
            bool selected = contactType == model.SelectedContactTypeEnum;
            <option value="@contactType" selected="@selected">@contactType</option>
        }
    </GdsSelect>
    <p>Selected Value: @model.SelectedContactTypeEnum</p>
</GdsFormGroup>

@code {
    private Dictionary<int, string> ContactTypes = new Dictionary<int, string>
    {
        { 0, "None" },
        { 1, "Phone" },
        { 2, "Email" },
        { 3, "Text" },
        { 4, "Post" }
    };

    public enum ContactTypeEnum    
    {
        None,
        Phone,
        Email,
        Text,
        Post
    };

    public class SelectModel
    {
        [Required(ErrorMessage = "Select the contact type")]
        [GdsFieldErrorClass(GdsFieldTypes.Select)]
        public int? SelectedContactType { get; set; }

        [Required(ErrorMessage = "Select the contact type")]
        [GdsFieldErrorClass(GdsFieldTypes.Select)]
        public ContactTypeEnum? SelectedContactTypeEnum { get; set; }
    }
}
```