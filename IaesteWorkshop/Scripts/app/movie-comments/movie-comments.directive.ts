module app.movieComments {
    "use strict";

    export interface IMovieCommentsDirectiveScope extends ng.IScope {
        comment: CommentModel;
    }

    export function MovieCommentDirective(): ng.IDirective {
        return {
            template: `<div class="col-md-2 comments-section-grid-image">
                    <img src="/images/eye-brow.jpg" class="img-responsive" alt="" />
                </div>
                <div class="col-md-10 comments-section-grid-text">
                    <h4><a href="#">{{comment.AuthorName}}</a></h4>
                    <label>{{comment.CreateTime}}</label>
                    <p>{{comment.Comment}}</p>
                    <span><a href="#">Reply</a></span>
                    <i class="rply-arrow"></i>
                </div>`,
            scope: {
                comment: "=ngMovieComment"
            },
            link: (scope: app.movieComments.IMovieCommentsDirectiveScope) => {

            },
        };
    }
} 