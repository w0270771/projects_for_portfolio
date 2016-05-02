require 'test_helper'

class ApiKeysControllerTest < ActionController::TestCase
  setup do
    @api_key = api_keys(:one)
  end

  test "should get index" do
    get :index
    assert_response :success
    assert_not_nil assigns(:api_keys)
  end

  test "should create api_key" do
    assert_difference('ApiKey.count') do
      post :create, api_key: {  }
    end

    assert_response 201
  end

  test "should show api_key" do
    get :show, id: @api_key
    assert_response :success
  end

  test "should update api_key" do
    put :update, id: @api_key, api_key: {  }
    assert_response 204
  end

  test "should destroy api_key" do
    assert_difference('ApiKey.count', -1) do
      delete :destroy, id: @api_key
    end

    assert_response 204
  end
end
