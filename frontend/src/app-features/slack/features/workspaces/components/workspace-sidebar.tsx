import {
  Sidebar,
  SidebarContent,
  SidebarGroup,
  SidebarGroupContent,
  SidebarHeader,
  SidebarInput,
  SidebarMenu,
  SidebarMenuAction,
  SidebarMenuButton,
  SidebarMenuItem,
} from "@/components/ui/sidebar";
import { WorkspaceHeader } from "./workspace-header";
import { useWorkspaceId } from "../hooks/use-workspace-id";
import { useGetChannels } from "../../channels/api/use-get-channels";
import { useGetMembers } from "../../members/api/use-get-members";
import {
  Loader,
  MessageSquareMoreIcon,
  Plus,
  SendHorizonal,
} from "lucide-react";
import Link from "next/link";
import { Button } from "@/components/ui/button";
import { useCreateChannelDialog } from "../../channels/hooks/use-create-channel-dialog";
import { MemberAvatar } from "../../members/components/member-avatar";
import { usePathname } from "next/navigation";
import { cn } from "@/lib/utils";

export const WorkspaceSidebar = () => {
  const pathname = usePathname();
  const workspaceId = useWorkspaceId();
  const [, setOpenCreateChannelDialog] = useCreateChannelDialog();
  const { data: channels, isPending: isChannelsPending } = useGetChannels({
    workspaceId,
  });
  const { data: members, isPending: isMembersPending } = useGetMembers({
    workspaceId,
  });

  const isPending = isChannelsPending || isMembersPending;
  /* This is the second sidebar */
  /* We disable collapsible and let it fill remaining space */
  return (
    <Sidebar collapsible="none" className="hidden flex-1 md:flex">
      <SidebarHeader className="gap-3.5 border-b p-4">
        <WorkspaceHeader />
        <SidebarInput placeholder="Type to search..." />
      </SidebarHeader>
      <SidebarContent>
        <SidebarGroup className="px-0">
          <SidebarGroupContent>
            <SidebarMenu>
              <SidebarMenu>
                <SidebarMenuItem>
                  <SidebarMenuButton>
                    <MessageSquareMoreIcon /> Threads
                  </SidebarMenuButton>
                </SidebarMenuItem>
                <SidebarMenuItem>
                  <SidebarMenuButton>
                    <SendHorizonal /> Dasfts & Sent
                  </SidebarMenuButton>
                </SidebarMenuItem>
              </SidebarMenu>
              <SidebarMenuItem className="flex h-[40px] items-center">
                <SidebarMenuButton>Channels</SidebarMenuButton>
                <SidebarMenuAction asChild>
                  <Button
                    variant="ghost"
                    size="icon"
                    className="size-[30px] opacity-0 transition-opacity duration-700 group-hover:opacity-100"
                    onClick={() => setOpenCreateChannelDialog(true)}
                  >
                    <Plus className="text-muted-foreground" />
                  </Button>
                </SidebarMenuAction>
              </SidebarMenuItem>
            </SidebarMenu>
            {isPending ? (
              <>
                <div>
                  <Loader className="animate-spin" />
                </div>
              </>
            ) : (
              channels?.map((item) => {
                const href = `/slack/workspaces/${workspaceId}/channels/${item.id}`;
                const isActive = pathname.includes(href);
                return (
                  <Link
                    href={href}
                    key={item.id}
                    className={cn("hover:bg-sidebar-accent hover:text-sidebar-accent-foreground flex flex-col items-start gap-2 px-2 py-1.5 text-sm leading-tight whitespace-nowrap",
                      isActive && "bg-sidebar-accent font-semibold"
                    )}
                  >
                    <div className="flex w-full items-center gap-2">
                      <span>#{item.name}</span>
                    </div>
                  </Link>
                );
              })
            )}
            {members?.map((item) => {
              return (
                <Link
                  href="#"
                  key={item.id}
                  className="hover:bg-sidebar-accent hover:text-sidebar-accent-foreground flex items-center gap-2 px-2 py-1.5 text-sm leading-tight whitespace-nowrap"
                >
                  <MemberAvatar name={item.name} /> {item.name}
                </Link>
              );
            })}
          </SidebarGroupContent>
        </SidebarGroup>
      </SidebarContent>
    </Sidebar>
  );
};
