# Task list

Render GOV.UK Design System styled task list component

## How it works
- renders a list of tasks styled according to the GOV.UK Design System
- use `GdsTaskListItem` component to render each task
- use `Text` parameter to specify the task text
- use `Href` parameter to specify the link for the task
- the `Status` child component should be used to render the status of the task
- a `GdsTag` component is recommended to be used inside the `Status`
- using a `Hint` child component is optional to provide additional information about the task

## Example

```csharp
<GdsTaskList>
    <GdsTaskListItem Text="Company Directors" Href="task/directors">
        <Status>Completed</Status>
    </GdsTaskListItem>

    <GdsTaskListItem Text="Registered company details" Href="task/company">
        <Status>
            <GdsTag Text="Incomplete" Colour="GdsTagColour.Blue" />
        </Status>
    </GdsTaskListItem>

    <GdsTaskListItem Text="Financial history" Href="task/financial">
        <Hint>
            Include 5 years of the company’s relevant financial information
        </Hint>
        <Status>
            <GdsTag Text="Incomplete" Colour="GdsTagColour.Blue" />
        </Status>
    </GdsTaskListItem>
</GdsTaskList>
```