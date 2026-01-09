import { createAll, Accordion, Button, CharacterCount, ErrorSummary, ExitThisPage, FileUpload, Header, NotificationBanner, PasswordInput, Radios, ServiceNavigation, SkipLink, Tabs } from 'govuk-frontend'
import { BlazorCheckboxes } from './blazorCheckboxes'

function onCreateError(error: any) {
    if (error.name !== 'InitError') {
        console.error('Error creating GDS component: %s', error.message)
    }
}

/**
 * Observer class to watch for DOM changes and initialise GDS components
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
    }

    /**
     * Stop observing the DOM
     */
    public stopObserving(): void {
        if (this.observer) {
            this.observer.disconnect()
            this.observer = null
            this.isObserving = false
        }
    }

    /**
     * Handle DOM mutations and initialise GDS components
     */
    private handleMutations(mutations: MutationRecord[]): void {
        const moduleNames = new Set<string>()

        mutations.forEach((mutation) => {
            mutation.addedNodes.forEach((node) => {
                if (node.nodeType === Node.ELEMENT_NODE) {
                    const element = node as Element
                    this.findModuleNames(element, moduleNames)
                }
            })
        })

        if (moduleNames.size > 0) {
            this.initialiseModules(moduleNames)
        }
    }

    /**
     * Find all GDS module names in the given element
     */
    private findModuleNames(element: Element, moduleNames: Set<string>): void {
        // Check if the element itself is a GDS component
        if (element.hasAttribute('data-module')) {
            const moduleName = element.getAttribute('data-module')
            if (moduleName) {
                moduleNames.add(moduleName)
            }
        }

        // Find all child elements with data-module attribute
        const gdsComponents = element.querySelectorAll('[data-module]')
        gdsComponents.forEach(component => {
            const moduleName = component.getAttribute('data-module')
            if (moduleName) {
                moduleNames.add(moduleName)
            }
        })
    }

    /**
     * Initialise GDS modules by calling createAll for each unique module type
     * See GitHub - govuk-frontend https://github.com/alphagov/govuk-frontend/blob/main/packages/govuk-frontend/src/govuk/init.mjs for complete list of component modules.
     */
    private initialiseModules(moduleNames: Set<string>): void {
        moduleNames.forEach((moduleName) => {
            switch (moduleName) {
                case 'govuk-accordion':
                    createAll(Accordion, undefined, onCreateError)
                    break
                case 'govuk-button':
                    createAll(Button, undefined, onCreateError)
                    break
                case 'govuk-character-count':
                    createAll(CharacterCount, undefined, onCreateError)
                    break
                case 'govuk-checkboxes':
                    createAll(BlazorCheckboxes, undefined, onCreateError)
                    break
                case 'govuk-error-summary':
                    createAll(ErrorSummary, undefined, onCreateError)
                    break
                case 'govuk-exit-this-page':
                    createAll(ExitThisPage, undefined, onCreateError)
                    break
                case 'govuk-file-upload':
                    createAll(FileUpload, undefined, onCreateError)
                    break
                case 'govuk-header':
                    createAll(Header, undefined, onCreateError)
                    break
                case 'govuk-notification-banner':
                    createAll(NotificationBanner, undefined, onCreateError)
                    break
                case 'govuk-password-input':
                    createAll(PasswordInput, undefined, onCreateError)
                    break
                case 'govuk-radios':
                    createAll(Radios, undefined, onCreateError)
                    break
                case 'govuk-service-navigation':
                    createAll(ServiceNavigation, undefined, onCreateError)
                    break
                case 'govuk-skip-link':
                    createAll(SkipLink, undefined, onCreateError)
                    break
                case 'govuk-tabs':
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