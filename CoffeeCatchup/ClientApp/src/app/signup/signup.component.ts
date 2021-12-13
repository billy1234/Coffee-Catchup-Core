import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
    baseURL: string;


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl

  }

  ngOnInit() {
  }

  submitForm(form: NgForm) {
    if (form.valid) {
      for (var k in form.value) { //convert string true to bool true
        if (form.value[k] == "true") {
          form.value[k] = true
        }
      }
      form.value["email"] = (new Date()).toString() + "test@gamil.com"
      this.http.post<any>(this.baseURL + "api/signup/store", form.value).subscribe(x => { alert(x.result)})
    }
  }

}
