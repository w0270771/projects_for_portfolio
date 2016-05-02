# encoding: UTF-8
# This file is auto-generated from the current state of the database. Instead
# of editing this file, please use the migrations feature of Active Record to
# incrementally modify your database, and then regenerate this schema definition.
#
# Note that this schema.rb definition is the authoritative source for your
# database schema. If you need to create the application database on another
# system, you should be using db:schema:load, not running all the migrations
# from scratch. The latter is a flawed and unsustainable approach (the more migrations
# you'll amass, the slower it'll run and the greater likelihood for issues).
#
# It's strongly recommended that you check this file into your version control system.

ActiveRecord::Schema.define(version: 20160417181552) do

  create_table "Album", primary_key: "AlbumId", force: :cascade do |t|
    t.string  "Title",    limit: 160, null: false
    t.integer "ArtistId", limit: 4,   null: false
  end

  add_index "Album", ["ArtistId"], name: "IFK_AlbumArtistId", using: :btree

  create_table "Artist", primary_key: "ArtistId", force: :cascade do |t|
    t.string "Name", limit: 120
  end

  create_table "Customer", primary_key: "CustomerId", force: :cascade do |t|
    t.string  "FirstName",    limit: 40, null: false
    t.string  "LastName",     limit: 20, null: false
    t.string  "Company",      limit: 80
    t.string  "Address",      limit: 70
    t.string  "City",         limit: 40
    t.string  "State",        limit: 40
    t.string  "Country",      limit: 40
    t.string  "PostalCode",   limit: 10
    t.string  "Phone",        limit: 24
    t.string  "Fax",          limit: 24
    t.string  "Email",        limit: 60, null: false
    t.integer "SupportRepId", limit: 4
  end

  add_index "Customer", ["SupportRepId"], name: "IFK_CustomerSupportRepId", using: :btree

  create_table "Employee", primary_key: "EmployeeId", force: :cascade do |t|
    t.string   "LastName",   limit: 20, null: false
    t.string   "FirstName",  limit: 20, null: false
    t.string   "Title",      limit: 30
    t.integer  "ReportsTo",  limit: 4
    t.datetime "BirthDate"
    t.datetime "HireDate"
    t.string   "Address",    limit: 70
    t.string   "City",       limit: 40
    t.string   "State",      limit: 40
    t.string   "Country",    limit: 40
    t.string   "PostalCode", limit: 10
    t.string   "Phone",      limit: 24
    t.string   "Fax",        limit: 24
    t.string   "Email",      limit: 60
  end

  add_index "Employee", ["ReportsTo"], name: "IFK_EmployeeReportsTo", using: :btree

  create_table "Genre", primary_key: "GenreId", force: :cascade do |t|
    t.string "Name", limit: 120
  end

  create_table "Invoice", primary_key: "InvoiceId", force: :cascade do |t|
    t.integer  "CustomerId",        limit: 4,                           null: false
    t.datetime "InvoiceDate",                                           null: false
    t.string   "BillingAddress",    limit: 70
    t.string   "BillingCity",       limit: 40
    t.string   "BillingState",      limit: 40
    t.string   "BillingCountry",    limit: 40
    t.string   "BillingPostalCode", limit: 10
    t.decimal  "Total",                        precision: 10, scale: 2, null: false
  end

  add_index "Invoice", ["CustomerId"], name: "IFK_InvoiceCustomerId", using: :btree

  create_table "InvoiceLine", primary_key: "InvoiceLineId", force: :cascade do |t|
    t.integer "InvoiceId", limit: 4,                          null: false
    t.integer "TrackId",   limit: 4,                          null: false
    t.decimal "UnitPrice",           precision: 10, scale: 2, null: false
    t.integer "Quantity",  limit: 4,                          null: false
  end

  add_index "InvoiceLine", ["InvoiceId"], name: "IFK_InvoiceLineInvoiceId", using: :btree
  add_index "InvoiceLine", ["TrackId"], name: "IFK_InvoiceLineTrackId", using: :btree

  create_table "MediaType", primary_key: "MediaTypeId", force: :cascade do |t|
    t.string "Name", limit: 120
  end

  create_table "Playlist", primary_key: "PlaylistId", force: :cascade do |t|
    t.string  "Name",        limit: 120
    t.integer "api_keys_id", limit: 4
  end

  create_table "PlaylistTrack", id: false, force: :cascade do |t|
    t.integer "PlaylistId", limit: 4, null: false
    t.integer "TrackId",    limit: 4, null: false
  end

  add_index "PlaylistTrack", ["TrackId"], name: "IFK_PlaylistTrackTrackId", using: :btree

  create_table "Track", primary_key: "TrackId", force: :cascade do |t|
    t.string  "Name",         limit: 200,                                         null: false
    t.integer "AlbumId",      limit: 4
    t.integer "MediaTypeId",  limit: 4
    t.integer "GenreId",      limit: 4
    t.string  "Composer",     limit: 220
    t.integer "Milliseconds", limit: 4,                            default: 100,  null: false
    t.integer "Bytes",        limit: 4
    t.decimal "UnitPrice",                precision: 10, scale: 2, default: 0.99, null: false
  end

  add_index "Track", ["AlbumId"], name: "IFK_TrackAlbumId", using: :btree
  add_index "Track", ["GenreId"], name: "IFK_TrackGenreId", using: :btree
  add_index "Track", ["MediaTypeId"], name: "IFK_TrackMediaTypeId", using: :btree

  create_table "api_keys", force: :cascade do |t|
    t.string   "access_token", limit: 255
    t.datetime "created_at",               null: false
    t.datetime "updated_at",               null: false
    t.string   "username",     limit: 255
  end

  add_foreign_key "Album", "Artist", column: "ArtistId", primary_key: "ArtistId", name: "FK_AlbumArtistId"
  add_foreign_key "Customer", "Employee", column: "SupportRepId", primary_key: "EmployeeId", name: "FK_CustomerSupportRepId"
  add_foreign_key "Employee", "Employee", column: "ReportsTo", primary_key: "EmployeeId", name: "FK_EmployeeReportsTo"
  add_foreign_key "Invoice", "Customer", column: "CustomerId", primary_key: "CustomerId", name: "FK_InvoiceCustomerId"
  add_foreign_key "InvoiceLine", "Invoice", column: "InvoiceId", primary_key: "InvoiceId", name: "FK_InvoiceLineInvoiceId"
  add_foreign_key "InvoiceLine", "Track", column: "TrackId", primary_key: "TrackId", name: "FK_InvoiceLineTrackId"
  add_foreign_key "PlaylistTrack", "Playlist", column: "PlaylistId", primary_key: "PlaylistId", name: "FK_PlaylistTrackPlaylistId"
  add_foreign_key "PlaylistTrack", "Track", column: "TrackId", primary_key: "TrackId", name: "FK_PlaylistTrackTrackId"
  add_foreign_key "Track", "Album", column: "AlbumId", primary_key: "AlbumId", name: "FK_TrackAlbumId"
  add_foreign_key "Track", "Genre", column: "GenreId", primary_key: "GenreId", name: "FK_TrackGenreId"
  add_foreign_key "Track", "MediaType", column: "MediaTypeId", primary_key: "MediaTypeId", name: "FK_TrackMediaTypeId"
end
