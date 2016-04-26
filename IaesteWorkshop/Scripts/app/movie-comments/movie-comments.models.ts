module app.movieComments {
    "use strict";

    export interface CommentModel {
        Id: number;
        MovieId: number;
        ReplyToCommentId: number;
        AuthorName: string;
        AuthorEmail: string;
        Comment: string;
        CreateTime: Date;
    }
} 