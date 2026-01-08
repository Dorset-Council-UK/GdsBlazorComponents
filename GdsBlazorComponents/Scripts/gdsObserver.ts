import { createAll, Accordion, Button, CharacterCount, ErrorSummary, ExitThisPage, FileUpload, Header, NotificationBanner, PasswordInput, Radios, ServiceNavigation, SkipLink, Tabs } from 'govuk-frontend'
import { BlazorCheckboxes } from './blazorCheckboxes'

function onCreateError(error: any) {
    if (error.name !== 'InitError') {
        console.error('Error creating GDS component: %s', error.message)
    }
}

/**
 * Observer class to watch for DOM changes and initialize GDS components
 */
export class GdsObserver {
    private observer: MutationObserver | null = null
    private isObserving = false

    /**
     * Start observing the DOM for changes
     * @param target - The element to observe (defaults to document.body)
     */
    public startObserving(target: HTMLElement = document.body): void {
        if (this.isObserving) {
            console.warn('GDS Observer is already running')
            return
        }

        this.observer = new MutationObserver((mutations) => {
            this.handleMutations(mutations)
        })

        this.observer.observe(target, {
            childList: true,
            subtree: true
        })

        this.isObserving = true
        console.debug('GDS Observer started')
    }

    /**
     * Stop observing the DOM
     */
    public stopObserving(): void {
        if (this.observer) {
            this.observer.disconnect()
            this.observer = null
            this.isObserving = false
            console.debug('GDS Observer stopped')
        }
    }

    /**
     * Handle DOM mutations and initialize GDS components
     */
    private handleMutations(mutations: MutationRecord[]): void {
        const componentsToInit = new Set<Element>()

        mutations.forEach((mutation) => {
            mutation.addedNodes.forEach((node) => {
                if (node.nodeType === Node.ELEMENT_NODE) {
                    const element = node as Element
                    this.findGdsComponents(element, componentsToInit)
                }
            })
        })

        if (componentsToInit.size > 0) {
            this.initializeComponents(componentsToInit)
        }
    }

    /**
     * Find all GDS components in the given element
     */
    private findGdsComponents(element: Element, componentsToInit: Set<Element>): void {
        // Check if the element itself is a GDS component
        if (element.hasAttribute('data-module')) {
            componentsToInit.add(element)
        }

        // Find all child elements with data-module attribute
        const gdsComponents = element.querySelectorAll('[data-module]')
        gdsComponents.forEach(component => componentsToInit.add(component))
    }

    /**
     * Initialize GDS components
     * See GitHub - govuk-frontend https://github.com/alphagov/govuk-frontend/blob/main/packages/govuk-frontend/src/govuk/init.mjs for complete list of component modules.
     */
    private initializeComponents(components: Set<Element>): void {
        components.forEach((component) => {
            const moduleName = component.getAttribute('data-module')

            switch (moduleName) {
                case 'govuk-accordion':
                    console.debug('Creating GDS Accordion components')
                    createAll(Accordion, undefined, onCreateError)
                    break
                case 'govuk-button':
                    console.debug('Creating GDS Button components')
                    createAll(Button, undefined, onCreateError)
                    break
                case 'govuk-character-count':
                    console.debug('Creating GDS Character Count components')
                    createAll(CharacterCount, undefined, onCreateError)
                    break
                case 'govuk-checkboxes':
                    console.debug('Creating GDS Blazor Checkbox components')
                    createAll(BlazorCheckboxes, undefined, onCreateError)
                    break
                case 'govuk-error-summary':
                    console.debug('Creating GDS Error Summary components')
                    createAll(ErrorSummary, undefined, onCreateError)
                    break
                case 'govuk-exit-this-page':
                    console.debug('Creating GDS Exit This Page components')
                    createAll(ExitThisPage, undefined, onCreateError)
                    break
                case 'govuk-file-upload':
                    console.debug('Creating GDS File Upload components')
                    createAll(FileUpload, undefined, onCreateError)
                    break
                case 'govuk-header':
                    console.debug('Creating GDS Header components')
                    createAll(Header, undefined, onCreateError)
                    break
                case 'govuk-notification-banner':
                    console.debug('Creating GDS Notification Banner components')
                    createAll(NotificationBanner, undefined, onCreateError)
                    break
                case 'govuk-password-input':
                    console.debug('Creating GDS Password Input components')
                    createAll(PasswordInput, undefined, onCreateError)
                    break
                case 'govuk-radios':
                    console.debug('Creating GDS Radios components')
                    createAll(Radios, undefined, onCreateError)
                    break
                case 'govuk-service-navigation':
                    console.debug('Creating GDS Service Navigation components')
                    createAll(ServiceNavigation, undefined, onCreateError)
                    break
                case 'govuk-skip-link':
                    console.debug('Creating GDS Skip Link components')
                    createAll(SkipLink, undefined, onCreateError)
                    break
                case 'govuk-tabs':
                    console.debug('Creating GDS Tabs components')
                    createAll(Tabs, undefined, onCreateError)
                    break
                default:
                    console.warn(`Unknown GDS module: ${moduleName}`)
            }
        })
    }

    /**
     * Get the current observation status
     */
    public isActive(): boolean {
        return this.isObserving
    }
}