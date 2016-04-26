module app.movieComments {
    "use strict";

    export interface ICommentsService {
        getComments(movieId: number): ng.IPromise<CommentModel[]>;
        addComment(commentModel: CommentModel): ng.IPromise<boolean>;
    }

    export class CommentsService implements ICommentsService {

        static $inject = ["$http"];
        constructor(protected $http : ng.IHttpService) {

        }
        

        getComments = (movieId: number):ng.IPromise<CommentModel[]> => {
            return this.$http.get("/api/MovieComments/" + movieId)
                .then(x => {
                    return x.data;
                });
        }   

        addComment = (commentModel: CommentModel): ng.IPromise<boolean> => {
            commentModel.CreateTime = new Date();
            return this.$http.post("/api/MovieComments/",JSON.stringify(commentModel))
                .then(x=> {
                return true;
            });
        }
    }
} 