import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../services/user/user.service';
import { EmployeeDTO } from '../../models/employeeDto';
import { CustomValidators } from '../../validations/custom-validators';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.scss']
})
export class EmployeeFormComponent implements OnInit {
  @Input() employee?: EmployeeDTO;
  employeeForm!: FormGroup;
  isSubmitting = false;

  constructor(private fb: FormBuilder, private userService: UserService) {}

  ngOnInit(): void {
    this.employeeForm = this.fb.group({
      name: [this.employee?.name || '', [Validators.required, Validators.maxLength(100)]],
      email: [this.employee?.email || '', [Validators.required, Validators.maxLength(50), CustomValidators.emailPattern()]],
      position: [this.employee?.position || '', [Validators.required, Validators.maxLength(50)]],
      salary: [this.employee?.salary || 0, [Validators.required, Validators.min(0)]],
      joinDate: ['', [Validators.required, CustomValidators.noPastDate()]]
    });
  }

  get f() { return this.employeeForm.controls; }

  submit() {
    if (this.employeeForm.invalid) return;
    this.isSubmitting = true;
    const employeeData: EmployeeDTO = {
      name: this.f['name'].value,
      email: this.f['email'].value,
      position: this.f['position'].value,
      salary: this.f['salary'].value
    };

    const request = this.employee ? 
      this.userService.updateEmployee(this.employee.id!, employeeData) :
      this.userService.addEmployee(employeeData);

    request.subscribe({
      next: res => {
        alert(`Employee ${this.employee ? 'updated' : 'added'} successfully`);
        this.employeeForm.reset();
        this.isSubmitting = false;
      },
      error: err => {
        console.error(err);
        alert('Something went wrong!');
        this.isSubmitting = false;
      }
    });
  }
}
