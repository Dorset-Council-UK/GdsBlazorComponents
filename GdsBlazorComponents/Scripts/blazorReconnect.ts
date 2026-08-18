declare global {
    interface Window {
        Blazor: {
            reconnect(): Promise<boolean>;
            resumeCircuit(): Promise<boolean>;
        };
    }
}

interface ReconnectStateChangeDetail {
    state: "show" | "hide" | "failed" | "rejected" | "resume-failed";
}

type ReconnectStateChangeEvent = CustomEvent<ReconnectStateChangeDetail>;

export function initialiseReconnectHandlers(): void {
    const reconnectModal = document.getElementById("components-reconnect-modal") as HTMLDialogElement | null;
    const retryButton = document.getElementById("components-reconnect-button") as HTMLButtonElement | null;
    const resumeButton = document.getElementById("components-resume-button") as HTMLButtonElement | null;

    if (!reconnectModal) {
        if (document.readyState === "loading") {
            document.addEventListener("DOMContentLoaded", initialiseReconnectHandlers, { once: true });
            return;
        }

        console.warn("Reconnect modal not found.");
        return;
    }

    reconnectModal.addEventListener("components-reconnect-state-changed", (event) => handleReconnectStateChanged(event as ReconnectStateChangeEvent));

    reconnectModal.addEventListener("keydown", (event: KeyboardEvent) => {
        if (event.key === "Escape") {
            event.preventDefault();
        }
    });

    reconnectModal.addEventListener("cancel", (event: Event) => {
        event.preventDefault();
    });

    retryButton?.addEventListener("click", () => retry(reconnectModal));
    resumeButton?.addEventListener("click", () => resume(reconnectModal));
}

function handleReconnectStateChanged(event: ReconnectStateChangeEvent): void {
    const reconnectModal = document.getElementById("components-reconnect-modal") as HTMLDialogElement | null;

    if (!reconnectModal) {
        return;
    }

    switch (event.detail.state) {
        case "show":
            if (!reconnectModal.open) {
                reconnectModal.showModal();
            }
            break;

        case "hide":
            reconnectModal.close();
            break;

        case "failed":
            document.addEventListener(
                "visibilitychange",
                retryWhenDocumentBecomesVisible
            );
            break;

        case "rejected":
        case "resume-failed":
            location.reload();
            break;
    }
}

async function retry(reconnectModal: HTMLDialogElement): Promise<void> {
    document.removeEventListener("visibilitychange", retryWhenDocumentBecomesVisible);

    try {
        const successful = await window.Blazor.reconnect();

        if (successful) {
            reconnectModal.close();
            return;
        }

        const resumeSuccessful = await window.Blazor.resumeCircuit();

        if (!resumeSuccessful) {
            location.reload();
        } else {
            reconnectModal.close();
        }
    } catch {
        document.addEventListener(
            "visibilitychange",
            retryWhenDocumentBecomesVisible
        );
    }
}

async function resume(reconnectModal: HTMLDialogElement): Promise<void> {
    try {
        const successful = await window.Blazor.resumeCircuit();

        if (!successful) {
            location.reload();
        } else {
            reconnectModal.close();
        }
    } catch {
        location.reload();
    }
}

async function retryWhenDocumentBecomesVisible(): Promise<void> {
    if (document.visibilityState !== "visible") {
        return;
    }

    const reconnectModal = document.getElementById("components-reconnect-modal") as HTMLDialogElement | null;

    if (!reconnectModal) {
        return;
    }

    await retry(reconnectModal);
}