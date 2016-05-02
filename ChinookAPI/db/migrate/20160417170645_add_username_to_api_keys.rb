class AddUsernameToApiKeys < ActiveRecord::Migration
  def change
    add_column :api_keys, :username, :string
  end
end
