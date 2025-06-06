import { clients } from "@/lib/clients";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toast } from "sonner";

export const useCreateDocument = () => {
  const queryClient = useQueryClient();
  const mutation = useMutation({
    mutationFn: async (data: { title: string; initialContent?: string | null }) => {
      const response = await clients.post<{
        isSuccess: boolean;
        documentId: string;
      }>("/api/docs/documents", data );
      if (response.data.isSuccess) {
        return response.data;
      }
      throw new Error("has some error");
    },
    onSuccess: () => {
      toast.success("Document created success");
      queryClient.invalidateQueries({queryKey: ["documents"]})
    },
    onError: (error) => {
      toast.error(error.message);
    },
  });

  return mutation;
};
