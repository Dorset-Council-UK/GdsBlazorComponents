import { Checkboxes } from 'govuk-frontend';

class BlazorCheckboxes extends Checkboxes {
    constructor($root: Element | null) {
        super($root);
    }

    /**
     * The same features of unCheckAllInputsExcept except generate a change event for Blazor.
     * https://github.com/alphagov/govuk-frontend/blob/main/packages/govuk-frontend/src/govuk/components/checkboxes/checkboxes.mjs#L123
     */
    unCheckAllInputsExcept($input: HTMLInputElement) {
        // Get the currently selected checkboxes
        const previouslyChecked = document.querySelectorAll(`input[type="checkbox"][name="${$input.name}"]:checked`)

        // Call the original method
        //@ts-ignore
        super.unCheckAllInputsExcept($input)

        // Trigger a change event for each selected checkbox
        previouslyChecked.forEach(checkbox => checkbox.dispatchEvent(new Event('change', { bubbles: true })));
    }

    unCheckExclusiveInputs($input: HTMLInputElement) {
        // Get the currently selected checkboxes
        const previouslyChecked = document.querySelectorAll(`input[type="checkbox"][name="${$input.name}"]:checked`)

        // Call the original method
        //@ts-ignore
        super.unCheckExclusiveInputs($input)

        // Trigger a change event for each selected checkbox
        previouslyChecked.forEach(checkbox => checkbox.dispatchEvent(new Event('change', { bubbles: true })))
    }
}

export { BlazorCheckboxes };