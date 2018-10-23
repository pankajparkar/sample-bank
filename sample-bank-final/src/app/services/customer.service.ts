import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const apiUrl = 'https://pankajparkar.azurewebsites.net';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  getAll () {
    return this.http.get(`${apiUrl}/api/customer`);
  }

  getById (id: number) {
    return this.http.get(`${apiUrl}/api/customer/${id}`);
  }

  filterCustomers(name?: string, customerType?: string, cityId?: string) {
    return this.http.get(`${apiUrl}/api/customer`, {
      params: {
        name: name || '',
        customerType: customerType|| '',
        cityId: cityId|| ''
      }
    });
  }
}
