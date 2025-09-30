# GdsOptionItem

`GdsOptionItem<T>` is a simple, strongly typed model that represents a single selectable choice for GDS styled form controls.

It provides a consistent set of properties (`Id`, `Label`, `Value`, optional `Hint`, `Selected`, and `IsExclusive`) so the same options can be reused across multipe controls and components while preserving accessibility and behavior.

## Designed for use with

- `GdsCheckbox` and `GdsCheckboxes` (with `GdsCheckbox` using Blazor's `InputCheckbox`)
- `GdsRadio` and `GdsRadioButtons` (with `GdsRadio` using Blazor's `InputRadio`)
- Blazor's `InputSelect`

## Notes

- `Selected` is not relevant for radio buttons
- `Hint` is optional
- `IsExclusive` shows a visual "or" divider for both check boxes and radio buttons
- GDS exclusive behavior only applies to check boxes using their documented `data-behaviour="exclusive"` attribute