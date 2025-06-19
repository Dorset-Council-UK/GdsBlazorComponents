import './gds.scss'

import { createAll, Accordion, Button, CharacterCount, ErrorSummary, Header, PasswordInput, Radios, SkipLink } from 'govuk-frontend'
import { BlazorCheckboxes } from './blazorCheckboxes'

function onCreateError(error: any) {
    if (error.name !== 'InitError') {
        console.error('Error creating GDS component: %s', error.message)
    }
}

/**
 * See GitHub - govuk-frontend https://github.com/alphagov/govuk-frontend/blob/main/packages/govuk-frontend/src/govuk/init.mjs for complete list of component modules.
 */
export function initGDS() {
    document.body.classList.add('js-enabled')
    if ('noModule' in HTMLScriptElement.prototype) document.body.classList.add('govuk-frontend-supported')

    createAll(Accordion, undefined, onCreateError)
    createAll(Button, undefined, onCreateError)
    createAll(CharacterCount, undefined, onCreateError)
    //createAll(Checkboxes, undefined, onCreateError)
    createAll(BlazorCheckboxes, undefined, onCreateError)
    createAll(ErrorSummary, undefined, onCreateError)
    //createAll(ExitThisPage, undefined, notifyErrorMonitoringService)
    //createAll(FileUpload, undefined, notifyErrorMonitoringService)
    createAll(Header, undefined, onCreateError)
    //createAll(NotificationBanner, undefined, notifyErrorMonitoringService)
    createAll(PasswordInput, undefined, onCreateError)
    createAll(Radios, undefined, onCreateError)
    //createAll(ServiceNavigation, undefined, notifyErrorMonitoringService)
    createAll(SkipLink, undefined, onCreateError)
    //createAll(Tabs, undefined, notifyErrorMonitoringService)
}