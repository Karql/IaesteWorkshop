
module app.movieComments {
    "use strict";

    angular.module("app.movieComments", [])
        .service("app.movieComments.CommentsService", CommentsService)
        .controller("app.movieComments.CommentsController", CommentsCtrl)
        .directive("ngMovieComment", MovieCommentDirective);
} 