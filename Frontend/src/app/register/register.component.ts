import { Component } from '@angular/core';

import {FormBuilder,FormGroup} from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  RegForm!: FormGroup;


  constructor(private formBuilder:FormBuilder){}
  Regform = this.formBuilder.group({
    uname : '',
    email: '',
    password: '',
    cpassword:'',
    phn:'',
    addressp:''
  })
  submit(){
    console.log("ok")
    console.log(this.Regform.value)
  }
}
