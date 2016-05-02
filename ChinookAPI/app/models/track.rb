class Track < ActiveRecord::Base
    self.table_name = 'Track'
    self.primary_key = :TrackId

    has_many :invoicelines, :class_name => 'InvoiceLine', :foreign_key => :TrackId
    has_many :playlist_tracks, :class_name => 'PlaylistTrack', :foreign_key => :TrackId
    belongs_to :album, :class_name => 'Album', :foreign_key => :AlbumId
    belongs_to :genre, :class_name => 'Genre', :foreign_key => :GenreId
    belongs_to :mediatype, :class_name => 'MediaType', :foreign_key => :MediaTypeId
    has_many :playlists, through: :playlist_tracks, dependent: :destroy
end
