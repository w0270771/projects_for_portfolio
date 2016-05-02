include ActionController::HttpAuthentication::Token::ControllerMethods

class PlaylistsController < ApplicationController

  before_filter :restrict_access
  before_action :set_playlist, only: [ :show, :update, :destroy]

  # GET /playlists
  # GET /playlists.json
  def index
    current_user = ApiKey.find_by_access_token session[:token]
    @playlist = current_user.playlists
    render json: @playlist
  end

  # GET /playlists/1
  # GET /playlists/1.json
  def show
    current_user = ApiKey.find_by_access_token session[:token]
    @playlist = Playlist.find_by_api_keys_id(current_user.id)
    render json: @playlist, include: [:tracks]
  end

  # POST /playlists
  # POST /playlists.json
  def create
    @playlist = Playlist.new(playlist_params)
    current_user = ApiKey.find_by_access_token session[:token]
    @playlist.api_keys_id = current_user.id

    if @playlist.save
      render json: @playlist, status: :created, location: @playlist
    else
      render json: @playlist.errors, status: :unprocessable_entity
    end
  end

  # PATCH/PUT /playlists/1
  # PATCH/PUT /playlists/1.json
  def update
    current_user = ApiKey.find_by_access_token session[:token]
    # @playlist.api_keys_id = current_user.id
    @playlist = Playlist.find_by_api_keys_id(current_user.id)

    if @playlist.update(playlist_params)
      head :no_content
    else
      render json: @playlist.errors, status: :unprocessable_entity
    end
  end

  # DELETE /playlists/1
  # DELETE /playlists/1.json
  def destroy
    current_user = ApiKey.find_by_access_token session[:token]
    @playlist = Playlist.find_by_api_keys_id(current_user.id)
    @playlist.destroy
    head :no_content
  end

  private

    def set_playlist
      @playlist = Playlist.find(params[:id])
    end

    def playlist_params
      params.permit(:Name)
    end

  def restrict_access
    authenticate_or_request_with_http_token do |token, options|
      ApiKey.exists?(access_token: token)
      session[:token] = token
    end
  end
end
