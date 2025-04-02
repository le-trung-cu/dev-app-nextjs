"use client";
import { Button } from "@/components/ui/button";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { Plus } from "lucide-react";
import { useCreateTaskDialog } from "../hooks/use-create-task-dialog";
import { DataFilter } from "./data-filter";
import { useGetProjects } from "../../projects/api/use-get-projects";
import { useWorkspaceId } from "../../workspaces/hooks/use-workspace-id";
import { useGetTasks } from "../api/use-get-tasks";
import { useGetMembers } from "../../members/api/use-get-members";
import { DataTable } from "./data-table";
import { useMemo } from "react";
import { Project } from "../../projects/types";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Separator } from "@/components/ui/separator";
import { useTaskFilters } from "../hooks/use-task-filters";
import { parseAsString, useQueryState } from "nuqs";

export const TasksViewSwicher = () => {
  const { open } = useCreateTaskDialog();
  const workspaceId = useWorkspaceId();
  const { filter } = useTaskFilters();
  const [tasksView, setTasksView] = useQueryState(
    "tasks-view",
    parseAsString.withDefault("table").withOptions({ shallow: true }),
  );

  const { data: projects, isPending: isPendingProjects } = useGetProjects({
    workspaceId,
  });
  const { data: members, isPending: isPendingMembers } = useGetMembers({
    workspaceId,
  });
  const { data: tasksData, isPending: isPendingTasks } = useGetTasks({
    ...filter,
    workspaceId,
  });

  const mapProjects = useMemo(() => {
    return projects?.reduce(
      (value, item) => {
        value[item.id] = item;
        return value;
      },
      {} as Record<Project["id"], Project>,
    );
  }, [projects]);

  return (
    <Card>
      <CardHeader>
        <CardTitle></CardTitle>
        <CardDescription></CardDescription>
      </CardHeader>
      <CardContent>
        <Tabs value={tasksView} onValueChange={(value) => setTasksView(value)}>
          <div className="flex flex-wrap items-center gap-2">
            <TabsList className="w-full md:w-fit">
              <TabsTrigger value="table">table</TabsTrigger>
              <TabsTrigger value="kanban">kanban</TabsTrigger>
              <TabsTrigger value="calendar">calendar</TabsTrigger>
            </TabsList>
            <Button className="h-8 w-full p-0 md:w-fit" onClick={open}>
              New <Plus />
            </Button>
          </div>

          <Separator className="my-2.5" />
          <div>
            <DataFilter
              projectOptions={projects ?? []}
              assigneeIdOptions={members ?? []}
            />
          </div>
          <Separator className="" />

          <TabsContent value="table">
            <DataTable
              tasks={tasksData?.tasks ?? []}
              members={tasksData?.members ?? {}}
              projects={mapProjects ?? {}}
            />
          </TabsContent>
          <TabsContent value="kanban"></TabsContent>
          <TabsContent value="calendar"></TabsContent>
        </Tabs>
      </CardContent>
    </Card>
  );
};
