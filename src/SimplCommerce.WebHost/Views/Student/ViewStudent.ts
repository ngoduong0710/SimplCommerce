import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-student-list',
    template: `
    <h2>Student List</h2>
    <ul>
      <li *ngFor="let student of students">
        {{ student.name }} - {{ student.grade }}
      </li>
    </ul>
  `,
    styles: [`
    /* Add your custom styles here */
  `]
})
export class StudentListComponent implements OnInit {
    students: any[];

    constructor(private http: HttpClient) { }

    ngOnInit(): void {
        this.http.get<any[]>('https://localhost:49206/api/student/get-all')
            .subscribe(data => {
                this.students = data;
            });
    }
}
