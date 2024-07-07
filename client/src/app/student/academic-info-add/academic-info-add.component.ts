import { Component, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { AcademicInformation } from 'src/app/_models/academicInformation';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { StudentService } from 'src/app/_services/student.service';

@Component({
  selector: 'app-academic-info-add',
  templateUrl: './academic-info-add.component.html',
  styleUrl: './academic-info-add.component.css'
})
export class AcademicInfoAddComponent {
  studentForm: FormGroup;
  academicInfoForm: FormGroup;
  user: User;
  academicInformation: AcademicInformation;
  @ViewChild('editForm') editForm: NgForm;

  constructor(private fb: FormBuilder, private studentService: StudentService, private router: Router, 
    private accountService: AccountService, private toastr: ToastrService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user)
    };

    ngOnInit(): void {
      this.loadData();
    }
  
    loadData(){
      this.studentService.getData(this.user.id).subscribe(academicInformation => {
        this.academicInformation = academicInformation;
      })
    }
  
    updateAcademicInformation(){
      this.studentService.updateAcademicInformstion(this.user.id, this.academicInformation).subscribe(() => {
        this.toastr.success("Changes saved successfully");
        this.academicInfoForm.reset(this.academicInformation);
      })
  
    }

}
