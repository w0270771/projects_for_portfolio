class TracksController < ApplicationController
  before_action :set_track, only: [:show, :update, :destroy]

  # GET /tracks
  # GET /tracks.json
  def index
    @playlist = Playlist.find(params[:playlist_id])
    @tracks = @playlist.tracks.limit(50).all
    render json: @tracks
  end

  # GET /playlists/playlist_id/tracks/1
  # GET /playlists/playlist_id/tracks/1.json
  def show
    @playlist = Playlist.find(params[:playlist_id])
    @track = @playlist.tracks.find(params[:id])
    render json: @track
  end

  # POST /playlists/playlist_id/tracks/add/id
  # POST /playlists/playlist_id/tracks/add/id.json
  def add
    @playlist = Playlist.find(params[:playlist_id])
    @track = Track.find(params[:id])
    @playlist.tracks << @track
    render json: @track, status: :added
  end


  # DELETE /playlists/playlist_id/tracks/delete/id
  # DELETE /playlists/playlist_id/tracks/delete/id.json
  def delete
    @playlist = Playlist.find(params[:playlist_id])
    @track = Track.find(params[:id])
    @playlist.tracks.delete(@track)
    render json: @track, :status => :'Tracks Deleted'
  end



end
