# Footer

Render a GOV.UK Design System styled footer.

Allowing you to use your own content in the footer, via the GDS `Navigation` and `Meta` sections.

## Example image

![Footer example](Footer.png)

## How it works

- Renders a ```<footer class="govuk-footer">``` element.
- Supports flexible `Navigation` and `Meta` optional sections.
- For navigation columns use the `<GdsFooterSection>` component.
- The meta section supports multiple types of meta items with `govuk-footer__meta-item` examples include:
  - open government licence
  - support links with `govuk-footer__list`
  - images and copyright message.
- The utility class `.govuk-footer__meta-item--grow` can be used to make a meta item expand to fill available space.

Full examples from the GOV.UK Design System can be at [Footer with links and secondary navigation](https://design-system.service.gov.uk/components/footer/#footer-with-links-and-secondary-navigation).

## Example - Simple image and copyright

```csharp
<GdsFooter>
    <Meta>
        <div class="govuk-footer__meta-item govuk-footer__meta-item--grow">
            <a class="govuk-footer__link govuk-link-image" href="https://www.google.co.uk" title="Go to your site">
                <img src="your-image-x2.webp" alt="Your logo" width="188" height="80">
            </a>
        </div>
        <div class="govuk-footer__meta-item">
            <div>Copyright &copy; @(DateTimeOffset.UtcNow.Year) Your company</div>
        </div>
    </Meta>
</GdsFooter>
```

## Example - Navigation columns

```csharp
<GdsFooter>
    <Navigation>
        <GdsFooterSection Width="GdsGridColumnWidth.TwoThirds">
            <h2 class="govuk-footer__heading govuk-heading-m">Two column list</h2>
                <ul class="govuk-footer__list govuk-footer__list--columns-2">
                    <li class="govuk-footer__list-item">
                        <a class="govuk-footer__link" href="#">Navigation item 1</a>
                    </li>
                    <li class="govuk-footer__list-item">
                        <a class="govuk-footer__link" href="#">Navigation item 2</a>
                    </li>
                    <li class="govuk-footer__list-item">
                        <a class="govuk-footer__link" href="#">Navigation item 3</a>
                    </li>
                    <li class="govuk-footer__list-item">
                        <a class="govuk-footer__link" href="#">Navigation item 4</a>
                    </li>
                    <li class="govuk-footer__list-item">
                        <a class="govuk-footer__link" href="#">Navigation item 5</a>
                    </li>
                    <li class="govuk-footer__list-item">
                        <a class="govuk-footer__link" href="#">Navigation item 6</a>
                    </li>
                </ul>
            </GdsFooterSection>
            <GdsFooterSection Width="GdsGridColumnWidth.OneThird">
                <h2 class="govuk-footer__heading govuk-heading-m">Single column list</h2>
                <ul class="govuk-footer__list">
                    <li class="govuk-footer__list-item">
                        <a class="govuk-footer__link" href="#">Navigation item 1</a>
                    </li>
                    <li class="govuk-footer__list-item">
                        <a class="govuk-footer__link" href="#">Navigation item 2</a>
                    </li>
                    <li class="govuk-footer__list-item">
                        <a class="govuk-footer__link" href="#">Navigation item 3</a>
                    </li>
                </ul>
            </GdsFooterSection>
        </Navigation>
</GdsFooter>
```