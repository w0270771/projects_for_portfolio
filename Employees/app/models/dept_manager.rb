class DeptManager < ActiveRecord::Base
    self.table_name = 'dept_manager'


    belongs_to :employee, :class_name => 'Employee', :foreign_key => :emp_no
    belongs_to :department, :class_name => 'Department', :foreign_key => :dept_no
end
