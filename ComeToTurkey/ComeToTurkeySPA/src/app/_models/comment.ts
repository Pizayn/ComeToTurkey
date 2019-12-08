export interface Comment {
    id: number;
    senderId: number;
    senderFirstName: string;
    senderPhotoUrl: string;
    recipientId: number;
    content: string;  
    sendDate: Date;
}
