class ApiKeysController < ApplicationController
  before_action :set_api_key, only: [:show]

  # GET /api_keys
  # GET /api_keys.json
  def index
    @api_keys = ApiKey.all
    # render json: @api_keys
  end

  # GET /api_keys/1
  # GET /api_keys/1.json
  def show
    render json: @api_key
  end

  # POST /api_keys
  # POST /api_keys.json
  def create
    @api_key = ApiKey.new(api_key_params)
    @api_key.username = params[:username]

    # respond_to do |format|
      if @api_key.save
        # format.html { redirect_to @customer, notice: 'Customer was successfully created.' }
        render json: @api_key, status: :created, location: @api_key
      else
        # format.html { render :new }
        render json: @api_key.errors, status: :unprocessable_entity
      end
    # end

  end

  private

  def set_api_key
    @api_key = ApiKey.find(params[:id])
  end

  def api_key_params
    params[:api_key]
  end

end
