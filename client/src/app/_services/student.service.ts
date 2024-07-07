// student.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, of } from 'rxjs';
import { Student } from '../_models/student';
import { AcademicInformation } from '../_models/academicInformation';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  baseUrl = environment.apiUrl;
  academicInformations: AcademicInformation[] = [];

  constructor(private http: HttpClient) { }

  getData(appUserId: number) {
    const academicInformation = this.academicInformations.find(x => x.appUserId === appUserId);
    if(academicInformation !== undefined) return of(academicInformation);
    return this.http.get<AcademicInformation>(this.baseUrl + 'students/' + appUserId + '/get-academic-information');
  }

  updateAcademicInformstion(appUserId: number, academicInformation: AcademicInformation) {
    return this.http.put(this.baseUrl + 'students/'+ appUserId + '/edit-academic-information', academicInformation).pipe(
      map(() => {
        const index = this.academicInformations.indexOf(academicInformation);
        this.academicInformations[index] = academicInformation;
      })
    );
  }
}
