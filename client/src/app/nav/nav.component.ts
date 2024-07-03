import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {}
  @ViewChild('navbarCollapse') navbarCollapse!: ElementRef;

  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {

  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  toggleNavbar() {
    document.querySelectorAll('.nav-link').forEach(item => {
      item.addEventListener('click', () => {
          document.querySelector('.navbar-collapse').classList.remove('show');
      });
  });
  }

}
