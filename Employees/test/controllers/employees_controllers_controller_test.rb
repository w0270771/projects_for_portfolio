require 'test_helper'

class EmployeesControllersControllerTest < ActionController::TestCase
  setup do
    @employees_controller = employees_controllers(:one)
  end

  test "should get index" do
    get :index
    assert_response :success
    assert_not_nil assigns(:employees_controllers)
  end

  test "should get new" do
    get :new
    assert_response :success
  end

  test "should create employees_controller" do
    assert_difference('EmployeesController.count') do
      post :create, employees_controller: { first_name: @employees_controller.first_name, last_name: @employees_controller.last_name }
    end

    assert_redirected_to employees_controller_path(assigns(:employees_controller))
  end

  test "should show employees_controller" do
    get :show, id: @employees_controller
    assert_response :success
  end

  test "should get edit" do
    get :edit, id: @employees_controller
    assert_response :success
  end

  test "should update employees_controller" do
    patch :update, id: @employees_controller, employees_controller: { first_name: @employees_controller.first_name, last_name: @employees_controller.last_name }
    assert_redirected_to employees_controller_path(assigns(:employees_controller))
  end

  test "should destroy employees_controller" do
    assert_difference('EmployeesController.count', -1) do
      delete :destroy, id: @employees_controller
    end

    assert_redirected_to employees_controllers_path
  end
end
