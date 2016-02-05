class Department < ActiveRecord::Base

    self.primary_key = :dept_no

    has_many :dept_emps, :class_name => 'DeptEmp', :foreign_key => :dept_no
    has_many :dept_managers, :class_name => 'DeptManager', :foreign_key => :dept_no
end
