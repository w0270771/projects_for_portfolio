class Salary < ActiveRecord::Base



    belongs_to :employee, :class_name => 'Employee', :foreign_key => :emp_no
end
