var app;
(function (app) {
    var movieComments;
    (function (movieComments) {
        "use strict";
        var CommentsService = (function () {
            function CommentsService($http) {
                var _this = this;
                this.$http = $http;
                this.getComments = function (movieId) {
                    return _this.$http.get("/api/MovieComments/" + movieId)
                        .then(function (x) {
                        return x.data;
                    });
                };
                this.addComment = function (commentModel) {
                    commentModel.CreateTime = new Date();
                    return _this.$http.post("/api/MovieComments/", JSON.stringify(commentModel))
                        .then(function (x) {
                        return true;
                    });
                };
            }
            CommentsService.$inject = ["$http"];
            return CommentsService;
        }());
        movieComments.CommentsService = CommentsService;
    })(movieComments = app.movieComments || (app.movieComments = {}));
})(app || (app = {}));
