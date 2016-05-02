/**
 * Created by inet2005 on 3/22/16.
 */
(function(){

    // my IIFE code will go here

    var app = angular.module('myApp',['ngResource']);

    app.config(function($httpProvider){
        $httpProvider.defaults.headers.common['Authorization'] = 'Token token="93e7795f871c0fbc40b02a2092e594fe"';
        //$httpProvider.defaults.headers.common['Authorization'] = 'Token token="6086c392d730fd0406204f5855161ae0"';
    });

    app.factory("Playlist", function($resource) {
        //return $resource("http://localhost:3000/actors/:actor_id");
        //return $resource("http://localhost:3000/actors/:actor_id");
        return $resource("http://0.0.0.0:3000/playlists/:playlist_id", null,{
            'update': { method: 'PUT' }
        });
    });

    app.controller('playlistsController',function($scope,Playlist){

        // initialize display report to false so it does not show
        $scope.displayReport = false;

        // Loads all Playlists
        $scope.refreshReport = function(){
            Playlist.query(function(data) {
                $scope.playlists = data;
            });
        };

        $scope.refreshReport();

        // Get one Playlist
        $scope.retrievePlaylist = function(playlistID){
            Playlist.get({ playlist_id: playlistID }, function(data) {
             if(playlistID == data.PlaylistId) {
                 $scope.selectedPlaylist = data;
                 $scope.displayReport = true;
             }
            });
        };

        // add a new Playlist
        $scope.addPlaylist = function(){
            var data = {Name: $scope.newName};
            $scope.message = Playlist.save(data);
        };


        // update an actor
        $scope.updatePlaylist = function(playlistId){
            var playlist = Playlist.get({playlist_id: playlistId},function(data) {
                        var playlistName = document.getElementById("currentName" + playlistId).innerHTML;
                        data = {Name: playlistName};
                        $scope.message = Playlist.update({playlist_id: playlistId}, data);
            });
        };


        // delete an Playlist
        $scope.deletePlaylist = function(playlistID){
            $scope.message = Playlist.delete({ playlist_id: playlistID });
            $scope.refreshReport();
        };




    });

})();
