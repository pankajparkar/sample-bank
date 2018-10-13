import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'sb-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private http: HttpClient){

  }

  ngOnInit() {
    this.http.get('https://pankajparkar.azurewebsites.net/api/customer').subscribe(c => console.log(c))
  }
}
