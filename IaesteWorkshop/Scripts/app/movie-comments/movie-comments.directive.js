var app;
(function (app) {
    var movieComments;
    (function (movieComments) {
        "use strict";
        function MovieCommentDirective() {
            return {
                template: "<div class=\"col-md-2 comments-section-grid-image\">\n                    <img src=\"/images/eye-brow.jpg\" class=\"img-responsive\" alt=\"\" />\n                </div>\n                <div class=\"col-md-10 comments-section-grid-text\">\n                    <h4><a href=\"#\">{{comment.AuthorName}}</a></h4>\n                    <label>{{comment.CreateTime}}</label>\n                    <p>{{comment.Comment}}</p>\n                    <span><a href=\"#\">Reply</a></span>\n                    <i class=\"rply-arrow\"></i>\n                </div>",
                scope: {
                    comment: "=ngMovieComment"
                },
                link: function (scope) {
                },
            };
        }
        movieComments.MovieCommentDirective = MovieCommentDirective;
    })(movieComments = app.movieComments || (app.movieComments = {}));
})(app || (app = {}));
