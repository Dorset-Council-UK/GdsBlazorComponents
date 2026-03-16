# Accordion

Render GOV.UK Design System styled accordion.

## Example image

![Accordion example](Accordion.png)

## How it works

- renders a `<div class="govuk-accordion"` element styled according to the GOV.UK Design System.
- the `Id` parameter is required, and is used to uniquely identify the accordion sections, headers, and content.

## How the accordion sections work

- each section is defined using the `GdsAccordionSection` component
- optional `Header` element to show the section heading / summary content
- optional `Content` element to show the section content
- the header ID and content ID are automatically generated

## Example

```csharp
<GdsAccordion Id="accordion-test">
    <GdsAccordionSection>
        <Header>Writing well for the web</Header>
        <Content>
            <p class="govuk-body">This is the content for Writing well for the web.</p>
        </Content>
    </GdsAccordionSection>
    <GdsAccordionSection>
        <Header>Writing well for specialists</Header>
        <Content>
            <p class="govuk-body">This is the content for Writing well for specialists.</p>
        </Content>
    </GdsAccordionSection>
</GdsAccordion>

```
