import { AppSidebar } from "@/app-features/slack/components/app-sidebar";
import { SidebarInset, SidebarProvider } from "@/components/ui/sidebar";
import { ModalsWorkspaceId } from "@/app-features/slack/components/modals-workspace-id";
import { WorkspaceHeaderMain } from "@/app-features/slack/features/workspaces/components/workspace-header-main";
import { ResizablePanel, ResizablePanelGroup } from "@/components/ui/resizable";
import { ThreadPanel } from "@/app-features/slack/features/messages/components/thread-panel";

export default function WorkspaceIdLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <>
      <SidebarProvider
        style={
          {
            "--sidebar-width": "350px",
          } as React.CSSProperties
        }
      >
        <AppSidebar />

        <SidebarInset>
          <ResizablePanelGroup
            direction="horizontal"
            className="flex-1 rounded-lg border"
          >
            <ResizablePanel defaultSize={65}>
              <div className="flex h-full flex-col">
                <WorkspaceHeaderMain />
                {children}
              </div>
            </ResizablePanel>
            <ThreadPanel />
          </ResizablePanelGroup>
        </SidebarInset>
      </SidebarProvider>
      <ModalsWorkspaceId />
    </>
  );
}
