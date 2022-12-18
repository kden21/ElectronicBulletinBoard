import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'app-sign-in-card',
  templateUrl: './sign-in-card.component.html',
  styleUrls: ['./sign-in-card.component.css']
})
export class SignInCardComponent implements OnInit {

  errorText:string|null;

  constructor(private  authService:AuthService) { }

  form = new FormGroup({
    login: new FormControl<string>("", [Validators.required]),
    password: new FormControl<string>("", [Validators.required])
  })

  ngOnInit(): void {
  }

  submit(){
    this.errorText=null;
    if (this.form.invalid) {
      this.errorText='Заполните все поля';
      Object.values(this.form.controls).forEach(control => {
        if (control.invalid) {
          control.markAllAsTouched();
          control.updateValueAndValidity({onlySelf: true});
        }
      })
      return;
    }
    this.authService.login({
      login: this.form.value['login'] as string,
      password: this.form.value['password'] as string
    })
  }
}
