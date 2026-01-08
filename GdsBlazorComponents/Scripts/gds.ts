import './gds.scss'
import { GdsObserver } from './gdsObserver'

// Setup GDS frontend requirements on document.body
function setupGdsFrontend(): void {
    document.body.classList.add('js-enabled')
    if ('noModule' in HTMLScriptElement.prototype) document.body.classList.add('govuk-frontend-supported')
}

let gdsObserver: GdsObserver | null = null

// Start observing the DOM for dynamically added GDS components
function startGdsObserver() {
    if (!gdsObserver) gdsObserver = new GdsObserver()
    gdsObserver.startObserving()
}

// Stop observing the DOM
function stopGdsObserver() {
    if (gdsObserver) gdsObserver.stopObserving()
}

// Setup GDS - called automatically when module loads
function setupGds() {
    setupGdsFrontend();
    startGdsObserver();
}

// Cleanup - called automatically on page unload
function cleanupGDS() {
    stopGdsObserver();
    document.body.classList.remove('js-enabled', 'govuk-frontend-supported')
}

// Automatically initialize when DOM is ready. Ensure it works whether the script is loaded before or after DOMContentLoaded.
if (document.readyState === 'loading') {
    // Loading hasn't finished yet
    document.addEventListener('DOMContentLoaded', setupGds)
} else {
    // `DOMContentLoaded` has already fired
    setupGds();
}

// Automatically cleanup on page unload
window.addEventListener('beforeunload', cleanupGDS)