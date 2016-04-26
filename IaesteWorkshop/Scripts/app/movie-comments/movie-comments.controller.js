var app;
(function (app) {
    var movieComments;
    (function (movieComments) {
        "use strict";
        var CommentsCtrl = (function () {
            function CommentsCtrl($scope, commentsService) {
                var _this = this;
                this.$scope = $scope;
                this.commentsService = commentsService;
                this.movieId = null;
                this.comments = null;
                this.addCommentModel = {};
                this.init = function (movieId) {
                    _this.movieId = movieId;
                    _this.setupAddCommentModel();
                    _this.loadComments();
                };
                this.loadComments = function () {
                    _this.commentsService.getComments(_this.movieId).then(function (x) {
                        _this.comments = x;
                    });
                };
                this.setupAddCommentModel = function () {
                    _this.addCommentModel = {
                        MovieId: _this.movieId
                    };
                    var form = _this.$scope["form"];
                    if (!!form) {
                        form.$setUntouched();
                        form.$setPristine();
                    }
                };
                this.addComment = function (form) {
                    if (form.$invalid)
                        return;
                    _this.commentsService.addComment(_this.addCommentModel).then(function (x) {
                        _this.loadComments();
                        _this.setupAddCommentModel();
                    });
                };
            }
            CommentsCtrl.$inject = ["$scope", "app.movieComments.CommentsService"];
            return CommentsCtrl;
        }());
        movieComments.CommentsCtrl = CommentsCtrl;
    })(movieComments = app.movieComments || (app.movieComments = {}));
})(app || (app = {}));
