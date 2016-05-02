class Playlist < ActiveRecord::Base
    self.table_name = 'Playlist'
    self.primary_key = 'PlaylistId'

    belongs_to :api_key, class_name: "ApiKey", :primary_key => 'id'
    has_many :playlist_tracks, :class_name => 'PlaylistTrack', :foreign_key => :PlaylistId
    has_many :tracks, through: :playlist_tracks, dependent: :destroy
end
