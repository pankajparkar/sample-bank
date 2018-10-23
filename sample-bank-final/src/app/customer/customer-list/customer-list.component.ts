import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'sb-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  customers: any;
  constructor(private customerService: CustomerService) { }

  getCustomers() {
    this.customerService.filterCustomers('', '')
      .subscribe(customers => this.customers = customers)
  }

  ngOnInit() {
    this.getCustomers();
  }

}
