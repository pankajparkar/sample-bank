import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { CustomerEditComponent } from './customer/customer-edit/customer-edit.component';
import { CustomerListComponent } from './customer/customer-list/customer-list.component';
import { NetbankingComponent } from './netbanking/netbanking.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'netbanking', component: NetbankingComponent },
  { path: 'customers', component: CustomerListComponent },
  { path: 'customers/edit/:id', component: CustomerEditComponent },
  { path: 'login', component: LoginComponent },
  { path: '**', pathMatch: 'full', redirectTo: 'dashboard' }
]

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
