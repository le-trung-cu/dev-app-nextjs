import { useMutation, useQueryClient } from "@tanstack/react-query";
import { z } from "zod";
import { clients } from "@/lib/clients";
import { toast } from "sonner";
import { createChannelSchema } from "../types";

export const useCreateChannel = () => {
  const queryClient = useQueryClient();
  const mutation = useMutation({
    mutationFn: async ({
      workspaceId,
      data,
    }: {
      workspaceId: string;
      data: z.infer<typeof createChannelSchema>;
    }) => {
      const response = await clients.post<{
        isSuccess: boolean;
        channelId: string;
      }>(`/api/slack/workspaces/${workspaceId}/channels`, data);
      if (response.data.isSuccess) {
        return response.data;
      }
      throw new Error("has some error");
    },
    onSuccess: (data, { workspaceId }) => {
      toast.success("Create channel success");
      queryClient.invalidateQueries({ queryKey: ["channels", workspaceId] });
    },
    onError: (error) => {
      toast.error(error.message);
    },
  });

  return mutation;
};
