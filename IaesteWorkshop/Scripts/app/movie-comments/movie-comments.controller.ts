module app.movieComments {
    "use strict";

    export class CommentsCtrl {
        movieId: number = null;
        comments: CommentModel[] = null;
        addCommentModel= <CommentModel>{};

        static $inject = ["$scope","app.movieComments.CommentsService"];
        constructor(protected $scope: ng.IScope, protected commentsService: ICommentsService) {
        }

        init = (movieId: number) => {
            this.movieId = movieId;
            this.setupAddCommentModel();
            this.loadComments();
        }

        loadComments = () => {
            this.commentsService.getComments(this.movieId).then(x => {
                this.comments = x;
            }); 
        }

        setupAddCommentModel = () => {
            this.addCommentModel = <CommentModel>{
                MovieId : this.movieId
            };
            var form = <ng.IFormController>this.$scope["form"];
            if (!!form) {//reset form validation
                form.$setUntouched();
                form.$setPristine();
            }
        }

        addComment = (form: ng.IFormController) => {
            if (form.$invalid)
                return;
            this.commentsService.addComment(this.addCommentModel).then(x => {
                this.loadComments();
                this.setupAddCommentModel();
            });
        }
    }
} 