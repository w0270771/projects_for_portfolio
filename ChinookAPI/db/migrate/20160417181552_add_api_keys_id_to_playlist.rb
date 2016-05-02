class AddApiKeysIdToPlaylist < ActiveRecord::Migration
  def change
    add_column :Playlist, :api_keys_id, :integer
  end
end
