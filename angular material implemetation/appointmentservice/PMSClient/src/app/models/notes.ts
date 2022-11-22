export class NotesModel {
    senderId!: number;
    senderName!: string;
    senderDesignation!: string;
    receiverId!: number;
    receiveName!: string;
    receiverDesignation!: string;
    message!: string;
    replyId!: number;
    isResponded: boolean = false;
    isUrgent!: boolean;
    deleteFlag: boolean = false;
}