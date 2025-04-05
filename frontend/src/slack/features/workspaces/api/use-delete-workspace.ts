import { clients } from "@/lib/clients";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toast } from "sonner";

export const useDeleteWorkspace = () => {
  const queryClient = useQueryClient();
  const mutation = useMutation({
    mutationFn: async ({ workspaceId }: { workspaceId: string }) => {
      const response = await clients.delete<{ isSuccess: boolean }>(
        `/api/slack/workspaces/${workspaceId}`,
      );
      if (!response.data.isSuccess) {
        throw new Error("has some error");
      }
    },
    onSuccess: () => {
      queryClient.removeQueries({ queryKey: ["workspaces"] });
      toast.success("Delete workspace succes");
    },
    onError: (error) => {
      toast.error(error.message);
    },
  });
  return mutation;
};
