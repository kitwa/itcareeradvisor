import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { PropertyAddComponent } from './properties/property-add/property-add.component';
import { PropertyDetailComponent } from './properties/property-detail/property-detail.component';
import { PropertyEditComponent } from './properties/property-edit/property-edit.component';
import { PropertyListComponent } from './properties/property-list/property-list.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { ResetPasswordComponent } from './resetpassword/reset-password/reset-password.component';
import { NewPasswordComponent } from './resetpassword/new-password/new-password.component';
import { authGuard } from './_guards/auth.guard';
import { adminGuard } from './_guards/admin.guard';
import { preventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { BondRepaymentComponent } from './bonrepayment/bond-repayment/bond-repayment.component';
import { BlogPostListComponent } from './blogpost/blog-post-list/blog-post-list.component';
import { BlogPostDetailComponent } from './blogpost/blog-post-detail/blog-post-detail.component';
import { BlogPostEditComponent } from './blogpost/blog-post-edit/blog-post-edit.component';
import { BlogPostAddComponent } from './blogpost/blog-post-add/blog-post-add.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'resetpassword', component: ResetPasswordComponent},
  {path: 'newpassword', component: NewPasswordComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      {path: 'members', component: MemberListComponent, canActivate: [adminGuard]},
      {path: 'members/:email', component: MemberDetailComponent},
      {path: 'member/edit', component: MemberEditComponent, canDeactivate: [preventUnsavedChangesGuard]},
      {path: 'lists', component: ListsComponent, canActivate: [adminGuard]},
      {path: 'messages', component: MessagesComponent},
      {path: 'property/edit/:id', component: PropertyEditComponent, canDeactivate: [preventUnsavedChangesGuard], canActivate: [adminGuard]},
      {path: 'property/add', component: PropertyAddComponent, canActivate: [adminGuard]},
      {path: 'admin', component: AdminPanelComponent, canActivate: [adminGuard]},
      {path: 'blogpost/edit/:id', component: BlogPostEditComponent, canDeactivate: [preventUnsavedChangesGuard], canActivate: [adminGuard]},
      {path: 'blogpost/add', component: BlogPostAddComponent, canActivate: [adminGuard]},
    ]
  },
  {path: 'properties', component: PropertyListComponent},
  {path: 'properties/:id', component: PropertyDetailComponent},
  {path: 'bonrepayment', component: BondRepaymentComponent},
  {path: 'blogposts', component: BlogPostListComponent},
  {path: 'blogposts/:id', component: BlogPostDetailComponent},
  {path: 'errors', component: TestErrorsComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component: NotFoundComponent, pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
