import { useParentMessageId } from "../features/messages/hooks/use-parent-message-id";

export const usePanel = () => {
  const [parentMessageId, setParentMessageId] = useParentMessageId();

  const onOpenMessage = (messageId: string) => {
    setParentMessageId(messageId);
  }
  const onClose = () => {
    setParentMessageId(null);
  }

  return {
    parentMessageId,
    onOpenMessage,
    onClose,
    setParentMessageId,
  }
}