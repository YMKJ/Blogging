var app = angular.module('Blogging', [
    'ngResource',
    'ngRoute'
]);

app.factory('Post', function ($resource) {
    return $resource('/api/v1/post/:id',
        { id: '@id' },
        { 'update': { method: 'PUT' } },
        { 'query': { method: 'GET', isArray: false } });
});

app.controller('BloggingCtrl', function ($scope, $routeParams, $resource, Post) {
    //GET
    $scope.posts = Post.query();

    //POST
    $scope.postPost = function () {
        $scope.post.UserId = document.getElementById("newPostId").value;
        $scope.post.PostId = $scope.posts.length + 1;
        Post.save($scope.post, function () {
            $scope.posts.push($scope.post);
            $scope.post = {
                Title: '',
                Body: '',
                UserId: ''
            };
        });
    };

    //PUT
    $scope.showEdit = function (id) {
        //$scope.post = Post.get({ id: id });
        $scope.editId = id;
        $scope.editTitle = $scope.posts[id - 1].Title;
        $scope.editBody = $scope.posts[id - 1].Body;
        $scope.editUserId = document.getElementById("newPostId1").value;
    };

    $scope.updatePost = function (id, title, body, userId) {
        $scope.posts[id - 1].Title = title;
        $scope.posts[id - 1].Body = body;
        $scope.posts[id - 1].UserId = userId;
        Post.update({ id: id, Title: title, Body: body, UserId: userId });
        $('#modal-container-' + id).modal('hide');

    };

    //DELETE
    $scope.deletePost = function (id) {
        confirm("Are you sure you want to delete this post?");
        Post.delete({ id: id });
        $scope.posts = Post.query();
    };

});