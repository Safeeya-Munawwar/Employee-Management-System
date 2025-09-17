import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user/user.service';
import { EmployeeDTO } from '../../models/employeeDto';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {
  employees: EmployeeDTO[] = [];

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees() {
    this.userService.getAllEmployees().subscribe(res => this.employees = res);
  }

  deleteEmployee(id: number) {
    if (!confirm('Are you sure?')) return;
    this.userService.deleteEmployee(id).subscribe(() => this.loadEmployees());
  }
}
