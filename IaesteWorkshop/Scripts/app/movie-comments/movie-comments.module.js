var app;
(function (app) {
    var movieComments;
    (function (movieComments) {
        "use strict";
        angular.module("app.movieComments", [])
            .service("app.movieComments.CommentsService", movieComments.CommentsService)
            .controller("app.movieComments.CommentsController", movieComments.CommentsCtrl);
    })(movieComments = app.movieComments || (app.movieComments = {}));
})(app || (app = {}));
